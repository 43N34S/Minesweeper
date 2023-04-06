using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Minesweeper.Properties;
using System.Security;

namespace Minesweeper
{
    public class GameLogic
    {
        public MineSweeper Form;
        #region LOGIC
        #region Static
        Random random = new Random();

        public static int NumberOfMines = 10;
        public enum GameLogicElements
        {
            Empty = 0,
            Mine = 1,
            Number = 2
        };
        public int GameFieldSize = 8;
        #endregion
        #region Session
        int SessionRealAmountOfMines;
        int SessionDisplayAmountOfMines;
        public GameLogicElements[,] GameFieldLogic; //0 - empty, 1 - mine, 2 - number
        public bool[,] GameFieldFlaggedCells;
        public bool[,] GameFieldKnownCells;
        public int[,] GameFieldCellSurroundingsMines;
        public bool IsDigging = true; // false means that player is placing flags
        public bool GameIsActive = false; //Determines whether or not player can push buttons
        #endregion
        #endregion
        #region STATS
        public int CurrentSessionTime = 0;
        int BestSessionTime = 0;
        #endregion

        #region FUNCTIONS
        #region Field functions

        public void NewGameBegin()
        { //Cleans up the mess you did in the previous session and giving you a chance to confess your sins
            CurrentSessionTime = 0;
            Form.GameTimerIsActive = true;
            #region Initialising 2D bool array of known cells and setting all the values to False
            GameFieldKnownCells = new bool[GameFieldSize, GameFieldSize];
            for(int x = 0; x < GameFieldSize; x++)
            {
                for(int y = 0; y < GameFieldSize; y++)
                {
                    GameFieldKnownCells[x, y] = false;
                }
            }
            #endregion
            #region Initialising 2D bool array of flagged cells and setting them all to false just like in the known cells array
            GameFieldFlaggedCells = new bool[GameFieldSize, GameFieldSize];
            for (int x = 0; x < GameFieldSize; x++)
            {
                for (int y = 0; y < GameFieldSize; y++)
                {
                    GameFieldFlaggedCells[x, y] = false;
                }
            }
            #endregion
            #region Initialising 2D GameLogicElements enum array and placing logic elements
            GameFieldLogic = new GameLogicElements[GameFieldSize, GameFieldSize];
            #region Setting all cells from undefined to Empty
            for (int X = 0; X < GameFieldSize; X++)
            {
                for (int Y = 0; Y < GameFieldSize; Y++)
                {
                    GameFieldLogic[X,Y] = GameLogicElements.Empty;
                }
            }
            #endregion
            #region Placing Mines
            for (int NumberOfBombsPlaced = 0; NumberOfBombsPlaced < NumberOfMines; NumberOfBombsPlaced++)
            {
                int MineX = random.Next(0, GameFieldSize);
                int MineY = random.Next(0, GameFieldSize);
                while (GameFieldLogic[MineX, MineY] == GameLogicElements.Mine)
                {
                    MineX = random.Next(0, GameFieldSize);
                    MineY = random.Next(0, GameFieldSize);
                }
                GameFieldLogic[MineX, MineY] = GameLogicElements.Mine;
            }
            #endregion
            #region Figuring out what cells are neighbouring to mines and assigning numbers to them
            GameFieldCellSurroundingsMines = new int[GameFieldSize, GameFieldSize];
            for (int x = 0; x < GameFieldSize; x++)
            {
                for (int y = 0; y < GameFieldSize; y++)
                {
                    if (GameFieldLogic[x,y] != GameLogicElements.Mine)
                    {
                        for (int CurrentSurroundingX = ClampInt(x - 1, 0, 7); CurrentSurroundingX < ClampInt(x + 2, 0, 8); CurrentSurroundingX++)
                        {
                            for (int CurrentSurroundingY = ClampInt(y - 1, 0, 7); CurrentSurroundingY < ClampInt(y + 2, 0, 8); CurrentSurroundingY++)
                            {
                                if (GameFieldLogic[CurrentSurroundingX, CurrentSurroundingY] == GameLogicElements.Mine)
                                {
                                    GameFieldLogic[x,y] = GameLogicElements.Number;
                                    GameFieldCellSurroundingsMines[x,y]++;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            #endregion
            GameIsActive = true; //Giving player a permission to use game field
            if (!IsDigging) 
            {
                ChangeDefuseMode();
            } //By default setting state of the interaction to Digging because i decided to
            SessionRealAmountOfMines = NumberOfMines;
            SessionDisplayAmountOfMines = NumberOfMines;
            Form.CurrentMood = MineSweeper.SmileState.Thinking;
            Form.Render();
        }

        public void ButtonClick(ref Button[,] GameButtons, Button sender)
        {
            if (GameIsActive)
            {
                Form.CurrentMood = MineSweeper.SmileState.Thinking;
                #region Identify coords of button that was pressed
                int SenderX = 0;
                int SenderY = 0;
                for (int x =  0; x < GameFieldSize; x++)
                {
                    for (int y = 0; y < GameFieldSize; y++)
                    {
                        if(sender == GameButtons[x, y])
                        {
                            SenderX = x;
                            SenderY = y;
                            break;
                        }
                    }
                }
                #endregion
                if (IsDigging)
                {
                    if (!GameFieldKnownCells[SenderX, SenderY])
                    {
                        switch(GameFieldLogic[SenderX, SenderY])
                        {
                            case GameLogicElements.Empty:
                                GameFieldKnownCells[SenderX, SenderY] = true;
                                CheckNeigbouringCells(SenderX, SenderY);
                                break;
                            case GameLogicElements.Number:
                                GameFieldKnownCells[SenderX,SenderY] = true;
                                break;
                            case GameLogicElements.Mine:
                                Form.CurrentMood = MineSweeper.SmileState.Loose;
                                GameIsActive = false;
                                for(int x = 0; x < GameFieldSize; x++)
                                {
                                    for (int y = 0; y < GameFieldSize; y++)
                                    {
                                        GameFieldFlaggedCells[x, y] = true;
                                        GameFieldKnownCells[x, y] = true;
                                    }
                                }
                                Form.GameTimerIsActive = false;
                                MessageBox.Show("Ви програли!□");
                                break;

                        }

                    }
                }
                else if (!GameFieldKnownCells[SenderX, SenderY])
                {
                    switch(GameFieldFlaggedCells[SenderX, SenderY])
                    {
                        case true:
                            SessionDisplayAmountOfMines++;
                            if (GameFieldLogic[SenderX, SenderY] == GameLogicElements.Mine)
                            {
                                SessionRealAmountOfMines++;
                            }
                            break;
                        case false:
                            SessionDisplayAmountOfMines--;
                            if (GameFieldLogic[SenderX, SenderY] == GameLogicElements.Mine)
                            {
                                SessionRealAmountOfMines--;
                            }
                            break;
                    }
                    GameFieldFlaggedCells[SenderX,SenderY] = !GameFieldFlaggedCells[SenderX, SenderY];
                } //Happens if interaction mode is Flagging
                if(SessionRealAmountOfMines == 0 && SessionDisplayAmountOfMines == 0)
                {
                    for(int x = 0; x < GameFieldSize; x++)
                    {
                        for (int y = 0; y < GameFieldSize; y++)
                        {
                            if (!GameFieldFlaggedCells[x, y])
                            {
                                GameFieldKnownCells[x,y] = true;
                            }
                        }
                    }
                    if(BestSessionTime > CurrentSessionTime || BestSessionTime == 0)
                    {
                        BestSessionTime = CurrentSessionTime;
                        Form.ChangeBestSessionTime(BestSessionTime);
                    }
                    Form.GameTimerIsActive = false;
                    MessageBox.Show("Ви виграли!■");
                    Form.CurrentMood = MineSweeper.SmileState.Win;
                    GameIsActive = false;
                }
                Form.Render();
            }
        }
        

        public void ChangeDefuseMode()
        {
            IsDigging = !IsDigging;
            Form.Render();
        }

        #endregion
        #region Math functions
        public int ClampInt(int number, int minVal, int maxVal)
        {
            int ReturnVal = number;
            if (ReturnVal < minVal)
            {
                ReturnVal = minVal;
            }
            if (ReturnVal > maxVal)
            {
                ReturnVal = maxVal;
            }
            return ReturnVal;
        }
        public void CheckNeigbouringCells(int XCord, int YCord)
        {
            if (GameFieldLogic[XCord, YCord] == GameLogicElements.Empty)
            {
                for (int X = ClampInt(XCord - 1, 0, 7); X < ClampInt(XCord + 2, 0, 8); X++)
                {
                    for (int Y = ClampInt(YCord - 1, 0, 7); Y < ClampInt(YCord + 2, 0, 8); Y++)
                    {
                        if (GameFieldKnownCells[X, Y] == false)
                        {
                            GameFieldFlaggedCells[X, Y] = false;
                            GameFieldKnownCells[X, Y] = true;
                            CheckNeigbouringCells(X, Y);
                            Form.Render();
                        }
                    }
                }
            }
        }
        #endregion
        #endregion
    }
}