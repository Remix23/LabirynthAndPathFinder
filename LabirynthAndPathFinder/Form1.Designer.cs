namespace LabirynthAndPathFinder
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.genMazeBtn = new System.Windows.Forms.Button();
            this.solveBtn = new System.Windows.Forms.Button();
            this.showAnimationCheck = new System.Windows.Forms.CheckBox();
            this.ClearBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(865, 629);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // genMazeBtn
            // 
            this.genMazeBtn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.genMazeBtn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.genMazeBtn.Location = new System.Drawing.Point(904, 12);
            this.genMazeBtn.Margin = new System.Windows.Forms.Padding(0);
            this.genMazeBtn.Name = "genMazeBtn";
            this.genMazeBtn.Size = new System.Drawing.Size(109, 23);
            this.genMazeBtn.TabIndex = 1;
            this.genMazeBtn.Text = "Generate Maze";
            this.genMazeBtn.UseVisualStyleBackColor = false;
            this.genMazeBtn.Click += new System.EventHandler(this.genMazeBtn_Click);
            // 
            // solveBtn
            // 
            this.solveBtn.Location = new System.Drawing.Point(904, 66);
            this.solveBtn.Name = "solveBtn";
            this.solveBtn.Size = new System.Drawing.Size(109, 23);
            this.solveBtn.TabIndex = 2;
            this.solveBtn.Text = "Solve";
            this.solveBtn.UseVisualStyleBackColor = true;
            this.solveBtn.Click += new System.EventHandler(this.solveBtn_Click);
            // 
            // showAnimationCheck
            // 
            this.showAnimationCheck.AutoSize = true;
            this.showAnimationCheck.Location = new System.Drawing.Point(904, 123);
            this.showAnimationCheck.Name = "showAnimationCheck";
            this.showAnimationCheck.Size = new System.Drawing.Size(141, 19);
            this.showAnimationCheck.TabIndex = 3;
            this.showAnimationCheck.Text = "Show Path Animation";
            this.showAnimationCheck.UseVisualStyleBackColor = true;
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(904, 173);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(110, 23);
            this.ClearBtn.TabIndex = 4;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 653);
            this.Controls.Add(this.ClearBtn);
            this.Controls.Add(this.showAnimationCheck);
            this.Controls.Add(this.solveBtn);
            this.Controls.Add(this.genMazeBtn);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Button genMazeBtn;
        private Button solveBtn;
        private CheckBox showAnimationCheck;
        private Button ClearBtn;
    }
}