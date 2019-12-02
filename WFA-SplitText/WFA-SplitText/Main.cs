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
            ckbDelLastComma.Enabled = false;
        }

        private void btnplit_Click(object sender, EventArgs e)
        {
            var model = new SplitModel();
            SetDefualtData(model);

            if (rbtnQueryText.Checked == true)
            {
                FetchData2Output(model);
            }
            else
            {
                MessageBox.Show("please check option", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void ckbComma_CheckedChanged(object sender, EventArgs e)
        {
            if(ckbComma.Checked == true)
            {
                ckbDelLastComma.Enabled = true;
            }
            else
            {
                ckbDelLastComma.Enabled = false;
                ckbDelLastComma.Checked = false;
            }
        }
        private void btncopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txt_to.Text);
        }

        private SplitModel SetDefualtData(SplitModel model)
        {
            model.FirstLoop = true;
            model.StringText = txt_from.Text;
            model.TextArea = model.StringText.Replace("\r\n", "").Replace(",", "").Split(null);
            model.TextFindAll = Array.FindAll(model.TextArea, element => element.StartsWith("@", StringComparison.Ordinal));

            return model;
        }
        private void FetchData2Output(SplitModel model)
        {
            try
            {
                int a = ckbAtSign.Checked ? 112 : 0;
                a += ckbComma.Checked ? 113 : 0;
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txt_to.Text = CaseOutput(intem, a);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        txt_to.Text += CaseOutput(intem, a);
                    }

                    if (last.Equals(intem) && ckbDelLastComma.Checked)
                    {
                        DeleteLastComma();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + " \r\nFix: Check input text in format querytext or null", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CaseOutput(string txt, int intCase)
        {
            string t = string.Empty;
            string r = string.Empty;
            char c;
            int a = txt.Length;
            if (intCase == 112) //AtSign
            {
                t = txt + "\r\n";
            }
            else if (intCase == 0) // default
            {
                t = txt.Replace("@", "") + "\r\n";
            }
            else if (intCase == 113) // comma
            {
                t = txt.Replace("@", "") + ',' + "\r\n";
            }
            else if (intCase == 225) // comma + AtSign
            {
                //c = txt[txt.Length - 1];
                t = txt + ',' + "\r\n";
            }

            return t;
        }
        private void DeleteLastComma()
        {
            string t = txt_to.Text;
            txt_to.Text = t.Substring(0, t.Length - 3);
        }
    }
}
