using AdhanyDesktop.Model;

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

            res_location.Text = ddl_country.SelectedItem.ToString() + ", " + ddl_city.SelectedItem.ToString();
            var selectedMethod = (CalculationMethod)ddl_method.SelectedItem;

            res_date.Text = selectedMethod.id.ToString();

            statusLabel.Text = "Done";
            MessageBox.Show("data fetched successfully!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var methods = new List<CalculationMethod>();

            // Create method objects and add them to the methods list
            foreach (var kvp in CalculationMethod.methodDictionary)
            {
                methods.Add(new CalculationMethod { id = kvp.Key, name = kvp.Value });
            }

            // Bind the list to the combo box
            ddl_method.DataSource = methods;
            ddl_method.DisplayMember = "name";
            ddl_method.ValueMember = "id";
        }
    }
}