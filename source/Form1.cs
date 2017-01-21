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

        private bool _isChanged = false;
        private string fileName = string.Empty;

        public string TextField
        {
            get { return rtbMainText.Text; }
            set { rtbMainText.Text = value; }
        }

        FontDialog fontDialog = new FontDialog();
        Base64 base64 = new Base64();
        DopeCrypt dopecrypt = new DopeCrypt();


        public Form1()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_isChanged)
            {
                DialogResult tmpResult = MessageBox.Show("Document has changed, wanna save?", "Don't get lost!",
                                          MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);

                if (tmpResult == DialogResult.Yes)
                {
                    _isChanged = saveOrNew();
                }
                else if (tmpResult == DialogResult.No)
                {
                    rtbMainText.Text = string.Empty;
                    _isChanged = false;
                    this.Text = "DopePad - © by Smarc";
                }
            } 
            else
            {
                rtbMainText.Text = string.Empty;
                _isChanged = false;
                this.Text = "DopePad - © by Smarc";
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Text files (*.txt)|*.txt";

                DialogResult dres = openFileDialog1.ShowDialog();

                if (dres == DialogResult.OK)
                {
                    using (StreamReader stream = new StreamReader(openFileDialog1.OpenFile()))
                    {
                        rtbMainText.Text = stream.ReadToEnd();
                        stream.Close();
                    }

                    this.Text = "DopePad - © by Smarc - " + openFileDialog1.FileName;
                    fileName = openFileDialog1.FileName;
                }
                else
                    return;
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Text files (*.txt) | *.txt";
                DialogResult dres = saveDialog.ShowDialog();

                if (dres == DialogResult.OK)
                {
                    rtbMainText.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);
                    _isChanged = false;
                }
                else
                    return;
            }
            
        }

        private bool saveOrNew()
        {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Text files (*.txt) | *.txt";
                        saveDialog.ShowDialog();
                try
                {
                    rtbMainText.SaveFile(saveDialog.FileName, RichTextBoxStreamType.PlainText);

                    rtbMainText.Text = string.Empty;
                    return false;
                }
                catch { }
                return true;
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
                _isChanged = false;
            }
            else
                saveOrNew();
        }

        private void rtbMainText_TextChanged_1(object sender, EventArgs e)
        {
            _isChanged = true;
        }

        private void rOT13ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ROT13 rot13 = new ROT13();

            rtbMainText.Text = rot13.ROT13_encrypt(rtbMainText.Text);
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMainText.Undo();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find frm = new Find(this);
            frm.Show();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {          
            fontDialog.ShowDialog();
            rtbMainText.Font = fontDialog.Font;
        }

        private void Menu_Base64_Encrypt_Click(object sender, EventArgs e)
        {
            rtbMainText.Text = base64.Base64Encrypt(rtbMainText.Text);
        }

        private void Menu_Base64_Decrypt_Click(object sender, EventArgs e)
        {
            try
            {
                rtbMainText.Text = base64.Base64Decrypt(rtbMainText.Text);
            }
            catch
            {
                MessageBox.Show("Kein gültiger BASE64 String!");
            }
        }

        private void encryptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMainText.Text = dopecrypt.Dope_encrypt(rtbMainText.Text);
        }

        private void decryptToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            rtbMainText.Text = dopecrypt.Dope_decrypt(rtbMainText.Text);
        }

        private void aboutDopePadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
