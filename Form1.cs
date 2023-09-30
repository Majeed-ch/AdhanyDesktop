namespace AdhanyDesktop
{
    public partial class Form1 : Form
    {
        private static Dictionary<int, string> methodDictionary = new Dictionary<int, string>
        {
            {0, "Shia Ithna-Ansari"},
            {1, "University of Islamic Sciences, Karachi"},
            {2, "Islamic Society of North America"},
            {3, "Muslim World League"},
            {4, "Umm Al-Qura University, Makkah"},
            {5, "Egyptian General Authority of Survey"},
            {7, "Institute of Geophysics, University of Tehran"},
            {8, "Gulf Region"},
            {9, "Kuwait"},
            {10, "Qatar"},
            {11, "Majlis Ugama Islam Singapura, Singapore"},
            {12, "Union Organization islamic de France"},
            {13, "Diyanet İşleri Başkanlığı, Turkey"},
            {14, "Spiritual Administration of Muslims of Russia"}
        };

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
            var selectedMethod = (CalculationMethods)ddl_method.SelectedItem;

            res_date.Text = selectedMethod.id.ToString();

            statusLabel.Text = "Done";
            MessageBox.Show("data fetched successfully!");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var methods = new List<CalculationMethods>();


            // Create objects and add them to the methods list
            foreach (var kvp in methodDictionary)
            {
                methods.Add(new CalculationMethods { id = kvp.Key, name = kvp.Value });
            }

            // Bind the list to the combo box
            ddl_method.DataSource = methods;
            ddl_method.DisplayMember = "name";
            ddl_method.ValueMember = "id";
        }

        public class CalculationMethods
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    }
}