namespace WinFormsApp
{
    partial class UserCtl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            resultLb = new Label();
            checkBox1 = new CheckBox();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // resultLb
            // 
            resultLb.Location = new Point(10, 10);
            resultLb.Name = "resultLb";
            resultLb.Size = new Size(161, 23);
            resultLb.TabIndex = 1;
            resultLb.Text = "result";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(444, 208);
            checkBox1.Name = "checkBox";
            checkBox1.Size = new Size(120, 29);
            checkBox1.TabIndex = 1;
            checkBox1.Text = "check Box";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox
            // 
            pictureBox.AccessibleName = "NoImage";
            pictureBox.Location = new Point(416, 79);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(100, 79);
            pictureBox.TabIndex = 2;
            pictureBox.TabStop = false;
            // 
            // UserCtl
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pictureBox);
            Controls.Add(resultLb);
            Controls.Add(checkBox1);
            Name = "UserCtl";
            Size = new Size(646, 420);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label resultLb;
        private CheckBox checkBox1;
        private PictureBox pictureBox;
    }
}
