namespace AdhanyDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            statusProgressBar.Value = 0;
            table_fetchedData.Visible = false;
            statusLabel.Text = "Fetching Data...";

            table_fetchedData.Visible = true;
            for (int i = 0; i < 10; i++)
            {
                System.Threading.Thread.Sleep(100);
                statusProgressBar.Value += 10;
            }
            statusLabel.Text = "Done";
            MessageBox.Show("data fetched successfully!");
        }
    }
}