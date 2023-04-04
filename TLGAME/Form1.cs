using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TLGAME.Properties;

namespace TLGAME
{
    public partial class Form1 : Form
    {
        Level level_1;
        Credits creditsWindow;
        Graphics pir, pil;
        private readonly Timer mainTimer;
        private int tick = 0;
        private bool pause = true;
        public Form1()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
            PictureBoxGameField.BackColor = Color.FromArgb(255, 16, 18, 28);
            PictureBoxGameField.BackgroundImage = Properties.Resources.title2;
            //PictureBoxGameField.BackgroundImageLayout = ImageLayout.Center;
            //DoubleBuffered = true;
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            PictureBoxGameField.Paint += new PaintEventHandler(DrawLevel);
            //PictureBoxRight.Paint += new PaintEventHandler(DrawInterface);
            mainTimer = new Timer
            {
                Interval = Globals.TIMER_INTERVAL
            };
            mainTimer.Tick += new EventHandler(Update);
            
            Init();
        }

        private void PictureBoxGameField_Click(object sender, EventArgs e)
        {
            if (creditsWindow.Enabled)
                creditsWindow.Close();
            pause = false;

        }

        public void Update(object sender, EventArgs e)
        {
            if (level_1.Exist && pause == false)
            {
                PictureBoxGameField.Invalidate();
                if (tick == 0)
                {
                    level_1.InterfaceStart(pir, pil);
                }

                if (tick % Globals.INTERFACE_UPDATE_TIME == 0)
                {
                    level_1.InterfaceIter(pir);
                    level_1.ChatIter(pil);
                }
                tick++;
            }
        }

        public void Init()
        {
            level_1 = new Level();
            KeyDown += level_1.KeyDown;
            KeyUp += level_1.KeyUp;
            pir = PictureBoxRight.CreateGraphics();
            pil = PictureBoxLeft.CreateGraphics();
        }

        private void DrawLevel(object sender, PaintEventArgs e)
        {
            if (level_1.Exist && pause == false)
            {
                Graphics g = e.Graphics;
                level_1.LevelIter(g);
            }
        }

        private void Credit()
        {
            if (pause == false)
            {
                creditsWindow = new Credits();
                creditsWindow.Show();
                pause = true;
            }
            else
            {
                creditsWindow.Hide();
                pause = false;
            }
        }
        private void ShowHint()
        {
            if (pause == false)
            {
                PictureBoxGameField.BackgroundImage = Properties.Resources.Hint;
                pause = true;
            }
            else
            {
                PictureBoxGameField.BackgroundImage = null;
                pause = false;
            }
        }

        private void ShowMenu()
        {
            if (pause == false)
            {
                MenuPanel.Show();
                pause = true;
            }
            else
            {
                MenuPanel.Hide();
                PictureBoxGameField.BackgroundImage = null;
                pause = false;
            }
        }


        private void ContinueButton_Click(object sender, EventArgs e)
        {
            if (level_1.Exist)
            {
                MenuPanel.Hide();
                pause = false;
            }
            else
            {
                if(File.Exists("save.dat"))
                {
                    PictureBoxGameField.BackgroundImage = null;
                    level_1.PauseGame -= ShowMenu;
                    level_1.Credits -= Credit;
                    level_1.GameHint -= ShowHint;
                    level_1.LevelStart();
                    mainTimer.Start();
                    level_1.Load();
                    level_1.PauseGame += ShowMenu;
                    level_1.Credits -= Credit;
                    level_1.GameHint += ShowHint;
                    MenuPanel.Hide();
                    pause = false;
                }
            }
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            PictureBoxGameField.BackgroundImage = null;
            level_1.PauseGame -= ShowMenu;
            level_1.Credits -= Credit;
            level_1.GameHint -= ShowHint;
            level_1.LevelStart();
            mainTimer.Start();
            level_1.PauseGame += ShowMenu;
            level_1.Credits += Credit;
            level_1.GameHint += ShowHint;
            MenuPanel.Hide();
            pause = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (level_1.Exist)
            {
                level_1.Save();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadButton_Click(object sender, EventArgs e)
        {
            PictureBoxGameField.BackgroundImage = null;
            level_1.PauseGame -= ShowMenu;
            level_1.Credits -= Credit;
            level_1.GameHint -= ShowHint;
            level_1.LevelStart();
            mainTimer.Start();
            level_1.Load();
            level_1.PauseGame += ShowMenu;
            level_1.Credits += Credit;
            level_1.GameHint += ShowHint;
            MenuPanel.Hide();
            pause = false;
        }

        private void ContinueButton_MouseHover(object sender, EventArgs e)
        {
            ContinueButton.BackgroundImage = Properties.Resources.Button1;
        }

        private void NewGameButton_MouseHover(object sender, EventArgs e)
        {
            NewGameButton.BackgroundImage = Properties.Resources.Button3;
        }

        private void SaveButton_MouseHover(object sender, EventArgs e)
        {
            SaveButton.BackgroundImage = Properties.Resources.Button5;
        }

        private void LoadButton_MouseHover(object sender, EventArgs e)
        {
            LoadButton.BackgroundImage = Properties.Resources.Button7;
        }

        private void ExitButton_MouseHover(object sender, EventArgs e)
        {
            ExitButton.BackgroundImage = Properties.Resources.Button9;
        }

        private void ContinueButton_MouseLeave(object sender, EventArgs e)
        {
            ContinueButton.BackgroundImage = Properties.Resources.Button2;
        }

        private void NewGameButton_MouseLeave(object sender, EventArgs e)
        {
           NewGameButton.BackgroundImage = Properties.Resources.Button4;
        }

        private void SaveButton_MouseLeave(object sender, EventArgs e)
        {
            SaveButton.BackgroundImage = Properties.Resources.Button6;
        }

        private void LoadButton_MouseLeave(object sender, EventArgs e)
        {
            LoadButton.BackgroundImage = Properties.Resources.Button8;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
           ExitButton.BackgroundImage = Properties.Resources.Button10;
        }

    }
}
