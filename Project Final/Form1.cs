using System.Windows.Forms;
using OfficeOpenXml;

namespace Project_Final
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            this.comboBox1.Items.Add("1");
            this.comboBox1.Items.Add("2");
            this.comboBox1.Items.Add("3");
            this.comboBox1.Items.Add("4");

            this.comboBox2.Items.Add("Red");
            this.comboBox2.Items.Add("Black");
            this.comboBox2.Items.Add("White");

            read_excel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var battery = this.comboBox1.SelectedItem.ToString();
            var quantity = this.textBox1.Text;
            Camera newCamera = new Camera("Canon R8", "15000", quantity, battery);
            var message = $"คุณสั่งชื้อ {newCamera.getName()} ราคา {(Int32.Parse(newCamera.getPrice()) * Int32.Parse(newCamera.getQuantity()))} {newCamera.getQuantity()} ชิ้น \nขนาด battery {newCamera.getBattery()}";
            MessageBox.Show(message);
            save_to_excel(message);
            this.dataGridView1.Rows.Add(message);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var color = this.comboBox2.SelectedItem.ToString();
            var quantity = this.textBox5.Text;
            Drone newDrone = new Drone("DJI M3C", "20000",quantity, color);
            var message = $"คุณสั่งชื้อ {newDrone.getName()} ราคา {(Int32.Parse(newDrone.getPrice()) * Int32.Parse(newDrone.getQuantity()))} {newDrone.getQuantity()} ชิ้น \n สี {newDrone.getColor()}";
            MessageBox.Show(message);
            save_to_excel(message);
            this.dataGridView1.Rows.Add(message);
        }

        private void save_to_excel(string message)
        {
            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            using (var package = new ExcelPackage(new FileInfo(@"C:\Users\lenovo\Desktop\Project-coed-main\Project Final\output.xlsx.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                if (worksheet == null)
                {
                    throw new Exception("Worksheet does not exist");
                }
                int lastUsedRow = worksheet.Dimension.End.Row;

                ExcelRange cell = worksheet.Cells[lastUsedRow + 1, 1];
                cell.Value = message;

                package.Save();
            }
        }

        private void read_excel()
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.Commercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(@"C:\Users\lenovo\Desktop\Project-coed-main\Project Final\output.xlsx.xlsx")))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets["Sheet1"];
                int lastUsedRow = worksheet.Dimension.End.Row;
                for (int row = 1; row <= lastUsedRow; row++)
                {
                    string value = worksheet.Cells[row, 1].Value?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        this.dataGridView1.Rows.Add(value);
                    }
                }
            }
        }
    }
}