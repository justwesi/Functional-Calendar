using System;
using System.Windows.Forms;

namespace grp2Calendar
{
    public partial class EventForm : Form
    {
        /// Stores the event text entered by the user.
        public string EventText { get; private set; }

        /// Holds the date for which the event is being added.
        public DateTime SelectedDate { get; private set; }

        /// Initializes the Event Form with the selected date.
        public EventForm(DateTime date)
        {
            InitializeComponent();

            // Save selected date and display it in readable format
            SelectedDate = date;
            lblDate.Text = date.ToLongDateString();
        }

        // BUTTON: SAVE EVENT
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Get and trim user input
            EventText = txtEvent.Text.Trim();

            // Validate input (ensure user typed something)
            if (string.IsNullOrEmpty(EventText))
            {
                MessageBox.Show(
                    "Please enter an event description.",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Mark dialog as successful and close
            DialogResult = DialogResult.OK;
            Close();
        }

        // BUTTON: CANCEL EVENT
        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the form without saving
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
