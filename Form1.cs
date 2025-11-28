using System.Globalization;
using System.Text.Json;
using System.IO;

namespace grp2Calendar
{
    public partial class Form1 : Form
    {

        // Fields and Variables
        int month, year;     // Tracks the current month and year
        private Dictionary<DateTime, string> events = new Dictionary<DateTime, string>();  // Stores events by date
        private string eventsFilePath = "events.json"; // JSON file path for saving events

        // Constructor
        public Form1()
        {
            InitializeComponent();
        }

        // 🚀 Form Load Event
        private void Form1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            LoadEvents();                 // Load saved events from JSON file
            DisplayDays(month, year);     // Display current month

            // Show reminder if today has an event
            DateTime today = DateTime.Today;
            if (events.ContainsKey(today))
            {
                MessageBox.Show(
                    $"📅 You have an event today:\n\n{events[today]}",
                    "Today's Event Reminder",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        // Load events when the program starts
        private void LoadEvents()
        {
            if (File.Exists(eventsFilePath))
            {
                string json = File.ReadAllText(eventsFilePath);
                events = JsonSerializer.Deserialize<Dictionary<DateTime, string>>(json);
            }
        }

        // Save events to the JSON file
        private void SaveEvents()
        {
            string json = JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(eventsFilePath, json);
        }


        // Display Calendar Days
        private void DisplayDays(int month, int year)
        {
            // Clear previous day controls
            daycontainer.Controls.Clear();

            // Set month name and year in the label
            string monthname = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            LBDATE.Text = "\uD83D\uDDD3 " + monthname + " " + year; // Month Year

            // Get the first day and total number of days in the month
            DateTime startOfTheMonth = new DateTime(year, month, 1);
            int days = DateTime.DaysInMonth(year, month);
            int dayOfTheWeek = (int)startOfTheMonth.DayOfWeek;

            // Add blank spaces before the first day of the month
            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlBlank ucBlank = new UserControlBlank();
                daycontainer.Controls.Add(ucBlank);
            }

            // Generate day boxes for each date
            for (int i = 1; i <= days; i++)
            {
                UserControlDays ucDays = new UserControlDays();
                ucDays.days(i);

                DateTime date = new DateTime(year, month, i);
                ucDays.SetDate(date);
                ucDays.SetWeekendType(date.DayOfWeek);

                // Highlight today's date
                if (date == DateTime.Today)
                    ucDays.HighlightAsToday();

                // Mark day if it has an event
                if (events.ContainsKey(date))
                    ucDays.SetDayColor(Color.DarkGreen);

                // Handle day click event
                ucDays.DayClicked += UcDays_DayClicked;
                daycontainer.Controls.Add(ucDays);
            }
        }

        //  Add or Edit Event
        private void UcDays_DayClicked(object sender, DateTime date)
        {
            // Open Add Event form for selected date
            EventForm eventForm = new EventForm(date);

            // If user saves an event
            if (eventForm.ShowDialog() == DialogResult.OK)
            {
                // Save event to memory
                events[date] = eventForm.EventText;

                // Save to file permanently
                SaveEvents();

                // Confirmation message
                MessageBox.Show(
                    $"Event added for {date.ToShortDateString()}:\n{eventForm.EventText}",
                    "Event Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                // Refresh calendar display
                DisplayDays(month, year);
            }
        }



        // Next and Previous Buttons


        // Go to the next month
        private void btnNext_Click(object sender, EventArgs e)
        {
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
            DisplayDays(month, year);
        }

        // Go to the previous month
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            month--;
            if (month < 1)
            {
                month = 12;
                year--;
            }
            DisplayDays(month, year);
        }

        // Go Button - Jump to Specific Month and Year

        private void btnGo_Click(object sender, EventArgs e)
        {
            try
            {
                int inputMonth;
                int inputYear;

                string monthText = txtMonth.Text.Trim();
                string yearText = txtYear.Text.Trim();

                // Accept either number (1–12) or full month name
                if (int.TryParse(monthText, out int m))
                    inputMonth = Math.Max(1, Math.Min(12, m));
                else
                    inputMonth = DateTime.ParseExact(monthText, "MMMM", CultureInfo.CurrentCulture).Month;

                // Validate year input
                if (!int.TryParse(yearText, out inputYear))
                    throw new Exception("Invalid year");

                // Update and display chosen month/year
                month = inputMonth;
                year = inputYear;

                DisplayDays(month, year);
            }
            catch
            {
                // Show error message for invalid input
                MessageBox.Show(
                    "Please enter a valid month (1–12 or name) and year (e.g. 2024).",
                    "Invalid Input",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
    }
}
