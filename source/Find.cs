using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DopePad
{
    public partial class Find : Form
    {
        int search = 0;
        int start = 0;

        string word = string.Empty;

        //---------------------------------------------Code for communication between Forms!------------------------
        private Form1 mainForm = null;
        public Find(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        //---------------------------------------------Code for communication between Forms!------------------------

        private void btnFind_Click(object sender, EventArgs e)
        {
            word = txtFind.Text;

            search = mainForm.rtbMainText.Find(word, start, RichTextBoxFinds.None);
            if (search != -1)
            {
                start += search + word.Length;
                mainForm.Focus();
            }
        }
    }
}
