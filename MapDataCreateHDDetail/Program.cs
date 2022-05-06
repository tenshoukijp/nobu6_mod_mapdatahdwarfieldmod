using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace MapDataCreateHDDetail
{
    internal class MapDataCreateHDDetail
    {
        const int PICTURE_WIDTH = 960;
        const int PICTURE_HEIGHT = 576;

        const int iFieldCol = 34;
        const int iFieldRow = 14;

        Image blankImage;
        Image baseCanvas;

        Dictionary<int, int> PicNumberToFieldID;

        public MapDataCreateHDDetail()
        {
            initialize_convert_table();
            CreateBaseCanvas();
        }

        // 画像番号からフィールドのIDを得る
        int GetPictureNumberToFieldID(int picture_number)
        {
            return PicNumberToFieldID[picture_number];
        }

        (int GridX, int GridY) GetFieldIDToXYGridPosition(int field_id)
        {
            int GridY = (int)(field_id / iFieldCol);
            int GridX = field_id % iFieldCol;
            return (GridX, GridY);
        }

        string GetPictureNumberToPictureName(int picture_number, int season_no)
        {
            if (0 <= season_no && season_no <= 3) { 
                string picture_name = String.Format("./images/f_{0:000}_{1}.png", picture_number, season_no);
                return picture_name;
            }
            return null;
        }

        (int X, int Y) GetGridPositionToLayoutPosition(int GridX, int GridY)
        {
            int X = GridX * PICTURE_WIDTH/3 - PICTURE_WIDTH/3 -GridX * 8;
            int Y = GridY * PICTURE_HEIGHT / 3 - PICTURE_HEIGHT / 3;
            return (X, Y);
        }

        Image GetBlankImage()
        {  
            if (blankImage == null) { 
                blankImage = Image.FromFile("images/blank.png");
            }
            return blankImage;
        }

        void CreateBaseCanvas()
        {
            //描画先とするImageオブジェクトを作成する
            Bitmap canvas = new Bitmap(iFieldCol* PICTURE_WIDTH/3, iFieldRow* PICTURE_HEIGHT/3);
            Graphics g = Graphics.FromImage(canvas);

            //画像ファイルを読み込んで、Imageオブジェクトとして取得する
            Image img = GetBlankImage();

            //画像をcanvasの座標(20, 10)の位置に描画する
            g.DrawImage(img, 0, 0, canvas.Width, canvas.Height);
            //Graphicsオブジェクトのリソースを解放する
            g.Dispose();

            baseCanvas = canvas;
        }

        // 季節ナンバー(0=春,1=夏,2=秋,3=冬)
        void PaintOnFieldGrids(int season_no, string filename)
        {
            Image canvas = baseCanvas;
            Graphics g = Graphics.FromImage(canvas);

            for (int ix = PicNumberToFieldID.Count-1; ix >= 0; ix--)
            // for (int ix = 0; ix < PicNumberToFieldID.Count; ix++)
            {
                string picturename = GetPictureNumberToPictureName(ix, season_no);
                int field_id = GetPictureNumberToFieldID(ix);
                var grid_pos = GetFieldIDToXYGridPosition(field_id);
                var pos = GetGridPositionToLayoutPosition(grid_pos.GridX, grid_pos.GridY);
 
                Image img = Image.FromFile(picturename);
                //画像をcanvasの座標(20, 10)の位置に描画する
                g.DrawImage(img, pos.X, pos.Y, PICTURE_WIDTH, PICTURE_HEIGHT);

                img.Dispose();
            }

            //Graphicsオブジェクトのリソースを解放する
            g.Dispose();

            canvas.Save(filename);

        }

        private void initialize_convert_table()
        {
            PicNumberToFieldID = new Dictionary<int, int>();
            PicNumberToFieldID[0] = 37;
            PicNumberToFieldID[1] = 52;
            PicNumberToFieldID[2] = 39;
            PicNumberToFieldID[3] = 40;
            PicNumberToFieldID[4] = 42;
            PicNumberToFieldID[5] = 43;
            PicNumberToFieldID[6] = 51;
            PicNumberToFieldID[7] = 63;
            PicNumberToFieldID[8] = 64;
            PicNumberToFieldID[9] = 66;
            PicNumberToFieldID[10] = 69;
            PicNumberToFieldID[11] = 72;
            PicNumberToFieldID[12] = 74;
            PicNumberToFieldID[13] = 75;
            PicNumberToFieldID[14] = 76;
            PicNumberToFieldID[15] = 84;
            PicNumberToFieldID[16] = 85;
            PicNumberToFieldID[17] = 89;
            PicNumberToFieldID[18] = 94;
            PicNumberToFieldID[19] = 96;
            PicNumberToFieldID[20] = 99;
            PicNumberToFieldID[21] = 71;
            PicNumberToFieldID[22] = 73;
            PicNumberToFieldID[23] = 77;
            PicNumberToFieldID[24] = 78;
            PicNumberToFieldID[25] = 86;
            PicNumberToFieldID[26] = 93;
            PicNumberToFieldID[27] = 95;
            PicNumberToFieldID[28] = 97;
            PicNumberToFieldID[29] = 98;
            PicNumberToFieldID[30] = 100;
            PicNumberToFieldID[31] = 104;
            PicNumberToFieldID[32] = 105;
            PicNumberToFieldID[33] = 106;
            PicNumberToFieldID[34] = 108;
            PicNumberToFieldID[35] = 110;
            PicNumberToFieldID[36] = 112;
            PicNumberToFieldID[37] = 113;
            PicNumberToFieldID[38] = 117;
            PicNumberToFieldID[39] = 118;
            PicNumberToFieldID[40] = 120;
            PicNumberToFieldID[41] = 124;
            PicNumberToFieldID[42] = 103;
            PicNumberToFieldID[43] = 107;
            PicNumberToFieldID[44] = 109;
            PicNumberToFieldID[45] = 111;
            PicNumberToFieldID[46] = 115;
            PicNumberToFieldID[47] = 121;
            PicNumberToFieldID[48] = 123;
            PicNumberToFieldID[49] = 126;
            PicNumberToFieldID[50] = 129;
            PicNumberToFieldID[51] = 130;
            PicNumberToFieldID[52] = 132;
            PicNumberToFieldID[53] = 133;
            PicNumberToFieldID[54] = 138;
            PicNumberToFieldID[55] = 139;
            PicNumberToFieldID[56] = 143;
            PicNumberToFieldID[57] = 146;
            PicNumberToFieldID[58] = 147;
            PicNumberToFieldID[59] = 148;
            PicNumberToFieldID[60] = 149;
            PicNumberToFieldID[61] = 150;
            PicNumberToFieldID[62] = 151;
            PicNumberToFieldID[63] = 156;
            PicNumberToFieldID[64] = 159;
            PicNumberToFieldID[65] = 161;
            PicNumberToFieldID[66] = 162;
            PicNumberToFieldID[67] = 164;
            PicNumberToFieldID[68] = 165;
            PicNumberToFieldID[69] = 166;
            PicNumberToFieldID[70] = 167;
            PicNumberToFieldID[71] = 137;
            PicNumberToFieldID[72] = 140;
            PicNumberToFieldID[73] = 141;
            PicNumberToFieldID[74] = 142;
            PicNumberToFieldID[75] = 145;
            PicNumberToFieldID[76] = 154;
            PicNumberToFieldID[77] = 158;
            PicNumberToFieldID[78] = 163;
            PicNumberToFieldID[79] = 171;
            PicNumberToFieldID[80] = 173;
            PicNumberToFieldID[81] = 177;
            PicNumberToFieldID[82] = 180;
            PicNumberToFieldID[83] = 181;
            PicNumberToFieldID[84] = 182;
            PicNumberToFieldID[85] = 183;
            PicNumberToFieldID[86] = 184;
            PicNumberToFieldID[87] = 185;
            PicNumberToFieldID[88] = 187;
            PicNumberToFieldID[89] = 190;
            PicNumberToFieldID[90] = 196;
            PicNumberToFieldID[91] = 172;
            PicNumberToFieldID[92] = 174;
            PicNumberToFieldID[93] = 178;
            PicNumberToFieldID[94] = 179;
            PicNumberToFieldID[95] = 192;
            PicNumberToFieldID[96] = 197;
            PicNumberToFieldID[97] = 198;
            PicNumberToFieldID[98] = 207;
            PicNumberToFieldID[99] = 211;
            PicNumberToFieldID[100] = 212;
            PicNumberToFieldID[101] = 213;
            PicNumberToFieldID[102] = 214;
            PicNumberToFieldID[103] = 216;
            PicNumberToFieldID[104] = 219;
            PicNumberToFieldID[105] = 220;
            PicNumberToFieldID[106] = 221;
            PicNumberToFieldID[107] = 223;
            PicNumberToFieldID[108] = 224;
            PicNumberToFieldID[109] = 225;
            PicNumberToFieldID[110] = 228;
            PicNumberToFieldID[111] = 229;
            PicNumberToFieldID[112] = 230;
            PicNumberToFieldID[113] = 206;
            PicNumberToFieldID[114] = 208;
            PicNumberToFieldID[115] = 209;
            PicNumberToFieldID[116] = 215;
            PicNumberToFieldID[117] = 218;
            PicNumberToFieldID[118] = 226;
            PicNumberToFieldID[119] = 227;
            PicNumberToFieldID[120] = 231;
            PicNumberToFieldID[121] = 239;
            PicNumberToFieldID[122] = 244;
            PicNumberToFieldID[123] = 245;
            PicNumberToFieldID[124] = 246;
            PicNumberToFieldID[125] = 249;
            PicNumberToFieldID[126] = 250;
            PicNumberToFieldID[127] = 251;
            PicNumberToFieldID[128] = 253;
            PicNumberToFieldID[129] = 254;
            PicNumberToFieldID[130] = 257;
            PicNumberToFieldID[131] = 259;
            PicNumberToFieldID[132] = 262;
            PicNumberToFieldID[133] = 240;
            PicNumberToFieldID[134] = 241;
            PicNumberToFieldID[135] = 243;
            PicNumberToFieldID[136] = 252;
            PicNumberToFieldID[137] = 255;
            PicNumberToFieldID[138] = 256;
            PicNumberToFieldID[139] = 260;
            PicNumberToFieldID[140] = 261;
            PicNumberToFieldID[141] = 263;
            PicNumberToFieldID[142] = 264;
            PicNumberToFieldID[143] = 273;
            PicNumberToFieldID[144] = 279;
            PicNumberToFieldID[145] = 280;
            PicNumberToFieldID[146] = 281;
            PicNumberToFieldID[147] = 283;
            PicNumberToFieldID[148] = 284;
            PicNumberToFieldID[149] = 288;
            PicNumberToFieldID[150] = 291;
            PicNumberToFieldID[151] = 296;
            PicNumberToFieldID[152] = 274;
            PicNumberToFieldID[153] = 275;
            PicNumberToFieldID[154] = 277;
            PicNumberToFieldID[155] = 285;
            PicNumberToFieldID[156] = 286;
            PicNumberToFieldID[157] = 287;
            PicNumberToFieldID[158] = 292;
            PicNumberToFieldID[159] = 294;
            PicNumberToFieldID[160] = 295;
            PicNumberToFieldID[161] = 297;
            PicNumberToFieldID[162] = 298;
            PicNumberToFieldID[163] = 307;
            PicNumberToFieldID[164] = 313;
            PicNumberToFieldID[165] = 315;
            PicNumberToFieldID[166] = 316;
            PicNumberToFieldID[167] = 317;
            PicNumberToFieldID[168] = 318;
            PicNumberToFieldID[169] = 319;
            PicNumberToFieldID[170] = 322;
            PicNumberToFieldID[171] = 325;
            PicNumberToFieldID[172] = 327;
            PicNumberToFieldID[173] = 330;
            PicNumberToFieldID[174] = 308;
            PicNumberToFieldID[175] = 309;
            PicNumberToFieldID[176] = 312;
            PicNumberToFieldID[177] = 320;
            PicNumberToFieldID[178] = 321;
            PicNumberToFieldID[179] = 328;
            PicNumberToFieldID[180] = 329;
            PicNumberToFieldID[181] = 331;
            PicNumberToFieldID[182] = 341;
            PicNumberToFieldID[183] = 347;
            PicNumberToFieldID[184] = 349;
            PicNumberToFieldID[185] = 351;
            PicNumberToFieldID[186] = 352;
            PicNumberToFieldID[187] = 353;
            PicNumberToFieldID[188] = 357;
            PicNumberToFieldID[189] = 358;
            PicNumberToFieldID[190] = 362;
            PicNumberToFieldID[191] = 342;
            PicNumberToFieldID[192] = 348;
            PicNumberToFieldID[193] = 350;
            PicNumberToFieldID[194] = 355;
            PicNumberToFieldID[195] = 359;
            PicNumberToFieldID[196] = 360;
            PicNumberToFieldID[197] = 361;
            PicNumberToFieldID[198] = 364;
            PicNumberToFieldID[199] = 377;
            PicNumberToFieldID[200] = 385;
            PicNumberToFieldID[201] = 386;
            PicNumberToFieldID[202] = 389;
            PicNumberToFieldID[203] = 391;
            PicNumberToFieldID[204] = 395;
            PicNumberToFieldID[205] = 375;
            PicNumberToFieldID[206] = 384;
            PicNumberToFieldID[207] = 392;
            PicNumberToFieldID[208] = 393;
            PicNumberToFieldID[209] = 394;
            PicNumberToFieldID[210] = 396;
            PicNumberToFieldID[211] = 397;
            PicNumberToFieldID[212] = 427;
            PicNumberToFieldID[213] = 418;
        }
        static void Main(string[] args)
        {
            MapDataCreateHDDetail converter = new MapDataCreateHDDetail();
            converter.PaintOnFieldGrids(0, "春_r.png");
            converter.PaintOnFieldGrids(1, "夏_r.png");
            converter.PaintOnFieldGrids(2, "秋_r.png");
            converter.PaintOnFieldGrids(3, "冬_r.png");
        }
    }
}
