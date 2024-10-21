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
            SubmitGuessButton = new Button();
            ColInputTextBox = new TextBox();
            RowInputTextBox = new TextBox();
            ColInputLabel = new Label();
            RowInputLabel = new Label();
            GuessCounterLabel = new Label();
            RemainingGuessesLabel = new Label();
            QuitButton = new Button();
            GuessCounterDisplayLabel = new Label();
            RemainingGuessesDisplayLabel = new Label();
            GuessEntryGroupBox = new GroupBox();
            PlayAgainButton = new Button();
            GridDisplayBox = new RichTextBox();
            SamplesFoundLabel = new Label();
            SamplesFoundDisplayLabel = new Label();
            ResultsBox = new GroupBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            GuessEntryGroupBox.SuspendLayout();
            ResultsBox.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // SubmitGuessButton
            // 
            SubmitGuessButton.Location = new Point(8, 204);
            SubmitGuessButton.Margin = new Padding(4);
            SubmitGuessButton.Name = "SubmitGuessButton";
            SubmitGuessButton.Size = new Size(118, 32);
            SubmitGuessButton.TabIndex = 8;
            SubmitGuessButton.Text = "Submit";
            SubmitGuessButton.UseVisualStyleBackColor = true;
            SubmitGuessButton.Click += SubmitGuessButton_Click;
            // 
            // ColInputTextBox
            // 
            ColInputTextBox.Location = new Point(36, 154);
            ColInputTextBox.Margin = new Padding(4);
            ColInputTextBox.Name = "ColInputTextBox";
            ColInputTextBox.Size = new Size(188, 20);
            ColInputTextBox.TabIndex = 7;
            // 
            // RowInputTextBox
            // 
            RowInputTextBox.Location = new Point(36, 82);
            RowInputTextBox.Margin = new Padding(4);
            RowInputTextBox.Name = "RowInputTextBox";
            RowInputTextBox.Size = new Size(188, 20);
            RowInputTextBox.TabIndex = 4;
            // 
            // ColInputLabel
            // 
            ColInputLabel.AutoSize = true;
            ColInputLabel.Location = new Point(36, 124);
            ColInputLabel.Margin = new Padding(4, 0, 4, 0);
            ColInputLabel.Name = "ColInputLabel";
            ColInputLabel.Size = new Size(103, 13);
            ColInputLabel.TabIndex = 6;
            ColInputLabel.Text = "Enter Column Guess";
            // 
            // RowInputLabel
            // 
            RowInputLabel.AutoSize = true;
            RowInputLabel.Location = new Point(36, 56);
            RowInputLabel.Margin = new Padding(4, 0, 4, 0);
            RowInputLabel.Name = "RowInputLabel";
            RowInputLabel.Size = new Size(90, 13);
            RowInputLabel.TabIndex = 4;
            RowInputLabel.Text = "Enter Row Guess";
            // 
            // GuessCounterLabel
            // 
            GuessCounterLabel.AutoSize = true;
            GuessCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            GuessCounterLabel.Location = new Point(8, 35);
            GuessCounterLabel.Margin = new Padding(4, 0, 4, 0);
            GuessCounterLabel.Name = "GuessCounterLabel";
            GuessCounterLabel.Size = new Size(51, 13);
            GuessCounterLabel.TabIndex = 2;
            GuessCounterLabel.Text = "Guesses:";
            // 
            // RemainingGuessesLabel
            // 
            RemainingGuessesLabel.AutoSize = true;
            RemainingGuessesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            RemainingGuessesLabel.Location = new Point(8, 67);
            RemainingGuessesLabel.Margin = new Padding(4, 0, 4, 0);
            RemainingGuessesLabel.Name = "RemainingGuessesLabel";
            RemainingGuessesLabel.Size = new Size(57, 26);
            RemainingGuessesLabel.TabIndex = 3;
            RemainingGuessesLabel.Text = "Remaining\r\nGuesses:";
            // 
            // QuitButton
            // 
            QuitButton.Location = new Point(163, 204);
            QuitButton.Margin = new Padding(4);
            QuitButton.Name = "QuitButton";
            QuitButton.Size = new Size(118, 32);
            QuitButton.TabIndex = 9;
            QuitButton.Text = "Give Up";
            QuitButton.UseVisualStyleBackColor = true;
            QuitButton.Click += QuitButton_Click;
            // 
            // GuessCounterDisplayLabel
            // 
            GuessCounterDisplayLabel.AutoSize = true;
            GuessCounterDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            GuessCounterDisplayLabel.Location = new Point(133, 35);
            GuessCounterDisplayLabel.Margin = new Padding(4, 0, 4, 0);
            GuessCounterDisplayLabel.Name = "GuessCounterDisplayLabel";
            GuessCounterDisplayLabel.Size = new Size(0, 13);
            GuessCounterDisplayLabel.TabIndex = 10;
            // 
            // RemainingGuessesDisplayLabel
            // 
            RemainingGuessesDisplayLabel.AutoSize = true;
            RemainingGuessesDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            RemainingGuessesDisplayLabel.Location = new Point(133, 82);
            RemainingGuessesDisplayLabel.Margin = new Padding(4, 0, 4, 0);
            RemainingGuessesDisplayLabel.Name = "RemainingGuessesDisplayLabel";
            RemainingGuessesDisplayLabel.Size = new Size(0, 13);
            RemainingGuessesDisplayLabel.TabIndex = 11;
            // 
            // GuessEntryGroupBox
            // 
            GuessEntryGroupBox.Controls.Add(PlayAgainButton);
            GuessEntryGroupBox.Controls.Add(RowInputLabel);
            GuessEntryGroupBox.Controls.Add(SubmitGuessButton);
            GuessEntryGroupBox.Controls.Add(ColInputLabel);
            GuessEntryGroupBox.Controls.Add(RowInputTextBox);
            GuessEntryGroupBox.Controls.Add(ColInputTextBox);
            GuessEntryGroupBox.Controls.Add(QuitButton);
            GuessEntryGroupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            GuessEntryGroupBox.Location = new Point(13, 206);
            GuessEntryGroupBox.Margin = new Padding(4);
            GuessEntryGroupBox.Name = "GuessEntryGroupBox";
            GuessEntryGroupBox.Padding = new Padding(4);
            GuessEntryGroupBox.Size = new Size(315, 260);
            GuessEntryGroupBox.TabIndex = 12;
            GuessEntryGroupBox.TabStop = false;
            GuessEntryGroupBox.Text = "Enter Guesses Here";
            // 
            // PlayAgainButton
            // 
            PlayAgainButton.Location = new Point(8, 204);
            PlayAgainButton.Margin = new Padding(4);
            PlayAgainButton.Name = "PlayAgainButton";
            PlayAgainButton.Size = new Size(118, 32);
            PlayAgainButton.TabIndex = 10;
            PlayAgainButton.Text = "Play Again";
            PlayAgainButton.UseVisualStyleBackColor = true;
            PlayAgainButton.Visible = false;
            PlayAgainButton.Click += PlayAgainButton_Click;
            // 
            // GridDisplayBox
            // 
            GridDisplayBox.Font = new System.Drawing.Font("Lucida Console", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            GridDisplayBox.Location = new Point(359, 22);
            GridDisplayBox.Margin = new Padding(4);
            GridDisplayBox.Name = "GridDisplayBox";
            GridDisplayBox.Size = new Size(416, 389);
            GridDisplayBox.TabIndex = 13;
            GridDisplayBox.Text = "";
            // 
            // SamplesFoundLabel
            // 
            SamplesFoundLabel.AutoSize = true;
            SamplesFoundLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            SamplesFoundLabel.Location = new Point(8, 117);
            SamplesFoundLabel.Margin = new Padding(4, 0, 4, 0);
            SamplesFoundLabel.Name = "SamplesFoundLabel";
            SamplesFoundLabel.Size = new Size(47, 26);
            SamplesFoundLabel.TabIndex = 17;
            SamplesFoundLabel.Text = "Samples\r\nFound:";
            // 
            // SamplesFoundDisplayLabel
            // 
            SamplesFoundDisplayLabel.AutoSize = true;
            SamplesFoundDisplayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            SamplesFoundDisplayLabel.Location = new Point(116, 132);
            SamplesFoundDisplayLabel.Margin = new Padding(4, 0, 4, 0);
            SamplesFoundDisplayLabel.Name = "SamplesFoundDisplayLabel";
            SamplesFoundDisplayLabel.Size = new Size(0, 13);
            SamplesFoundDisplayLabel.TabIndex = 18;
            // 
            // ResultsBox
            // 
            ResultsBox.Controls.Add(GuessCounterLabel);
            ResultsBox.Controls.Add(SamplesFoundDisplayLabel);
            ResultsBox.Controls.Add(RemainingGuessesLabel);
            ResultsBox.Controls.Add(SamplesFoundLabel);
            ResultsBox.Controls.Add(GuessCounterDisplayLabel);
            ResultsBox.Controls.Add(RemainingGuessesDisplayLabel);
            ResultsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            ResultsBox.Location = new Point(782, 22);
            ResultsBox.Name = "ResultsBox";
            ResultsBox.Size = new Size(279, 389);
            ResultsBox.TabIndex = 19;
            ResultsBox.TabStop = false;
            ResultsBox.Text = "Results";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            label2.Location = new Point(6, 34);
            label2.Name = "label2";
            label2.Size = new Size(144, 91);
            label2.TabIndex = 21;
            label2.Text = "Input a X and Y value below \r\nand hit submit. Only \r\nnonnegative integers are\r\nallowed and MUST be within\r\nthe grid size!!\r\nToo hard? That's what the \r\ngive up button is for :P";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, FontStyle.Underline, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(13, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(315, 187);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "Directions";
            // 
            // AnalyzerGameForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 479);
            Controls.Add(groupBox1);
            Controls.Add(ResultsBox);
            Controls.Add(GridDisplayBox);
            Controls.Add(GuessEntryGroupBox);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4);
            Name = "AnalyzerGameForm";
            Text = "Analyzer Game";
            GuessEntryGroupBox.ResumeLayout(false);
            GuessEntryGroupBox.PerformLayout();
            ResultsBox.ResumeLayout(false);
            ResultsBox.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label RowInputLabel;
        private Label GuessCounterLabel;
        private Label RemainingGuessesLabel;
        private Button SubmitGuessButton;
        private TextBox ColInputTextBox;
        private TextBox RowInputTextBox;
        private Label ColInputLabel;
        private Button QuitButton;
        private Label GuessCounterDisplayLabel;
        private Label RemainingGuessesDisplayLabel;
        private GroupBox GuessEntryGroupBox;
        private RichTextBox GridDisplayBox;
        private Label SamplesFoundLabel;
        private Label SamplesFoundDisplayLabel;
        private GroupBox ResultsBox;
        private Label label2;
        private GroupBox groupBox1;
        private Button PlayAgainButton;
    }
}
