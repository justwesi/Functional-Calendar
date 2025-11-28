
namespace grp2Calendar
{
    partial class UserControlDays
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
            lbdays = new Label();
            SuspendLayout();
            // 
            // lbdays
            // 
            lbdays.AutoSize = true;
            lbdays.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbdays.Location = new Point(106, 15);
            lbdays.Name = "lbdays";
            lbdays.Size = new Size(30, 23);
            lbdays.TabIndex = 0;
            lbdays.Text = "00";
            // 
            // UserControlDays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(lbdays);
            Name = "UserControlDays";
            Size = new Size(150, 108);
            Load += UserControlDays_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private void lbdays_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.LightGray; // highlight selected day
        }

        #endregion
        private Label lbdays;
    }
}
