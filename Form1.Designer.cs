namespace grp2Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            daycontainer = new FlowLayoutPanel();
            btnNext = new Button();
            btnPrevious = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            LBDATE = new Label();
            txtMonth = new TextBox();
            txtYear = new TextBox();
            btnGo = new Button();
            SuspendLayout();
            // 
            // daycontainer
            // 
            resources.ApplyResources(daycontainer, "daycontainer");
            daycontainer.Name = "daycontainer";
            // 
            // btnNext
            // 
            resources.ApplyResources(btnNext, "btnNext");
            btnNext.Name = "btnNext";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrevious
            // 
            resources.ApplyResources(btnPrevious, "btnPrevious");
            btnPrevious.Name = "btnPrevious";
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Click += btnPrevious_Click;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = Color.FromArgb(255, 128, 128);
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.ForeColor = Color.DodgerBlue;
            label7.Name = "label7";
            // 
            // LBDATE
            // 
            resources.ApplyResources(LBDATE, "LBDATE");
            LBDATE.Name = "LBDATE";
            // 
            // txtMonth
            // 
            resources.ApplyResources(txtMonth, "txtMonth");
            txtMonth.Name = "txtMonth";
            // 
            // txtYear
            // 
            resources.ApplyResources(txtYear, "txtYear");
            txtYear.Name = "txtYear";
            // 
            // btnGo
            // 
            resources.ApplyResources(btnGo, "btnGo");
            btnGo.Name = "btnGo";
            btnGo.UseVisualStyleBackColor = true;
            btnGo.Click += btnGo_Click;
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnableAllowFocusChange;
            BackColor = SystemColors.Control;
            Controls.Add(btnGo);
            Controls.Add(txtYear);
            Controls.Add(txtMonth);
            Controls.Add(LBDATE);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnPrevious);
            Controls.Add(btnNext);
            Controls.Add(daycontainer);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel daycontainer;
        private Button btnNext;
        private Button btnPrevious;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label LBDATE;
        private TextBox txtMonth;
        private TextBox txtYear;
        private Button btnGo;
    }
}
