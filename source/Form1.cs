using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Engine;

namespace DopePad
{
    public partial class Form1 : Form
    {

        private bool isChanged = false;
        private string fileName = string.Empty;

               

        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isChanged = saveOrNew();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.ShowDialog();
                

                using (StreamReader stream = new StreamReader(openFileDialog1.OpenFile()))
                {
                    rtbMainText.Text = stream.ReadToEnd();
                    stream.Close();
                }

                this.Text = "DopePad - © by Smarc - " + openFileDialog1.FileName;
                fileName = openFileDialog1.FileName;
            }
                



        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using(SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.ShowDialog();
                saveDialog.OpenFile();

                StreamWriter stream = new StreamWriter(saveDialog.FileName);
                stream.Close();
            }
            
        }

        private bool saveOrNew()
        {
            if (!isChanged)
            {
                rtbMainText.Text = string.Empty;
                return false;
            }
            else
            {
                DialogResult tmpResult = MessageBox.Show("Document has changed, wanna save?", "Don't get lost!",
                                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (tmpResult == DialogResult.Yes)
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.ShowDialog();
                        rtbMainText.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);

                        rtbMainText.Text = string.Empty;
                        return false;
                    }
                }
                else if (tmpResult == DialogResult.No)
                {
                    rtbMainText.Text = string.Empty;
                    return false;
                }
                return false;
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();           
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text != "DopePad - © by Smarc")
            {
                rtbMainText.SaveFile(fileName, RichTextBoxStreamType.PlainText);
            }
            else
                saveOrNew();
        }

        private void rtbMainText_TextChanged_1(object sender, EventArgs e)
        {
            isChanged = true;
        }

        private void rOT13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ROT13 rot13 = new ROT13();

            rtbMainText.Text = rot13.ROT13_encrypt(rtbMainText.Text);
        }
    }
}
