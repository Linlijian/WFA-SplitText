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

        #region Method
        private SplitModel SetDefualtData(SplitModel model, string mode)
        {
           if(mode == "QueryText")
            {
                model.FirstLoop = true;
                model.StringText = txt_from.Text;
                model.TextArea = model.StringText.Replace("\r\n", "").Replace(",", "").Split(null);
                model.TextFindAll = Array.FindAll(model.TextArea, element => element.StartsWith("@", StringComparison.Ordinal));
            }
            else if (mode == "AddParameter")
            {
               if(ckbNomal.Checked == true)
                {
                    model.FirstLoop = true;
                    model.StringText = txt_from.Text;
                    model.TextArea = model.StringText.Replace("\r\n", " ").Split(null);
                    model.TextFindAll = model.TextArea;
                }
                else
                {
                    model.FirstLoop = true;
                    model.StringText = txt_from.Text;
                    model.TextArea = model.StringText.Replace("\r\n", "").Replace(",", "").Replace("[", "").Replace("]", "").Split(null);
                    model.TextFindAll = model.TextArea.Where(a => !a.IsNullOrEmpty()).ToArray();
                }
            }

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
                MessageBox.Show("Check input text in format querytext or null", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void FetchData2AddParameter(SplitModel model)
        {
            try
            {
                string last = model.TextFindAll.Last();

                foreach (var intem in model.TextFindAll)
                {
                    if (model.FirstLoop)
                    {
                        txt_to.Text = CaseOutput(intem, 119);
                        model.FirstLoop = false;
                    }
                    else
                    {
                        if(!intem.IsNullOrEmpty())
                            txt_to.Text += CaseOutput(intem, 119);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check input text in format querytext or null", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string CaseOutput(string txt, int intCase)
        {
            string t = string.Empty;
            string r = string.Empty;

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
            else if (intCase == 119) // AddParameter
            {
                t = "parameters.AddParameter(\"" + txt + "\"" +", dto.Model." + txt + ");" + "\r\n";
            }

            return t;
        }
        private void DeleteLastComma()
        {
            string t = txt_to.Text;
            txt_to.Text = t.Substring(0, t.Length - 3);
        }
        #endregion

        private void Main_Load(object sender, EventArgs e)
        {
            ckbDelLastComma.Enabled = false;
            txt_to.Enabled = false;
        }

        private void btnplit_Click(object sender, EventArgs e)
        {
            var model = new SplitModel();            

            if (rbtnQueryText.Checked == true)
            {
                SetDefualtData(model, "QueryText");
                FetchData2Output(model);
            }
            else if(rbtnAddParameter.Checked == true)
            {
                SetDefualtData(model, "AddParameter");
                FetchData2AddParameter(model);
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
        private void rbtnAddParameter_CheckedChanged(object sender, EventArgs e)
        {
            ckbAtSign.Enabled = false;
            ckbComma.Enabled = false;
            ckbDelLastComma.Enabled = false;

            ckbAtSign.Checked = false;
            ckbComma.Checked = false;
            ckbDelLastComma.Checked = false;
        }

        private void rbtnQueryText_CheckedChanged(object sender, EventArgs e)
        {
            ckbAtSign.Enabled = true;
            ckbComma.Enabled = true;

            if (rbtnQueryText.Checked == true)
            {
                ckbFromDB.Checked = false;
                ckbNomal.Checked = false;
                ckbFromDB.Enabled = false;
                ckbNomal.Enabled = false;
            }
            else
            {
                ckbFromDB.Enabled = true;
                ckbNomal.Enabled = true;
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            txt_from.Text = Clipboard.GetText();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txt_from.Clear();
        }

        private void ckbNomal_CheckedChanged(object sender, EventArgs e)
        {           
            if(ckbNomal.Checked == true)
            {
                ckbFromDB.Enabled = false;
                ckbFromDB.Checked = false;
            }
            else
            {
                ckbFromDB.Enabled = true;
            }
        }

        private void ckbFromDB_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbFromDB.Checked == true)
            {
                ckbNomal.Enabled = false;
                ckbNomal.Checked = false;
            }
            else
            {
                ckbNomal.Enabled = true;
            }
        }
    }
}
