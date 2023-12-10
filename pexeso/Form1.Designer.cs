namespace pexeso
{
    partial class MainWdw
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
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.lblMoves = new System.Windows.Forms.Label();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.grpBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox
            // 
            this.grpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox.AutoSize = true;
            this.grpBox.BackColor = System.Drawing.Color.Transparent;
            this.grpBox.Controls.Add(this.lblEnd);
            this.grpBox.Location = new System.Drawing.Point(13, 13);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(642, 427);
            this.grpBox.TabIndex = 0;
            this.grpBox.TabStop = false;
            // 
            // lblMoves
            // 
            this.lblMoves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMoves.AutoSize = true;
            this.lblMoves.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblMoves.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMoves.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblMoves.Location = new System.Drawing.Point(661, 26);
            this.lblMoves.Name = "lblMoves";
            this.lblMoves.Size = new System.Drawing.Size(166, 42);
            this.lblMoves.TabIndex = 1;
            this.lblMoves.Text = "lblMoves";
            this.lblMoves.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTimer
            // 
            this.lblTimer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimer.AutoSize = true;
            this.lblTimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.lblTimer.Location = new System.Drawing.Point(661, 86);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(139, 39);
            this.lblTimer.TabIndex = 2;
            this.lblTimer.Text = "lblTimer";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblEnd.ForeColor = System.Drawing.Color.DarkRed;
            this.lblEnd.Location = new System.Drawing.Point(254, 170);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(158, 55);
            this.lblEnd.TabIndex = 0;
            this.lblEnd.Text = "label1";
            this.lblEnd.Visible = false;
            // 
            // MainWdw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 452);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.lblMoves);
            this.Controls.Add(this.grpBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MaximizeBox = false;
            this.Name = "MainWdw";
            this.Text = "PEXESO";
            this.grpBox.ResumeLayout(false);
            this.grpBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.Label lblMoves;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.Label lblEnd;
    }
}

