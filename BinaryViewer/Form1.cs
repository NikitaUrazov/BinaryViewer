namespace BinaryViewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            result_textBox.Font = new Font(FontFamily.GenericMonospace, result_textBox.Font.Size);
        }

        private void filePath_button_Click(object sender, EventArgs e)
        {
            string file = filePath_textBox.Text;
            if (!File.Exists(file))
            {
                MessageBox.Show("Файл не найден");
                return;
            }
            BinaryViewer.Read(file);
            result_textBox.Text = File.ReadAllText(BinaryViewer.Result);
        }

        private void offset_button_Click(object sender, EventArgs e)
        {
            if (result_textBox.Text == "")
            {
                MessageBox.Show("Файл пуст");
                return;
            }

            if (!Int64.TryParse(offset_textBox.Text, out long offset))
            {
                MessageBox.Show("Некорректный ввод.\nУкажите смещение в десятичной системе счисления.");
                return;
            }

            long position = BinaryViewer.GetOffsetPosition(offset);
            if (position == -1)
            {
                MessageBox.Show("Error");
                return;
            }
            result_textBox.Focus();
            result_textBox.SelectionStart = (int)position;
            result_textBox.SelectionLength = 2;
            result_textBox.ScrollToCaret();
        }
    }
}