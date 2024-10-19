namespace PlayAnalyzerGame
{
    partial class InputFileForm
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
            OpenFileButton = new Button();
            openFileDialog1 = new OpenFileDialog();
            DirectionsTitle = new Label();
            DirectionsText = new Label();
            ExampleBox = new GroupBox();
            ExampleTextBox = new RichTextBox();
            ExampleBox.SuspendLayout();
            SuspendLayout();
            // 
            // OpenFileButton
            // 
            OpenFileButton.Font = new Font("Lucida Sans Typewriter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            OpenFileButton.Location = new Point(143, 314);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(135, 45);
            OpenFileButton.TabIndex = 0;
            OpenFileButton.Text = "Open File";
            OpenFileButton.UseVisualStyleBackColor = true;
            OpenFileButton.Click += button1_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // DirectionsTitle
            // 
            DirectionsTitle.AutoSize = true;
            DirectionsTitle.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            DirectionsTitle.Location = new Point(143, 9);
            DirectionsTitle.Name = "DirectionsTitle";
            DirectionsTitle.Size = new Size(152, 27);
            DirectionsTitle.TabIndex = 1;
            DirectionsTitle.Text = "Directions";
            // 
            // DirectionsText
            // 
            DirectionsText.AutoSize = true;
            DirectionsText.Font = new Font("Lucida Sans Typewriter", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DirectionsText.Location = new Point(68, 50);
            DirectionsText.Name = "DirectionsText";
            DirectionsText.Size = new Size(318, 84);
            DirectionsText.TabIndex = 2;
            DirectionsText.Text = "To play the game please \r\ninput a .txt file with your \r\nrow, column, and number \r\nof samples like so:\r\n";
            // 
            // ExampleBox
            // 
            ExampleBox.Controls.Add(ExampleTextBox);
            ExampleBox.Location = new Point(123, 157);
            ExampleBox.Name = "ExampleBox";
            ExampleBox.Size = new Size(172, 130);
            ExampleBox.TabIndex = 3;
            ExampleBox.TabStop = false;
            ExampleBox.Text = "Example";
            // 
            // ExampleTextBox
            // 
            ExampleTextBox.Font = new Font("Lucida Sans Typewriter", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ExampleTextBox.Location = new Point(20, 40);
            ExampleTextBox.Name = "ExampleTextBox";
            ExampleTextBox.Size = new Size(135, 85);
            ExampleTextBox.TabIndex = 0;
            ExampleTextBox.Text = "4 3\n2";
            // 
            // InputFileForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(443, 371);
            Controls.Add(ExampleBox);
            Controls.Add(DirectionsText);
            Controls.Add(DirectionsTitle);
            Controls.Add(OpenFileButton);
            Name = "InputFileForm";
            Text = "Open File";
            ExampleBox.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button OpenFileButton;
        private OpenFileDialog openFileDialog1;
        private Label DirectionsTitle;
        private Label DirectionsText;
        private GroupBox ExampleBox;
        private RichTextBox ExampleTextBox;
    }
}