namespace PlayAnalyzerGame
{
    partial class PickGameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NewGameGroupBox = new GroupBox();
            BackButton = new Button();
            GameModeImage = new PictureBox();
            PlayButton = new Button();
            NewGameInstructionLabel = new Label();
            PrintRadio = new RadioButton();
            HairRadio = new RadioButton();
            DNARadio = new RadioButton();
            NewGameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GameModeImage).BeginInit();
            SuspendLayout();
            // 
            // NewGameGroupBox
            // 
            NewGameGroupBox.Controls.Add(BackButton);
            NewGameGroupBox.Controls.Add(GameModeImage);
            NewGameGroupBox.Controls.Add(PlayButton);
            NewGameGroupBox.Controls.Add(NewGameInstructionLabel);
            NewGameGroupBox.Controls.Add(PrintRadio);
            NewGameGroupBox.Controls.Add(HairRadio);
            NewGameGroupBox.Controls.Add(DNARadio);
            NewGameGroupBox.Font = new Font("Lucida Sans Typewriter", 12F);
            NewGameGroupBox.Location = new Point(25, 28);
            NewGameGroupBox.Margin = new Padding(4, 5, 4, 5);
            NewGameGroupBox.Name = "NewGameGroupBox";
            NewGameGroupBox.Padding = new Padding(4, 5, 4, 5);
            NewGameGroupBox.Size = new Size(393, 315);
            NewGameGroupBox.TabIndex = 2;
            NewGameGroupBox.TabStop = false;
            NewGameGroupBox.Text = "New Game";
            // 
            // BackButton
            // 
            BackButton.Font = new Font("Lucida Sans Typewriter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BackButton.Location = new Point(256, 267);
            BackButton.Margin = new Padding(4, 5, 4, 5);
            BackButton.Name = "BackButton";
            BackButton.Size = new Size(107, 38);
            BackButton.TabIndex = 6;
            BackButton.Text = "Back";
            BackButton.UseVisualStyleBackColor = true;
            BackButton.Click += BackButton_Click;
            // 
            // GameModeImage
            // 
            GameModeImage.Image = Properties.Resources.magnifyingGlass;
            GameModeImage.Location = new Point(256, 77);
            GameModeImage.Margin = new Padding(4, 5, 4, 5);
            GameModeImage.MaximumSize = new Size(107, 125);
            GameModeImage.MinimumSize = new Size(107, 125);
            GameModeImage.Name = "GameModeImage";
            GameModeImage.Size = new Size(107, 125);
            GameModeImage.SizeMode = PictureBoxSizeMode.StretchImage;
            GameModeImage.TabIndex = 5;
            GameModeImage.TabStop = false;
            // 
            // PlayButton
            // 
            PlayButton.Font = new Font("Lucida Sans Typewriter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            PlayButton.Location = new Point(31, 267);
            PlayButton.Margin = new Padding(4, 5, 4, 5);
            PlayButton.Name = "PlayButton";
            PlayButton.Size = new Size(107, 38);
            PlayButton.TabIndex = 4;
            PlayButton.Text = "Play";
            PlayButton.UseVisualStyleBackColor = true;
            PlayButton.Click += PlayButton_Click;
            // 
            // NewGameInstructionLabel
            // 
            NewGameInstructionLabel.AutoSize = true;
            NewGameInstructionLabel.Font = new Font("Lucida Sans Typewriter", 9F);
            NewGameInstructionLabel.Location = new Point(10, 34);
            NewGameInstructionLabel.Margin = new Padding(4, 0, 4, 0);
            NewGameInstructionLabel.MaximumSize = new Size(286, 0);
            NewGameInstructionLabel.Name = "NewGameInstructionLabel";
            NewGameInstructionLabel.Size = new Size(274, 42);
            NewGameInstructionLabel.TabIndex = 3;
            NewGameInstructionLabel.Text = "Choose type of evidence to collect.";
            // 
            // PrintRadio
            // 
            PrintRadio.AutoSize = true;
            PrintRadio.Font = new Font("Lucida Sans Typewriter", 9F);
            PrintRadio.Location = new Point(31, 130);
            PrintRadio.Margin = new Padding(4, 5, 4, 5);
            PrintRadio.Name = "PrintRadio";
            PrintRadio.Size = new Size(167, 25);
            PrintRadio.TabIndex = 1;
            PrintRadio.Text = "Print Sample";
            PrintRadio.UseVisualStyleBackColor = true;
            // 
            // HairRadio
            // 
            HairRadio.AutoSize = true;
            HairRadio.Checked = true;
            HairRadio.Font = new Font("Lucida Sans Typewriter", 9F);
            HairRadio.Location = new Point(31, 89);
            HairRadio.Margin = new Padding(4, 5, 4, 5);
            HairRadio.Name = "HairRadio";
            HairRadio.Size = new Size(156, 25);
            HairRadio.TabIndex = 0;
            HairRadio.TabStop = true;
            HairRadio.Text = "Hair Sample";
            HairRadio.UseVisualStyleBackColor = true;
            // 
            // DNARadio
            // 
            DNARadio.AutoSize = true;
            DNARadio.Font = new Font("Lucida Sans Typewriter", 9F);
            DNARadio.Location = new Point(31, 172);
            DNARadio.Margin = new Padding(4, 5, 4, 5);
            DNARadio.Name = "DNARadio";
            DNARadio.Size = new Size(200, 25);
            DNARadio.TabIndex = 2;
            DNARadio.Text = "DNA - Hard Mode";
            DNARadio.UseVisualStyleBackColor = true;
            // 
            // PickGameForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 371);
            Controls.Add(NewGameGroupBox);
            Name = "PickGameForm";
            Text = "Pick Game";
            NewGameGroupBox.ResumeLayout(false);
            NewGameGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GameModeImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox NewGameGroupBox;
        private Button BackButton;
        private PictureBox GameModeImage;
        private Button PlayButton;
        private Label NewGameInstructionLabel;
        private RadioButton PrintRadio;
        private RadioButton HairRadio;
        private RadioButton DNARadio;
    }
}