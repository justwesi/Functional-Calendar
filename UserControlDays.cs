using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace grp2Calendar
{
    public partial class UserControlDays : UserControl
    {
        // 🎨 COLOR DEFINITIONS
        private Color normalBackColor = Color.White;                     // Default background color
        private Color sundayColor = Color.FromArgb(255, 210, 220);       // Light pink for Sundays
        private Color saturdayColor = Color.FromArgb(200, 225, 255);     // Light blue for Saturdays
        private Color hoverBorderColor = Color.Black;                    // Border color when hovered

        // ⚙️ STATE VARIABLES
        private Color originalBackColor;                                 // Stores color before hover
        private bool isHovered = false;                                  // Tracks if the mouse is over the control
        private bool isWeekend = false;                                  // Identifies if the day is a Saturday or Sunday

        // 🧱 CONSTRUCTOR
        public UserControlDays()
        {
            InitializeComponent();

            // Enable smooth drawing and prevent flicker
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer,
                true
            );

            // Attach hover event handlers
            this.MouseEnter += UserControlDays_MouseEnter;
            this.MouseLeave += UserControlDays_MouseLeave;
        }

        // 📅 PROPERTIES
        public DateTime Date { get; private set; } // Stores the full date of the day box


        // 🌟 METHODS
        public void HighlightAsToday()            /// Highlights the current day visually.
        {
            this.BackColor = Color.LightGray;

            // Make label text bold safely
            if (lbdays != null)
                lbdays.Font = new Font(lbdays.Font, FontStyle.Bold);
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            // Reserved for future logic (currently empty)
        }

        /// Sets the day number label.
        public void days(int numday)
        {
            lbdays.Text = numday.ToString();
        }

        /// Changes the day number’s text color.
        public void SetDayColor(Color color)
        {
            lbdays.ForeColor = color;
        }

        /// Applies weekend color based on the day of the week.
        public void SetWeekendType(DayOfWeek dayOfWeek)
        {
            if (dayOfWeek == DayOfWeek.Sunday)
            {
                this.BackColor = sundayColor;
                isWeekend = true;
            }
            else if (dayOfWeek == DayOfWeek.Saturday)
            {
                this.BackColor = saturdayColor;
                isWeekend = true;
            }
            else
            {
                this.BackColor = normalBackColor;
                isWeekend = false;
            }
        }

        /// Sets the Date value for this day.
        public void SetDate(DateTime date)
        {
            Date = date;
        }

        // 🖌️ CUSTOM DRAWING
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int borderRadius = 15;

            // Create a rounded rectangle path
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
            path.AddArc(Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
            path.AddArc(Width - borderRadius, Height - borderRadius, borderRadius, borderRadius, 0, 90);
            path.AddArc(0, Height - borderRadius, borderRadius, borderRadius, 90, 90);
            path.CloseAllFigures();

            // Apply rounded corners to the control
            this.Region = new Region(path);

            // Draw hover border (only for weekdays)
            if (isHovered && !isWeekend)
            {
                using (Pen pen = new Pen(hoverBorderColor, 3))
                {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        // 🖱️ HOVER EVENTS
        private void UserControlDays_MouseEnter(object sender, EventArgs e)
        {
            isHovered = true;
            originalBackColor = this.BackColor;

            // Keep weekday background white
            if (!isWeekend)
            {
                this.BackColor = normalBackColor;
            }

            this.Cursor = Cursors.Hand; // Change cursor to hand
            this.Invalidate();          // Redraw control
        }

        private void UserControlDays_MouseLeave(object sender, EventArgs e)
        {
            isHovered = false;

            // Restore the original background color
            this.BackColor = originalBackColor;
            this.Invalidate();
        }

        // ==============================
        // 🖱️ CLICK EVENT (RAISES TO FORM)
        // ==============================

        // Triggered when a day is clicked
        public event EventHandler<DateTime> DayClicked;

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            DayClicked?.Invoke(this, Date);
        }
    }
}
