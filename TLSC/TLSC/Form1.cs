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
        // タイルマップ
        sData sD;
        // ユニットマップ

        public Form1() {
            InitializeComponent();
            sD = new sData((int)X_num.Value, (int)Y_num.Value);
            makeCellPanel((int)X_num.Value, (int)Y_num.Value);
            //makeList(0);
            comboBox1.SelectedIndex = 0;
        }

        // リスト作成( 0:タイル / 1: ユニット )
        void makeList(int type) {
            //フォーメーション一覧作成
            listBox1.Items.Clear();
            if (type == 0) {
                foreach (tData cd in tData.tList) {
                    //listBox1.Items.Add(cd.name);
                    listBox1.Items.Add(String.Format("{0:X2} : {1}", cd.id, cd.name));
                }
            } else if (type == 1) {
                foreach (uData ud in uData.uList) {
                    //listBox1.Items.Add(ud.name);
                    if (ud.id > -1) {
                        listBox1.Items.Add(String.Format("{0:X2} : {1}", ud.id, ud.name));
                    } else {
                        listBox1.Items.Add(String.Format("NONE"));
                    }
                }
            }
            listBox1.SelectedIndex = 0;
        }

        void makeCellPanel(int x, int y) {
            //過去のセルを全クリア
            while (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.RemoveAt(0);

            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    Label tmpLabel = new Label();
                    tmpLabel.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    tmpLabel.Margin = new System.Windows.Forms.Padding(3);
                    tmpLabel.Name = $"C{i:D2}_{j:D2}";
                    tmpLabel.Size = new System.Drawing.Size(40, 40);
                    tmpLabel.TabIndex = 0;
                    if (sD.uMap[i, j] < 0) {
                        tmpLabel.Text = String.Format("-- {0:X2}", sD.tMap[i, j]);
                    } else {
                        tmpLabel.Text = String.Format("{0:X2} {1:X2}", sD.uMap[i, j], sD.tMap[i, j]);
                    }
                    tmpLabel.BackColor = tData.tList.FirstOrDefault(name => name.id == sD.tMap[i, j]).c;
                    tmpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                    tmpLabel.Margin = new Padding(1);
                    tmpLabel.Padding = new Padding(1, 1, 1, 1);
                    tmpLabel.Visible = true;
                    tmpLabel.MouseDown += new MouseEventHandler(CellClick);
                    tmpLabel.MouseEnter += new EventHandler(mouseEnter);
                    this.flowLayoutPanel1.Controls.Add(tmpLabel);

                    if (j == y - 1) this.flowLayoutPanel1.SetFlowBreak(tmpLabel, true);
                }
            }
            //sD = new sData((int)X_num.Value, (int)Y_num.Value);
        }

        void CellClick(object sender, System.Windows.Forms.MouseEventArgs e) {
            int x = int.Parse(((Label)sender).Name.Substring(1, 2));
            int y = int.Parse(((Label)sender).Name.Substring(4, 2));
            if (comboBox1.SelectedIndex == 0) {
                ((Label)sender).BackColor = tData.tList[listBox1.SelectedIndex].c;
                sD.tMap[x, y] = tData.tList[listBox1.SelectedIndex].id;
            } else if (comboBox1.SelectedIndex == 1) {
                //((Label)sender).BackColor = tData.uList[listBox1.SelectedIndex].c;
                sD.uMap[x, y] = uData.uList[listBox1.SelectedIndex].id;
            }
            if (sD.uMap[x, y] < 0) {
                ((Label)sender).Text = String.Format("-- {0:X2}", sD.tMap[x, y]);
            } else {
                ((Label)sender).Text = String.Format("{0:X2} {1:X2}", sD.uMap[x, y], sD.tMap[x, y]);
            }
            
        }

        void mouseEnter(object sender, EventArgs e) {
            this.Text = "Trick Labyrinth Stage Creater (" + ((Label)sender).Name + ")";
        }

        private void button3_Click(object sender, EventArgs e) {
            //メッセージボックスを表示する
            DialogResult result = MessageBox.Show("マップサイズを変更しますか？",
                "マップサイズ",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            //何が選択されたか調べる
            if (result == DialogResult.Yes) {
                //「はい」が選択された時
                //Console.WriteLine("「はい」が選択されました");
                //while (flowLayoutPanel1.Controls.Count > 0) flowLayoutPanel1.Controls.RemoveAt(0);
                sD = new sData((int)X_num.Value, (int)Y_num.Value);
                makeCellPanel((int)X_num.Value, (int)Y_num.Value);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            makeList(comboBox1.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e) {
            sData loadedData = sData.load();
            if(loadedData != null) {
                sD = loadedData;
                makeCellPanel(sD.x, sD.y);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            sD.save();
        }

        private void button4_Click(object sender, EventArgs e) {
            bool ret = gForm.ShowMiniForm(ref sD);　//Form2を開く
        }
    }

}
