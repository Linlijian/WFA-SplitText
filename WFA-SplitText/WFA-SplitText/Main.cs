using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA_SplitText
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }

        private void btnplit_Click(object sender, EventArgs e)
        {
            if(rbtnQueryText.Checked == true)
            {
                bool first = true;
                string txt = txt_from.Text;
                string[] txtas = null;
                string[] after = null;

                txtas = txt.Replace("\r\n", "").Replace(",", "").Split(null);
                after = Array.FindAll(txtas, element => element.StartsWith("@", StringComparison.Ordinal));
                if (ckbAtSign.Checked == true)
                {
                    foreach (var intem in after)
                    {
                        if (first)
                        {
                            txt_to.Text = intem + "\r\n";
                            first = false;
                        }
                        else
                        {
                            txt_to.Text += intem + "\r\n";
                        }
                    }
                }
                else
                {
                    foreach (var intem in after)
                    {
                        if (first)
                        {
                            txt_to.Text = intem.Replace("@", "") + "\r\n";
                            first = false;
                        }
                        else
                        {
                            txt_to.Text += intem.Replace("@", "") + "\r\n";
                        }
                    }
                }

                

            }
            else
            {
                MessageBox.Show("please check option", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
