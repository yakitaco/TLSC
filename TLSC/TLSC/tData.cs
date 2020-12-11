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
            tList.Add(new tData("test", 0x00, Color.FromArgb(200, 200, 200)));
            tList.Add(new tData("test", 0x01, Color.FromArgb(100, 200, 200)));
            tList.Add(new tData("test", 0x02, Color.FromArgb(200, 200, 100)));
        }

        public tData(String _name, int _id, Color _c) {
            name = _name;
            id = _id;
            c = _c;
        }
    }
}
