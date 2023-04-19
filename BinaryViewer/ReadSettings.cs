using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryViewer
{
    public partial class ReadSettings : Form
    {
        private string fileToRead;
        private long beginOffset;
        public long BeginOffset { get { return beginOffset; } }
        private long endOffset;
        public long EndOffset { get { return endOffset; } }
        private long fileLength;

        public ReadSettings(string filetoRead)
        {
            this.fileToRead = filetoRead;
            FileStream fs = new FileStream(fileToRead, FileMode.Open, FileAccess.Read);
            fileLength = fs.Length;
            fs.Close();
            fs.Dispose();
            InitializeComponent();
        }

        private void from0_button_Click(object sender, EventArgs e)
        {
            beginOffset_textbox.Text = "0";
        }

        private void toEnd_button_Click(object sender, EventArgs e)
        {
            long value = fileLength - 1;
            endOffset_textbox.Text = value.ToString();
        }

        private void accept_button_Click(object sender, EventArgs e)
        {
            if (!Int64.TryParse(beginOffset_textbox.Text, out beginOffset) || !Int64.TryParse(endOffset_textbox.Text, out endOffset))
            {
                MessageBox.Show("Error");
                return;
            }

            if (!IsOffsetValid(beginOffset) || !IsOffsetValid(endOffset))
            {
                MessageBox.Show("Значение за пределами");
                return;
            }

            if (endOffset < beginOffset)
            {
                MessageBox.Show("Error");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private bool IsOffsetValid(long offset)
        {
            if (offset >= 0 && offset < fileLength)
                return true;
            else
                return false;
        }
    }
}
