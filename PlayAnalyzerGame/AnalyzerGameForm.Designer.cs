using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PlayAnalyzerGame
{
    partial class AnalyzerGameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            HairRadio = new RadioButton();
            NewGameGroupBox = new GroupBox();
            GameModeImage = new PictureBox();
            NewGameSubmitButton = new Button();
            NewGameInstructionLabel = new Label();
            BloodRadio = new RadioButton();
            DNARadio = new RadioButton();
            SubmitGuessButton = new Button();
            ColumnInputTextBox = new TextBox();
            RowInputTextBox = new TextBox();
            ColumnInputLabel = new Label();
            RowInputLabel = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            GuessCounterLabel = new Label();
            RemainingGuessesLabel = new Label();
            QuitButton = new Button();
            GuessCounterDisplayLabel = new Label();
            RemainingGuessesDisplayLabel = new Label();
            GuessEntryGroupBox = new GroupBox();
            GridDisplayBox = new RichTextBox();
            Sample1AnswerLabel = new Label();
            Sample2AnswerLabel = new Label();
            InfoLabel = new Label();
            NewGameGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)GameModeImage).BeginInit();
            GuessEntryGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // HairRadio
            // 
            HairRadio.AutoSize = true;
            HairRadio.Location = new Point(21, 52);
            HairRadio.Name = "HairRadio";
            HairRadio.Size = new Size(89, 19);
            HairRadio.TabIndex = 0;
            HairRadio.TabStop = true;
            HairRadio.Text = "Hair Sample";
            HairRadio.UseVisualStyleBackColor = true;
            // 
            // NewGameGroupBox
            // 
            NewGameGroupBox.Controls.Add(GameModeImage);
            NewGameGroupBox.Controls.Add(NewGameSubmitButton);
            NewGameGroupBox.Controls.Add(NewGameInstructionLabel);
            NewGameGroupBox.Controls.Add(BloodRadio);
            NewGameGroupBox.Controls.Add(HairRadio);
            NewGameGroupBox.Controls.Add(DNARadio);
            NewGameGroupBox.Location = new Point(27, 12);
            NewGameGroupBox.Name = "NewGameGroupBox";
            NewGameGroupBox.Size = new Size(275, 189);
            NewGameGroupBox.TabIndex = 1;
            NewGameGroupBox.TabStop = false;
            NewGameGroupBox.Text = "New Game Setup";
            // 
            // GameModeImage
            // 
            GameModeImage.Location = new Point(179, 46);
            GameModeImage.MaximumSize = new Size(75, 75);
            GameModeImage.MinimumSize = new Size(75, 75);
            GameModeImage.Name = "GameModeImage";
            GameModeImage.Size = new Size(75, 75);
            GameModeImage.TabIndex = 5;
            GameModeImage.TabStop = false;
            // 
            // NewGameSubmitButton
            // 
            NewGameSubmitButton.Location = new Point(93, 160);
            NewGameSubmitButton.Name = "NewGameSubmitButton";
            NewGameSubmitButton.Size = new Size(75, 23);
            NewGameSubmitButton.TabIndex = 4;
            NewGameSubmitButton.Text = "Submit";
            NewGameSubmitButton.UseVisualStyleBackColor = true;
            NewGameSubmitButton.Click += NewGameSubmitButton_Click;
            // 
            // NewGameInstructionLabel
            // 
            NewGameInstructionLabel.AutoSize = true;
            NewGameInstructionLabel.Location = new Point(6, 19);
            NewGameInstructionLabel.MaximumSize = new Size(200, 0);
            NewGameInstructionLabel.Name = "NewGameInstructionLabel";
            NewGameInstructionLabel.Size = new Size(192, 15);
            NewGameInstructionLabel.TabIndex = 3;
            NewGameInstructionLabel.Text = "Choose type of evidence to collect.";
            // 
            // BloodRadio
            // 
            BloodRadio.AutoSize = true;
            BloodRadio.Location = new Point(21, 77);
            BloodRadio.Name = "BloodRadio";
            BloodRadio.Size = new Size(98, 19);
            BloodRadio.TabIndex = 1;
            BloodRadio.TabStop = true;
            BloodRadio.Text = "Blood Sample";
            BloodRadio.UseVisualStyleBackColor = true;
            // 
            // DNARadio
            // 
            DNARadio.AutoSize = true;
            DNARadio.Location = new Point(21, 102);
            DNARadio.Name = "DNARadio";
            DNARadio.Size = new Size(121, 19);
            DNARadio.TabIndex = 2;
            DNARadio.TabStop = true;
            DNARadio.Text = "DNA - Hard Mode";
            DNARadio.UseVisualStyleBackColor = true;
            // 
            // SubmitGuessButton
            // 
            SubmitGuessButton.Location = new Point(23, 146);
            SubmitGuessButton.Name = "SubmitGuessButton";
            SubmitGuessButton.Size = new Size(75, 23);
            SubmitGuessButton.TabIndex = 8;
            SubmitGuessButton.Text = "Submit";
            SubmitGuessButton.UseVisualStyleBackColor = true;
            SubmitGuessButton.Click += SubmitGuessButton_Click;
            // 
            // ColumnInputTextBox
            // 
            ColumnInputTextBox.Location = new Point(23, 110);
            ColumnInputTextBox.Name = "ColumnInputTextBox";
            ColumnInputTextBox.Size = new Size(100, 23);
            ColumnInputTextBox.TabIndex = 7;
            // 
            // RowInputTextBox
            // 
            RowInputTextBox.Location = new Point(23, 59);
            RowInputTextBox.Name = "RowInputTextBox";
            RowInputTextBox.Size = new Size(100, 23);
            RowInputTextBox.TabIndex = 4;
            // 
            // ColumnInputLabel
            // 
            ColumnInputLabel.AutoSize = true;
            ColumnInputLabel.Location = new Point(23, 89);
            ColumnInputLabel.Name = "ColumnInputLabel";
            ColumnInputLabel.Size = new Size(114, 15);
            ColumnInputLabel.TabIndex = 6;
            ColumnInputLabel.Text = "Enter Column Guess";
            // 
            // RowInputLabel
            // 
            RowInputLabel.AutoSize = true;
            RowInputLabel.Location = new Point(23, 40);
            RowInputLabel.Name = "RowInputLabel";
            RowInputLabel.Size = new Size(94, 15);
            RowInputLabel.TabIndex = 4;
            RowInputLabel.Text = "Enter Row Guess";
            // 
            // GuessCounterLabel
            // 
            GuessCounterLabel.AutoSize = true;
            GuessCounterLabel.Location = new Point(71, 233);
            GuessCounterLabel.Name = "GuessCounterLabel";
            GuessCounterLabel.Size = new Size(52, 15);
            GuessCounterLabel.TabIndex = 2;
            GuessCounterLabel.Text = "Guesses:";
            // 
            // RemainingGuessesLabel
            // 
            RemainingGuessesLabel.AutoSize = true;
            RemainingGuessesLabel.Location = new Point(12, 256);
            RemainingGuessesLabel.Name = "RemainingGuessesLabel";
            RemainingGuessesLabel.Size = new Size(112, 15);
            RemainingGuessesLabel.TabIndex = 3;
            RemainingGuessesLabel.Text = "Remaining Guesses:";
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(48, 407);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(75, 23);
            QuitButton.TabIndex = 9;
            QuitButton.Text = "Give Up";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // GuessCounterDisplayLabel
            // 
            GuessCounterDisplayLabel.AutoSize = true;
            GuessCounterDisplayLabel.Location = new Point(131, 233);
            GuessCounterDisplayLabel.Name = "GuessCounterDisplayLabel";
            GuessCounterDisplayLabel.Size = new Size(0, 15);
            GuessCounterDisplayLabel.TabIndex = 10;
            // 
            // RemainingGuessesDisplayLabel
            // 
            RemainingGuessesDisplayLabel.AutoSize = true;
            RemainingGuessesDisplayLabel.Location = new Point(130, 256);
            RemainingGuessesDisplayLabel.Name = "RemainingGuessesDisplayLabel";
            RemainingGuessesDisplayLabel.Size = new Size(0, 15);
            RemainingGuessesDisplayLabel.TabIndex = 11;
            // 
            // GuessEntryGroupBox
            // 
            GuessEntryGroupBox.Controls.Add(RowInputLabel);
            GuessEntryGroupBox.Controls.Add(SubmitGuessButton);
            GuessEntryGroupBox.Controls.Add(ColumnInputLabel);
            GuessEntryGroupBox.Controls.Add(RowInputTextBox);
            GuessEntryGroupBox.Controls.Add(ColumnInputTextBox);
            GuessEntryGroupBox.Location = new Point(27, 31);
            GuessEntryGroupBox.Name = "GuessEntryGroupBox";
            GuessEntryGroupBox.Size = new Size(200, 186);
            GuessEntryGroupBox.TabIndex = 12;
            GuessEntryGroupBox.TabStop = false;
            GuessEntryGroupBox.Text = "Enter Guesses Here";
            // 
            // GridDisplayBox
            // 
            GridDisplayBox.Location = new Point(351, 71);
            GridDisplayBox.Name = "GridDisplayBox";
            GridDisplayBox.Size = new Size(256, 247);
            GridDisplayBox.TabIndex = 13;
            GridDisplayBox.Text = "";
            // 
            // Sample1AnswerLabel
            // 
            Sample1AnswerLabel.AutoSize = true;
            Sample1AnswerLabel.Location = new Point(351, 22);
            Sample1AnswerLabel.Name = "Sample1AnswerLabel";
            Sample1AnswerLabel.Size = new Size(38, 15);
            Sample1AnswerLabel.TabIndex = 14;
            Sample1AnswerLabel.Text = "label1";
            // 
            // Sample2AnswerLabel
            // 
            Sample2AnswerLabel.AutoSize = true;
            Sample2AnswerLabel.Location = new Point(351, 48);
            Sample2AnswerLabel.Name = "Sample2AnswerLabel";
            Sample2AnswerLabel.Size = new Size(38, 15);
            Sample2AnswerLabel.TabIndex = 15;
            Sample2AnswerLabel.Text = "label1";
            // 
            // InfoLabel
            // 
            InfoLabel.AutoSize = true;
            InfoLabel.Location = new Point(12, 303);
            InfoLabel.Name = "InfoLabel";
            InfoLabel.Size = new Size(0, 15);
            InfoLabel.TabIndex = 16;
            // 
            // ScanalyzerGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 461);
            Controls.Add(InfoLabel);
            Controls.Add(Sample2AnswerLabel);
            Controls.Add(Sample1AnswerLabel);
            Controls.Add(GridDisplayBox);
            Controls.Add(GuessEntryGroupBox);
            Controls.Add(RemainingGuessesDisplayLabel);
            Controls.Add(GuessCounterDisplayLabel);
            Controls.Add(QuitButton);
            Controls.Add(RemainingGuessesLabel);
            Controls.Add(GuessCounterLabel);
            Controls.Add(NewGameGroupBox);
            Name = "ScanalyzerGameForm";
            Text = "ScanAlyzer";
            NewGameGroupBox.ResumeLayout(false);
            NewGameGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)GameModeImage).EndInit();
            GuessEntryGroupBox.ResumeLayout(false);
            GuessEntryGroupBox.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton HairRadio;
        private GroupBox NewGameGroupBox;
        private RadioButton DNARadio;
        private RadioButton BloodRadio;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label NewGameInstructionLabel;
        private Button NewGameSubmitButton;
        private PictureBox GameModeImage;
        private Label RowInputLabel;
        private Label GuessCounterLabel;
        private Label RemainingGuessesLabel;
        private Button SubmitGuessButton;
        private TextBox ColumnInputTextBox;
        private TextBox RowInputTextBox;
        private Label ColumnInputLabel;
        private Button QuitButton;
        private Label GuessCounterDisplayLabel;
        private Label RemainingGuessesDisplayLabel;
        private GroupBox GuessEntryGroupBox;
        private RichTextBox GridDisplayBox;
        private Label Sample1AnswerLabel;
        private Label Sample2AnswerLabel;
        private Label InfoLabel;
    }
}
