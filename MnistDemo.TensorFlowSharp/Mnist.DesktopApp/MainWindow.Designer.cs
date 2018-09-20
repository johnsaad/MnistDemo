namespace Mnist.DesktopApp
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberLabel = new System.Windows.Forms.Label();
            this.recognizeButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "The Handwritten Digit:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(419, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "The Result:";
            // 
            // numberLabel
            // 
            this.numberLabel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.numberLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberLabel.Location = new System.Drawing.Point(422, 79);
            this.numberLabel.Name = "numberLabel";
            this.numberLabel.Size = new System.Drawing.Size(187, 187);
            this.numberLabel.TabIndex = 5;
            this.numberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // recognizeButton
            // 
            this.recognizeButton.FlatAppearance.BorderSize = 0;
            this.recognizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.recognizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.recognizeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recognizeButton.Location = new System.Drawing.Point(420, 400);
            this.recognizeButton.Name = "recognizeButton";
            this.recognizeButton.Size = new System.Drawing.Size(90, 30);
            this.recognizeButton.TabIndex = 7;
            this.recognizeButton.Text = "Recognize";
            this.recognizeButton.UseVisualStyleBackColor = true;
            this.recognizeButton.Paint += recognizeButton_Paint;
            this.recognizeButton.Click += recognizeButton_Click;
            // 
            // clearButton
            // 
            this.clearButton.FlatAppearance.BorderSize = 0;
            this.clearButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlLight;
            this.clearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.clearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearButton.Location = new System.Drawing.Point(520, 400);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(90, 30);
            this.clearButton.TabIndex = 9;
            this.clearButton.TabStop = false;
            this.clearButton.Text = "Clear Digit";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Paint += clearButton_Paint;
            this.clearButton.Click += clearButton_Click;
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imagePanel.Location = new System.Drawing.Point(43, 79);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(350, 350);
            this.imagePanel.TabIndex = 8;
            this.imagePanel.MouseDown += imagePanel_MouseDown;
            this.imagePanel.MouseEnter += imagePanel_MouseEnter;
            this.imagePanel.MouseLeave += imagePanel_MouseLeave;
            this.imagePanel.MouseMove += imagePanel_MouseMove;
            this.imagePanel.MouseUp += imagePanel_MouseUp;
            this.imagePanel.Paint += imagePanel_Paint;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(652, 523);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.recognizeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numberLabel);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Handwriting Digit Recognition";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numberLabel;
        private System.Windows.Forms.Button recognizeButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Panel imagePanel;
    }
}
