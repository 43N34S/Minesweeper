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

namespace Minesweeper
{
    public partial class MineSweeper : Form
    {
        #region RENDER VARS
        Random random = new Random();
        public enum SmileState
        {
            Win,
            Loose,
            Thinking
        }
        public SmileState CurrentMood;
        Image MoodWin = Image.FromFile(Application.StartupPath + "\\Sprites\\SmileWin.png");
        Image MoodLoose = Image.FromFile(Application.StartupPath + "\\Sprites\\SmileDefeat.png");
        Image[] MoodThinking = new Image[5]
        {
            Image.FromFile(Application.StartupPath + "\\Sprites\\SmileThinking01.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\SmileThinking02.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\SmileThinking03.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\SmileThinking04.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\SmileThinking05.png")
        };

        Image imgMine = Image.FromFile(Application.StartupPath + "\\Sprites\\Mine.png");
        Image imgFlag = Image.FromFile(Application.StartupPath + "\\Sprites\\Flag.png");
        Image imgShowel = Image.FromFile(Application.StartupPath + "\\Sprites\\Showel.png");
        Image[] imgNumbers = new Image[8]
        {
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num1.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num2.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num3.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num4.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num5.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num6.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num7.png"),
            Image.FromFile(Application.StartupPath + "\\Sprites\\Num8.png")
        };
        #endregion
        public bool GameTimerIsActive = true;

        GameLogic gameLogic = new GameLogic();
        public Button[,] GameFieldButtons;
        
        public MineSweeper()
        {
            InitializeComponent();
            gameLogic.Form = this;
            GameFieldButtons = new Button[8, 8]
            {
                {btnGF00,btnGF01,btnGF02,btnGF03,btnGF04,btnGF05,btnGF06,btnGF07},
                {btnGF10,btnGF11,btnGF12,btnGF13,btnGF14,btnGF15,btnGF16,btnGF17},
                {btnGF20,btnGF21,btnGF22,btnGF23,btnGF24,btnGF25,btnGF26,btnGF27},
                {btnGF30,btnGF31,btnGF32,btnGF33,btnGF34,btnGF35,btnGF36,btnGF37},
                {btnGF40,btnGF41,btnGF42,btnGF43,btnGF44,btnGF45,btnGF46,btnGF47},
                {btnGF50,btnGF51,btnGF52,btnGF53,btnGF54,btnGF55,btnGF56,btnGF57},
                {btnGF60,btnGF61,btnGF62,btnGF63,btnGF64,btnGF65,btnGF66,btnGF67},
                {btnGF70,btnGF71,btnGF72,btnGF73,btnGF74,btnGF75,btnGF76,btnGF77},
            }; //Initialization of buttons array, it needs to be executed inside form initialisation
            gameLogic.NewGameBegin();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }        

        private void btnNewSession_Click(object sender, EventArgs e)
        {
            gameLogic.NewGameBegin();
        }

        
        public void GameFieldClick(object Btn)
        {
            gameLogic.ButtonClick(ref GameFieldButtons, (Button)Btn);
        }

        #region ClickEvents
        private void button10_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }
        private void btnGF07_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF02_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF00_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF01_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF03_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF04_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF05_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF06_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF10_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF11_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF12_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF13_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF14_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF15_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF16_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF17_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF20_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF21_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF22_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF23_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF24_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF25_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF26_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF27_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF30_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF31_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF32_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF33_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF34_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF35_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF37_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF47_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF46_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF45_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF44_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF43_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF42_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF41_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF40_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF50_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF51_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF52_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF53_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF54_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF55_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF56_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF57_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF67_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF66_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF65_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF64_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF63_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF62_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF61_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF60_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF70_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF71_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF72_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF73_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF74_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF75_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF76_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }

        private void btnGF77_Click(object sender, EventArgs e)
        {
            GameFieldClick(sender);
        }
        #endregion

        private void btnChangeDefuseMode_Click(object sender, EventArgs e)
        {
            gameLogic.ChangeDefuseMode();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GameTimerIsActive)
            {
                gameLogic.CurrentSessionTime++;
                lblSessionTime.Text = gameLogic.CurrentSessionTime.ToString();
            }
        }

        public void ChangeBestSessionTime(int Time) {
            lblBestSessionTime.Text = Time.ToString();
        }

        public void Render()
        {
            switch (gameLogic.IsDigging)
            {
                case true:
                    btnChangeDefuseMode.Image = imgShowel;
                    break;
                case false:
                    btnChangeDefuseMode.Image = imgFlag; 
                    break;
            }
            switch (CurrentMood)
            {
                case SmileState.Win:
                    btnNewSession.Image = MoodWin;
                    break;
                case SmileState.Loose:
                    btnNewSession.Image = MoodLoose;
                    break;
                case SmileState.Thinking:
                    btnNewSession.Image = MoodThinking[random.Next(0, MoodThinking.Length)];
                    break;
            }
            for (int x = 0; x < gameLogic.GameFieldSize; x++)
            {
                for (int y = 0; y < gameLogic.GameFieldSize; y++)
                {
                    GameFieldButtons[x, y].BackColor = Color.Empty;
                    GameFieldButtons[x, y].Image = null;
                    if (gameLogic.GameFieldKnownCells[x, y])
                    {
                        switch (gameLogic.GameFieldLogic[x, y])
                        {
                            case GameLogic.GameLogicElements.Empty:
                                GameFieldButtons[x, y].BackColor = Color.LightGray;
                                break;
                            case GameLogic.GameLogicElements.Number:
                                GameFieldButtons[x, y].BackColor = Color.LightGray;
                                GameFieldButtons[x, y].Image = imgNumbers[gameLogic.GameFieldCellSurroundingsMines[x, y] - 1];
                                break;
                            case GameLogic.GameLogicElements.Mine:
                                GameFieldButtons[x, y].Image = imgMine;
                                break;
                        }
                    }
                    else if (gameLogic.GameFieldFlaggedCells[x, y])
                    {
                        GameFieldButtons[x, y].Image = imgFlag;
                    }
                }
            }
        }
    }
}
