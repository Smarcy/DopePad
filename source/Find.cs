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
        int findPos = 0;

        string word = string.Empty;

        //---------------------------------------------Code for communication between Forms!------------------------
        private Form1 mainForm = null;
        public Find(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }
        //---------------------------------------------Code for communication between Forms!------------------------

        private void btnFindNext_Click(object sender, EventArgs e)
        {
            word = txtFind.Text;

            findPos = mainForm.rtbMainText.Find(word, findPos + 1, RichTextBoxFinds.None);
            if (search != -1)
            {
                //mainForm.rtbMainText.Select(findPos, word.Length);
               // findPos += findPos + word.Length;
                mainForm.Focus();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            word = txtFind.Text;

            findPos = mainForm.rtbMainText.Find(word);
            if (search != -1)
            {
                mainForm.Focus();
            }
        }
    }
}
