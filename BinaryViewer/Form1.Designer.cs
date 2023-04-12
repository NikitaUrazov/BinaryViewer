namespace BinaryViewer
{
    partial class Form1
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
            filePath_textBox = new TextBox();
            filePath_button = new Button();
            offset_textBox = new TextBox();
            offset_button = new Button();
            result_textBox = new TextBox();
            SuspendLayout();
            // 
            // filePath_textBox
            // 
            filePath_textBox.Location = new Point(36, 38);
            filePath_textBox.Name = "filePath_textBox";
            filePath_textBox.Size = new Size(216, 23);
            filePath_textBox.TabIndex = 0;
            filePath_textBox.Text = "Полное имя файла";
            // 
            // filePath_button
            // 
            filePath_button.Location = new Point(258, 38);
            filePath_button.Name = "filePath_button";
            filePath_button.Size = new Size(75, 23);
            filePath_button.TabIndex = 1;
            filePath_button.Text = "Ввод";
            filePath_button.UseVisualStyleBackColor = true;
            filePath_button.Click += filePath_button_Click;
            // 
            // offset_textBox
            // 
            offset_textBox.Location = new Point(461, 38);
            offset_textBox.Name = "offset_textBox";
            offset_textBox.Size = new Size(190, 23);
            offset_textBox.TabIndex = 2;
            offset_textBox.Text = "Смещение";
            // 
            // offset_button
            // 
            offset_button.Location = new Point(657, 38);
            offset_button.Name = "offset_button";
            offset_button.Size = new Size(75, 23);
            offset_button.TabIndex = 3;
            offset_button.Text = "Перейти";
            offset_button.UseVisualStyleBackColor = true;
            offset_button.Click += offset_button_Click;
            // 
            // result_textBox
            // 
            result_textBox.Location = new Point(36, 93);
            result_textBox.Multiline = true;
            result_textBox.Name = "result_textBox";
            result_textBox.ReadOnly = true;
            result_textBox.ScrollBars = ScrollBars.Both;
            result_textBox.Size = new Size(696, 328);
            result_textBox.TabIndex = 4;
            result_textBox.WordWrap = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(result_textBox);
            Controls.Add(offset_button);
            Controls.Add(offset_textBox);
            Controls.Add(filePath_button);
            Controls.Add(filePath_textBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox filePath_textBox;
        private Button filePath_button;
        private TextBox offset_textBox;
        private Button offset_button;
        private TextBox result_textBox;
    }
}