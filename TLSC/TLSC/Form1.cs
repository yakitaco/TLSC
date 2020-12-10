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
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            makeCellPanel();

            //フォーメーション一覧作成
            foreach (tData cd in tData.tList) {
                listBox1.Items.Add(cd.name);
            }
            listBox1.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        void makeCellPanel() {
            //int x = 10; int y = 10;
            for (int i = 0; i < X_num.Value; i++) {
                for (int j = 0; j < Y_num.Value; j++) {
                    Label tmpLabel = new Label();
                    tmpLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    tmpLabel.Margin = new System.Windows.Forms.Padding(3);
                    tmpLabel.Name = $"C{i:D2}_{j:D2}";
                    tmpLabel.Size = new System.Drawing.Size(40, 40);
                    tmpLabel.TabIndex = 0;
                    tmpLabel.Text = $"00001\n00001";
                    tmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    tmpLabel.Margin = new Padding(1);
                    tmpLabel.Padding = new Padding(1, 1, 1, 1);
                    tmpLabel.Visible = true;
                    tmpLabel.MouseDown += new MouseEventHandler(CellClick);
                    this.flowLayoutPanel1.Controls.Add(tmpLabel);

                    if (j == Y_num.Value - 1) this.flowLayoutPanel1.SetFlowBreak(tmpLabel, true);
                }
            }
        }

        void CellClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            ((Label)sender).BackColor = tData.tList[listBox1.SelectedIndex].c;
        }

        private void button3_Click(object sender, EventArgs e) {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("ファイルを上書きしますか？",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            //何が選択されたか調べる
            if (result == DialogResult.Yes) {
                //「はい」が選択された時
                Console.WriteLine("「はい」が選択されました");
                while (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.RemoveAt(0);
                makeCellPanel();
            }
        }
    }

}
