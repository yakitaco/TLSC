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
            uList.Add(new uData("PLAYER", 0x00));
            uList.Add(new uData("S_BLOCK_1X1", 0x10));
            uList.Add(new uData("S_BLOCK_2X1", 0x11));
            uList.Add(new uData("S_BLOCK_3X1", 0x12));
            uList.Add(new uData("S_BLOCK_1X2", 0x13));
            uList.Add(new uData("S_BLOCK_1X3", 0x14));
            uList.Add(new uData("S_BLOCK_2X2", 0x15));
            uList.Add(new uData("S_BLOCK_3X2", 0x16));
            uList.Add(new uData("S_BLOCK_2X3", 0x17));
            uList.Add(new uData("S_BLOCK_3X3", 0x18));
            uList.Add(new uData("G_BLOCK_1X1", 0x20));
            uList.Add(new uData("G_BLOCK_2X1", 0x21));
            uList.Add(new uData("G_BLOCK_3X1", 0x22));
            uList.Add(new uData("G_BLOCK_1X2", 0x23));
            uList.Add(new uData("G_BLOCK_1X3", 0x24));
            uList.Add(new uData("G_BLOCK_2X2", 0x25));
            uList.Add(new uData("G_BLOCK_3X2", 0x26));
            uList.Add(new uData("G_BLOCK_2X3", 0x27));
            uList.Add(new uData("G_BLOCK_3X3", 0x28));

            // 敵
            uList.Add(new uData("E_SLIME", 0xA0));
            uList.Add(new uData("E_FIREBALL", 0xA1));
            uList.Add(new uData("E_BEE", 0xA2));
            uList.Add(new uData("E_SNAKE", 0xA3));
            uList.Add(new uData("E_WOLFMAN", 0xA4));
            uList.Add(new uData("E_TROLL", 0xA5));
            uList.Add(new uData("E_GOBLIN", 0xA6));
            uList.Add(new uData("E_DAEMON", 0xA7));

            // ゴール
            uList.Add(new uData("GOAL"      , 0xF0));
            uList.Add(new uData("CHECKPOINT", 0xF1));
            uList.Add(new uData("ESC_GOAL"  , 0xF2));
            uList.Add(new uData("TEST"      , 0xFF));
        }

        public uData(String _name, int _id) {
            name = _name;
            id = _id;
        }

    }
}
