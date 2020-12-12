using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLSC {
    public partial class gForm : Form {

        sData sD;              //Form1から受け取った引数
        public bool ReturnValue = false;   //Form1に返す戻り値

        public gForm(params sData[] argumentValues) {
            sD = argumentValues[0];
            InitializeComponent();
            numericUpDown1.Value = sD.star3;
            numericUpDown2.Value = sD.star2;
            comboBox1.SelectedIndex = sD.goalType;
            numericUpDown3.Value = sD.goalDetail;


        }

        static public bool ShowMiniForm(ref sData s) {
            gForm f = new gForm(s);
            f.ShowDialog();
            f.Dispose();

            return f.ReturnValue;
        }

        private void button1_Click(object sender, EventArgs e) {
            sD.star3 = (int)numericUpDown1.Value;
            sD.star2 = (int)numericUpDown2.Value;
            sD.goalType = comboBox1.SelectedIndex;
            sD.goalDetail = (int)numericUpDown3.Value;

            ReturnValue = true;
            this.Close();

        }
    }
}
