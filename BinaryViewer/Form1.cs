using System.Runtime.InteropServices;
using System.Threading;

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
            string fileName = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.ShowDialog();

                fileName = openFileDialog.FileName;
            }

            filePath_textBox.Text = fileName;
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


            long position = BinaryViewer.GetOffsetPosition(offset, result_textBox.Text.Split('\n'));
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

        private void read_button_Click(object sender, EventArgs e)
        {
            if (!File.Exists(filePath_textBox.Text))
            {
                MessageBox.Show("Файл не найден");
                return;
            }

            long begin_offset = -1;
            long end_offset = -1;

            using (ReadSettings readSettings = new ReadSettings(filePath_textBox.Text))
            {
                readSettings.ShowDialog();

                if (readSettings.DialogResult == DialogResult.OK)
                {
                    begin_offset = readSettings.BeginOffset;
                    end_offset = readSettings.EndOffset;
                    //BinaryViewer.Read(filePath_textBox.Text, begin_offset, end_offset, ref result_textBox);
                    BinaryViewer.TargetTextBox = result_textBox;
                    BinaryViewer.BeginOffset = begin_offset;
                    BinaryViewer.EndOffset = end_offset;
                    BinaryViewer.Source = filePath_textBox.Text;

                    BinaryViewer.Read();
                    //Thread thread = new Thread(BinaryViewer.Test);
                    //thread.Start();
                }

            }
        }

        private void save_button_Click(object sender, EventArgs e)
        {
            if (result_textBox.Text == "")
            {
                MessageBox.Show("Нечего сохранять");
                return;
            }

            string saveFile = "";

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.ShowDialog();
                saveFile = openFileDialog.FileName;
            }

            if (!File.Exists(saveFile))
                return;

            StreamWriter sr = new StreamWriter(saveFile);
            string s = result_textBox.Text;
            sr.Write(s);
            sr.Close();
            sr.Dispose();
        }
    }
}