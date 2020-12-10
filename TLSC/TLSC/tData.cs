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
        public Color c;
        
        static tData(){
            tList.Add(new tData("test", Color.FromArgb(200, 200, 200)));
            tList.Add(new tData("test", Color.FromArgb(100, 200, 200)));
            tList.Add(new tData("test", Color.FromArgb(200, 200, 100)));
        }

        public tData(String _name, Color _c) {
            name = _name;
            c = _c;
        }
    }
}
