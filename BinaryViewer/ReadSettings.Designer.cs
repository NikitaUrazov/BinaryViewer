namespace BinaryViewer
{
    partial class ReadSettings
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
            beginOffset_textbox = new TextBox();
            endOffset_textbox = new TextBox();
            from0_button = new Button();
            toEnd_button = new Button();
            accept_button = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // beginOffset_textbox
            // 
            beginOffset_textbox.Location = new Point(27, 40);
            beginOffset_textbox.Name = "beginOffset_textbox";
            beginOffset_textbox.Size = new Size(121, 23);
            beginOffset_textbox.TabIndex = 0;
            // 
            // endOffset_textbox
            // 
            endOffset_textbox.Location = new Point(27, 97);
            endOffset_textbox.Name = "endOffset_textbox";
            endOffset_textbox.Size = new Size(121, 23);
            endOffset_textbox.TabIndex = 1;
            // 
            // from0_button
            // 
            from0_button.Location = new Point(171, 39);
            from0_button.Name = "from0_button";
            from0_button.Size = new Size(75, 23);
            from0_button.TabIndex = 2;
            from0_button.Text = "С начала";
            from0_button.UseVisualStyleBackColor = true;
            from0_button.Click += from0_button_Click;
            // 
            // toEnd_button
            // 
            toEnd_button.Location = new Point(171, 97);
            toEnd_button.Name = "toEnd_button";
            toEnd_button.Size = new Size(75, 23);
            toEnd_button.TabIndex = 3;
            toEnd_button.Text = "До конца";
            toEnd_button.UseVisualStyleBackColor = true;
            toEnd_button.Click += toEnd_button_Click;
            // 
            // accept_button
            // 
            accept_button.Location = new Point(94, 141);
            accept_button.Name = "accept_button";
            accept_button.Size = new Size(75, 23);
            accept_button.TabIndex = 4;
            accept_button.Text = "Принять";
            accept_button.UseVisualStyleBackColor = true;
            accept_button.Click += accept_button_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 22);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 5;
            label1.Text = "Читать с смещения";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 79);
            label2.Name = "label2";
            label2.Size = new Size(121, 15);
            label2.TabIndex = 6;
            label2.Text = "Читать до смещения";
            // 
            // ReadSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(276, 186);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(accept_button);
            Controls.Add(toEnd_button);
            Controls.Add(from0_button);
            Controls.Add(endOffset_textbox);
            Controls.Add(beginOffset_textbox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReadSettings";
            Text = "Настройки чтения";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox beginOffset_textbox;
        private TextBox endOffset_textbox;
        private Button from0_button;
        private Button toEnd_button;
        private Button accept_button;
        private Label label1;
        private Label label2;
    }
}