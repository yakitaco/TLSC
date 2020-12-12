using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLSC {
    //タイルデータ
    class tData {
        public static List<tData> tList = new List<tData>(); //タイルデータのテンプレートリスト
        public String name;
        public int id;
        public Color c;
        
        static tData(){
            tList.Add(new tData("通路", 0x00, Color.FromArgb(200, 250, 250)));
            tList.Add(new tData("壁"  , 0x01, Color.FromArgb(200, 200, 100)));
            tList.Add(new tData("test", 0x02, Color.FromArgb(100, 100, 100)));
        }

        public tData(String _name, int _id, Color _c) {
            name = _name;
            id = _id;
            c = _c;
        }
    }
}
