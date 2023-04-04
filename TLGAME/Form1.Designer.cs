namespace TLGAME
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MenuPanel = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.PictureBox();
            this.LoadButton = new System.Windows.Forms.PictureBox();
            this.SaveButton = new System.Windows.Forms.PictureBox();
            this.NewGameButton = new System.Windows.Forms.PictureBox();
            this.ContinueButton = new System.Windows.Forms.PictureBox();
            this.PictureBoxRight = new System.Windows.Forms.PictureBox();
            this.PictureBoxGameField = new System.Windows.Forms.PictureBox();
            this.PictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewGameButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinueButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGameField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPanel
            // 
            this.MenuPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(28)))));
            this.MenuPanel.Controls.Add(this.ExitButton);
            this.MenuPanel.Controls.Add(this.LoadButton);
            this.MenuPanel.Controls.Add(this.SaveButton);
            this.MenuPanel.Controls.Add(this.NewGameButton);
            this.MenuPanel.Controls.Add(this.ContinueButton);
            this.MenuPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.MenuPanel.Location = new System.Drawing.Point(735, 160);
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Size = new System.Drawing.Size(450, 400);
            this.MenuPanel.TabIndex = 3;
            // 
            // ExitButton
            // 
            this.ExitButton.BackColor = System.Drawing.Color.Transparent;
            this.ExitButton.Image = global::TLGAME.Properties.Resources.Button10;
            this.ExitButton.Location = new System.Drawing.Point(45, 299);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(360, 60);
            this.ExitButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ExitButton.TabIndex = 4;
            this.ExitButton.TabStop = false;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            this.ExitButton.MouseLeave += new System.EventHandler(this.ExitButton_MouseLeave);
            this.ExitButton.MouseHover += new System.EventHandler(this.ExitButton_MouseHover);
            // 
            // LoadButton
            // 
            this.LoadButton.BackColor = System.Drawing.Color.Transparent;
            this.LoadButton.Image = global::TLGAME.Properties.Resources.Button8;
            this.LoadButton.Location = new System.Drawing.Point(45, 233);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(360, 60);
            this.LoadButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LoadButton.TabIndex = 3;
            this.LoadButton.TabStop = false;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            this.LoadButton.MouseLeave += new System.EventHandler(this.LoadButton_MouseLeave);
            this.LoadButton.MouseHover += new System.EventHandler(this.LoadButton_MouseHover);
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.Transparent;
            this.SaveButton.Image = global::TLGAME.Properties.Resources.Button6;
            this.SaveButton.Location = new System.Drawing.Point(45, 167);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(360, 60);
            this.SaveButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.SaveButton.TabIndex = 2;
            this.SaveButton.TabStop = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            this.SaveButton.MouseLeave += new System.EventHandler(this.SaveButton_MouseLeave);
            this.SaveButton.MouseHover += new System.EventHandler(this.SaveButton_MouseHover);
            // 
            // NewGameButton
            // 
            this.NewGameButton.BackColor = System.Drawing.Color.Transparent;
            this.NewGameButton.Image = global::TLGAME.Properties.Resources.Button4;
            this.NewGameButton.Location = new System.Drawing.Point(45, 101);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(360, 60);
            this.NewGameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.NewGameButton.TabIndex = 1;
            this.NewGameButton.TabStop = false;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            this.NewGameButton.MouseLeave += new System.EventHandler(this.NewGameButton_MouseLeave);
            this.NewGameButton.MouseHover += new System.EventHandler(this.NewGameButton_MouseHover);
            // 
            // ContinueButton
            // 
            this.ContinueButton.BackColor = System.Drawing.Color.Transparent;
            this.ContinueButton.Image = global::TLGAME.Properties.Resources.Button2;
            this.ContinueButton.Location = new System.Drawing.Point(45, 35);
            this.ContinueButton.Name = "ContinueButton";
            this.ContinueButton.Size = new System.Drawing.Size(360, 60);
            this.ContinueButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.ContinueButton.TabIndex = 0;
            this.ContinueButton.TabStop = false;
            this.ContinueButton.Click += new System.EventHandler(this.ContinueButton_Click);
            this.ContinueButton.MouseLeave += new System.EventHandler(this.ContinueButton_MouseLeave);
            this.ContinueButton.MouseHover += new System.EventHandler(this.ContinueButton_MouseHover);
            // 
            // PictureBoxRight
            // 
            this.PictureBoxRight.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBoxRight.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxRight.Image")));
            this.PictureBoxRight.Location = new System.Drawing.Point(1440, 0);
            this.PictureBoxRight.Name = "PictureBoxRight";
            this.PictureBoxRight.Size = new System.Drawing.Size(480, 1080);
            this.PictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxRight.TabIndex = 2;
            this.PictureBoxRight.TabStop = false;
            // 
            // PictureBoxGameField
            // 
            this.PictureBoxGameField.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBoxGameField.Location = new System.Drawing.Point(480, 0);
            this.PictureBoxGameField.Name = "PictureBoxGameField";
            this.PictureBoxGameField.Size = new System.Drawing.Size(960, 1080);
            this.PictureBoxGameField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PictureBoxGameField.TabIndex = 1;
            this.PictureBoxGameField.TabStop = false;
            this.PictureBoxGameField.Click += new System.EventHandler(this.PictureBoxGameField_Click);
            // 
            // PictureBoxLeft
            // 
            this.PictureBoxLeft.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PictureBoxLeft.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PictureBoxLeft.BackgroundImage")));
            this.PictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("PictureBoxLeft.Image")));
            this.PictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.PictureBoxLeft.Name = "PictureBoxLeft";
            this.PictureBoxLeft.Size = new System.Drawing.Size(480, 1080);
            this.PictureBoxLeft.TabIndex = 0;
            this.PictureBoxLeft.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.MenuPanel);
            this.Controls.Add(this.PictureBoxRight);
            this.Controls.Add(this.PictureBoxGameField);
            this.Controls.Add(this.PictureBoxLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Ticker Loss";
            this.MenuPanel.ResumeLayout(false);
            this.MenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaveButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NewGameButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ContinueButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxGameField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxLeft)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox PictureBoxGameField;
        private System.Windows.Forms.PictureBox PictureBoxRight;
        private System.Windows.Forms.PictureBox PictureBoxLeft;
        private System.Windows.Forms.Panel MenuPanel;
        private System.Windows.Forms.PictureBox ExitButton;
        private System.Windows.Forms.PictureBox LoadButton;
        private System.Windows.Forms.PictureBox SaveButton;
        private System.Windows.Forms.PictureBox NewGameButton;
        private System.Windows.Forms.PictureBox ContinueButton;
    }
}

