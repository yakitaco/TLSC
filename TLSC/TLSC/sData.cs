using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TLSC {
    // ステージデータ
    public class sData {
        static byte[] magic = { 0xA5, 0xF9 };
        static byte version = 0x01;

        public int x;
        public int y;
        // タイルマップ
        public int[,] tMap;
        // ユニットマップ
        public int[,] uMap;

        public int star3;
        public int star2;

        // ゴール情報
        public int goalType;
        public int goalDetail;

        public sData(int _x, int _y) {
            x = _x;
            y = _y;
            tMap = new int[x, y];
            uMap = new int[x, y];
            for (int i = 0; i < x; i++) {
                for (int j = 0; j < y; j++) {
                    uMap[i, j] = -1;
                }
            }
        }

        //ファイルへ保存
        public bool save() {
            //保存先を指定するダイアログを開く
            System.IO.Directory.CreateDirectory(@"Userdata");
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ステージデータ(*.sdt)|*.sdt" + "|All Files|*.*";
            //sfd.InitialDirectory = Directory.GetCurrentDirectory() + @"\Userdata";
            sfd.FileName = "dat" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "_" + DateTime.Now.Hour + DateTime.Now.Minute + DateTime.Now.Second + ".sdt";
            if (sfd.ShowDialog() == DialogResult.OK) {
                byte[] data = new byte[4096];
                data[0] = magic[0];
                data[1] = magic[1];
                data[2] = version;
                data[4] = (byte)(star3 / 256);
                data[5] = (byte)(star3 % 256);
                data[6] = (byte)(star2 / 256);
                data[7] = (byte)(star2 % 256);
                data[8] = (byte)x;
                data[9] = (byte)y;

                int cnt = 10;
                // タイル情報登録
                for (int i = 0; i < x; i++) {
                    for (int j = 0; j < y; j++) {
                        data[cnt] = (byte)tMap[i, j];
                        cnt++;
                    }
                }

                // ユニット情報
                //int unitNum = data[cnt];
                int uIdx = cnt; // ユニット数格納インデックス
                cnt++;
                int uNum = 0; // ユニット数
                for (int i = 0; i < x; i++) {
                    for (int j = 0; j < y; j++) {
                        if (uMap[i,j] > -1) {
                            data[cnt] = (byte)i;
                            data[cnt + 1] = (byte)j;
                            data[cnt + 2] = (byte)uMap[i, j];
                            cnt += 4;
                            uNum++;
                        }
                    }
                }
                data[uIdx] = (byte)uNum;

                // ゴール条件
                data[cnt] = (byte)goalType;
                cnt++;
                data[cnt] = (byte)goalDetail;
                cnt++;

                //ファイルを作成して書き込む
                //バイト型配列の内容をすべて書き込む
                Stream fileStream = sfd.OpenFile();
                fileStream.Write(data, 0, cnt);
                //閉じる
                fileStream.Close();
            }
            return true;
        }

        //ファイルから読み取り
        public static sData load() {
            //開くファイルを選択するダイアログを開く
            sData loadedData = null;
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ステージデータ(*.sdt)|*.sdt" + "|All Files|*.*";
            //ofd.InitialDirectory = Directory.GetCurrentDirectory() + @"\Userdata";
            if (ofd.ShowDialog() == DialogResult.OK) {
                //ファイルをバイナリ読込
                Stream fileStream = ofd.OpenFile();
                byte[] data = new byte[fileStream.Length];
                fileStream.Read(data, 0, data.Length);

                // マジックチェック
                if (magic.SequenceEqual(data.Take(2).ToArray())) {
                    // バージョンチェック
                    if (version == data[2]) {
                        loadedData = new sData(data[8], data[9]);
                        loadedData.star3 = data[4] * 255 + data[5];
                        loadedData.star2 = data[6] * 255 + data[7];

                        int cnt = 10;
                        // タイル情報登録
                        for (int i = 0; i < loadedData.x; i++) {
                            for (int j = 0; j < loadedData.y; j++) {
                                loadedData.tMap[i, j] = data[cnt];
                                cnt++;
                            }
                        }

                        // ユニット情報
                        int unitNum = data[cnt];
                        cnt++;
                        for (int i = 0; i < unitNum; i++) {
                            loadedData.uMap[data[cnt], data[cnt + 1]] = data[cnt + 2];
                            //unitObj.addUnit("test_" + i, (uType)Enum.ToObject(typeof(uType), loadData[cnt + 2]), new Vector2Int(loadData[cnt], loadData[cnt + 1]));
                            cnt += 4;
                        }

                        // ゴール条件
                        loadedData.goalType = data[cnt];
                        cnt++;
                        loadedData.goalDetail = data[cnt];


                    } else {
                        MessageBox.Show("ファイルバージョンが違います。", "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("ファイルフォーマットが違います。", "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                }

            }
            return loadedData;
        }


    }
}
