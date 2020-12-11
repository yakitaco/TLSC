using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLSC {
    class uData {
        public static List<uData> uList = new List<uData>(); //タイルデータのテンプレートリスト
        public String name;
        public int id;

        static uData() {
            uList.Add(new uData("None",    -1));
            uList.Add(new uData("Unit1", 0x00));
            uList.Add(new uData("Unit2", 0x01));
            uList.Add(new uData("Unit3", 0x02));
        }

        public uData(String _name, int _id) {
            name = _name;
            id = _id;
        }

    }
}
