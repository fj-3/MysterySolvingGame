using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MysterySolvingGame
{
    /// <summary>
    /// 第2ステージ(ピクロス→QRコード)
    /// </summary>
    public partial class Form2 : Form
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form2()
        {
            InitializeComponent();
        }

        //クリア時の文言
        private const string text = "完成！おめでとう！　「少し離れて」確認して、答えを入力しよう！！";

        // 次のステージ用フォーム追加
        private Form3 form3 = null;

        //ボタンリスト
        private List<Button> button;

        //黒色正解配置リスト(全部)(デバック用)
        private HashSet<int> blackButtons = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 9, 14, 15, 16, 17, 18, 19, 20, 21, 27, 30, 31, 35, 41, 42, 44, 45, 46, 48, 50, 51, 52, 54, 56, 58, 59, 60, 62, 63, 65, 66, 67, 69, 71, 72, 75, 77, 79, 80, 81, 83, 84, 86, 87, 88, 90, 93, 94, 95, 98, 100, 101, 102, 104, 105, 111, 115, 117, 119, 125, 126, 127, 128, 129, 130, 131, 132, 134, 136, 138, 140, 141, 142, 143, 144, 145, 146, 157, 158, 171, 172, 174, 175, 185, 186, 189, 190, 193, 194, 197, 198, 201, 203, 205, 206, 207, 210, 211, 213, 216, 219, 220, 221, 222, 223, 226, 227, 233, 235, 236, 238, 240, 245, 248, 251, 252, 253, 254, 255, 256, 258, 259, 260, 266, 269, 270, 271, 272, 281, 282, 283, 285, 287, 288, 291, 292, 293, 294, 295, 296, 297, 298, 299, 300, 302, 303, 304, 306, 307, 308, 309, 310, 313, 314, 315, 321, 330, 331, 332, 335, 336, 338, 339, 340, 342, 344, 345, 347, 348, 349, 350, 351, 353, 354, 355, 356, 357, 359, 360, 361, 363, 365, 366, 368, 373, 375, 378, 380, 381, 382, 384, 388, 389, 390, 391, 392, 395, 397, 398, 399, 405, 409, 413, 415, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 430, 431, 438 };

        /// <summary>
        /// ロード時動作
        /// </summary>
        private void Form2_Load(object sender, EventArgs e)
        {
            //ボタンの数だけボタン番号を左上から順に定義
            var buttons = Controls
        .OfType<Button>()
        .OrderBy(b => b.Top)
        .ThenBy(b => b.Left)
        .ToList();

            button = buttons;
            for (int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Name = "button" + (i + 1);
                buttons[i].Click += new EventHandler(ColorChangeEventHandler);
            }

            //白黒配置初期値(一部)：ここの値によって初期配置を変更
            var blackButtonsInit = new HashSet<int> { 0, 1, 2, 3, 4, 5, 6, 9, 14, 15, 16, 17, 18, 19, 20, 21, 27, 30, 31, 35, 41, 157, 158, 171, 172, 174, 175, 185, 186, 189, 190, 193, 194, 197, 198, 201, 203, 205, 206, 207, 210, 211, 213, 216, 219, 220, 221, 222, 223, 226, 227, 233, 235, 236, 238, 240, 245 };

            //リストにある番号のボタンのみを黒色にする
            for (int i = 0; i < button.Count; i++)
            {
                buttons[i].BackColor = blackButtonsInit.Contains(i) ? Color.Black : Color.White;
            }
        }

        /// <summary>
        /// 白黒入れ替えイベント
        /// </summary>
        private void ColorChangeEventHandler(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.BackColor == Color.Black && button.ForeColor == Color.White)
            {
                button.BackColor = Color.White;
                button.ForeColor = Color.Black;
                button.Text = "×";
            }
            else
            {
                button.BackColor = Color.Black;
                button.ForeColor = Color.White;
                button.Text = "";
            }

            Goal();
        }

        /// <summary>
        /// 終了判定
        /// </summary>
        private void Goal()
        {
            bool condition = true;

            for (int i = 0; i < button.Count; i++)
            {
                if (blackButtons.Contains(i))
                {
                    // 黒であるべきボタン
                    if (button[i].BackColor != Color.Black)
                    {
                        condition = false;
                        break;
                    }
                }
                else
                {
                    // 白であるべきボタン
                    if ((button[i].BackColor != Color.White) || (button[i].Text == ""))
                    {
                        condition = false;
                        break;
                    }
                }
            }

            if (condition)
            {
                MessageBox.Show(text);
            }
        }

        /// <summary>
        /// 第3ゲーム答え判定
        /// </summary>
        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            if (textBox43.Text == "えと" || textBox43.Text == "干支" || textBox43.Text == "エト")
            {
                form3 = new Form3();
                form3.Show();
            }
        }
    }
}