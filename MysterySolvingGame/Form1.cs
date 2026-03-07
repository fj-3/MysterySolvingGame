using System;
using System.Linq;
using System.Windows.Forms;

namespace MysterySolvingGame
{
    /// <summary>
    /// (ステージ１)9スライドパズル
    /// </summary>
    public partial class Form1 : Form
    {
        // Form2型のオブジェクト定義
        private Form2 form2 = null;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        private const string LogName = "MysterySolvingGame";
        private static readonly NLog.Logger logger1 = NLog.LogManager.GetLogger(LogName);
        private string[] num = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        /// <summary>
        /// Stopwatchオブジェクトを作成する
        /// </summary>
        private readonly System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        /// <summary>
        /// ロード時の動作
        /// </summary>
        private void Form1_Load_1(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = true;
            button11.Enabled = false;
        }

        /// <summary>
        /// 終了判定
        /// </summary>
        private void Goal()
        {
            if ((button1.Text == "1") && (button2.Text == "2") && (button3.Text == "3")
                && (button4.Text == "4") && (button5.Text == "5") && (button6.Text == "6")
                && (button7.Text == "7") && (button8.Text == "8") && (button9.Text == " "))
            {
                //ストップウォッチを止める
                sw.Stop();

                //結果を表示する
                logger1.Trace($"[9パズルの記録]{sw.Elapsed}");

                if (sw.Elapsed.Minutes >= 1)
                {
                    MessageBox.Show($"残念！もう一回チャレンジしてね！ \nタイム:  {sw.Elapsed.Minutes}分{sw.Elapsed.Seconds} 秒");
                    return;
                }

                //次へ進むボタン表示
                button11.Enabled = true;

                // TODO  謎を考える
                button1.Text = "";
                button2.Text = "";
                button3.Text = "";
                button4.Text = "";
                button5.Text = "";
                button6.Text = "";
                button7.Text = "";
                button8.Text = "";
                button9.Text = "";

                MessageBox.Show($"第一ステージクリア！　Congratulation! \nタイム:  {sw.Elapsed.Minutes}分{sw.Elapsed.Seconds} 秒");
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// 数字をランダムに並び替え
        /// </summary>
        /// <exception cref="InvalidOperationException">1～9以外の数字の場合</exception>
        private void RandomNumber()
        {
            num = num.OrderBy(a => Guid.NewGuid()).ToArray();
            for (int i = 0; i < num.Length; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            if (num[i] == "9")
                            {
                                button1.Text = " ";
                                break;
                            }
                            button1.Text = num[i];
                        }
                        break;

                    case 1:
                        {
                            if (num[i] == "9")
                            {
                                button2.Text = " ";
                                break;
                            }
                            button2.Text = num[i];
                        }
                        break;

                    case 2:
                        {
                            if (num[i] == "9")
                            {
                                button3.Text = " ";
                                break;
                            }
                            button3.Text = num[i];
                        }
                        break;

                    case 3:
                        {
                            if (num[i] == "9")
                            {
                                button4.Text = " ";
                                break;
                            }
                            button4.Text = num[i];
                        }
                        break;

                    case 4:
                        {
                            if (num[i] == "9")
                            {
                                button5.Text = " ";
                                break;
                            }
                            button5.Text = num[i];
                        }
                        break;

                    case 5:
                        {
                            if (num[i] == "9")
                            {
                                button6.Text = " ";
                                break;
                            }
                            button6.Text = num[i];
                        }
                        break;

                    case 6:
                        {
                            if (num[i] == "9")
                            {
                                button7.Text = " ";
                                break;
                            }
                            button7.Text = num[i];
                        }
                        break;

                    case 7:
                        {
                            if (num[i] == "9")
                            {
                                button8.Text = " ";
                                break;
                            }
                            button8.Text = num[i];
                        }
                        break;

                    case 8:
                        {
                            if (num[i] == "9")
                            {
                                button9.Text = " ";
                                break;
                            }
                            button9.Text = num[i];
                        }
                        break;

                    default: throw new InvalidOperationException();
                }
            }
        }

        /// <summary>
        /// 1のボタン
        /// </summary>
        private void Button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == " ")
            {
                return;
            }
            else
            {
                if (button2.Text == " ")
                {
                    (button1.Text, button2.Text) = (button2.Text, button1.Text);
                }

                if (button4.Text == " ")
                {
                    (button1.Text, button4.Text) = (button4.Text, button1.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 2のボタン
        /// </summary>
        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == " ")
            {
                return;
            }
            else
            {
                if (button1.Text == " ")
                {
                    (button2.Text, button1.Text) = (button1.Text, button2.Text);
                }

                if (button3.Text == " ")
                {
                    (button2.Text, button3.Text) = (button3.Text, button2.Text);
                }

                if (button5.Text == " ")
                {
                    (button2.Text, button5.Text) = (button5.Text, button2.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 3のボタン
        /// </summary>s
        private void Button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == " ")
            {
                return;
            }
            else
            {
                if (button2.Text == " ")
                {
                    (button3.Text, button2.Text) = (button2.Text, button3.Text);
                }

                if (button6.Text == " ")
                {
                    (button3.Text, button6.Text) = (button6.Text, button3.Text);
                }
            }

            Goal();
        }

        /// <summary>
        ///　4のボタン
        /// </summary>
        private void Button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == " ")
            {
                return;
            }
            else
            {
                if (button1.Text == " ")
                {
                    (button1.Text, button4.Text) = (button4.Text, button1.Text);
                }

                if (button5.Text == " ")
                {
                    (button5.Text, button4.Text) = (button4.Text, button5.Text);
                }

                if (button7.Text == " ")
                {
                    (button7.Text, button4.Text) = (button4.Text, button7.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 5のボタン
        /// </summary>
        private void Button5_Click(object sender, EventArgs e)
        {
            if (button5.Text == " ")
            {
                return;
            }
            else
            {
                if (button2.Text == " ")
                {
                    (button5.Text, button2.Text) = (button2.Text, button5.Text);
                }

                if (button4.Text == " ")
                {
                    (button5.Text, button4.Text) = (button4.Text, button5.Text);
                }

                if (button6.Text == " ")
                {
                    (button5.Text, button6.Text) = (button6.Text, button5.Text);
                }

                if (button8.Text == " ")
                {
                    (button5.Text, button8.Text) = (button8.Text, button5.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 6のボタン
        /// </summary>
        private void Button6_Click(object sender, EventArgs e)
        {
            if (button6.Text == " ")
            {
                return;
            }
            else
            {
                if (button3.Text == " ")
                {
                    (button6.Text, button3.Text) = (button3.Text, button6.Text);
                }

                if (button5.Text == " ")
                {
                    (button6.Text, button5.Text) = (button5.Text, button6.Text);
                }

                if (button9.Text == " ")
                {
                    (button6.Text, button9.Text) = (button9.Text, button6.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 7のボタン
        /// </summary>
        private void Button7_Click(object sender, EventArgs e)
        {
            if (button7.Text == " ")
            {
                return;
            }
            else
            {
                if (button4.Text == " ")
                {
                    (button7.Text, button4.Text) = (button4.Text, button7.Text);
                }

                if (button8.Text == " ")
                {
                    (button7.Text, button8.Text) = (button8.Text, button7.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 8のボタン
        /// </summary>
        private void Button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == " ")
            {
                return;
            }
            else
            {
                if (button5.Text == " ")
                {
                    (button8.Text, button5.Text) = (button5.Text, button8.Text);
                }

                if (button7.Text == " ")
                {
                    (button8.Text, button7.Text) = (button7.Text, button8.Text);
                }

                if (button9.Text == " ")
                {
                    (button8.Text, button9.Text) = (button9.Text, button8.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// 9のボタン
        /// </summary>
        private void Button9_Click(object sender, EventArgs e)
        {
            if (button9.Text == " ")
            {
                return;
            }
            else
            {
                if (button6.Text == " ")
                {
                    (button9.Text, button6.Text) = (button6.Text, button9.Text);
                }

                if (button8.Text == " ")
                {
                    (button9.Text, button8.Text) = (button8.Text, button9.Text);
                }
            }

            Goal();
        }

        /// <summary>
        /// ゲーム開始ボタン
        /// </summary>
        private void Button10_Click(object sender, EventArgs e)
        {
            bool EvenNum1;
            bool EvenNum2;

            do
            {
                //初期配置
                RandomNumber();

                int count = 0;
                int gap = 0;

                ///　(i)「空き」の最短距離の偶奇判定 ///

                int[] num1 = Array.ConvertAll(num, int.Parse);  // stringをintに変換

                if (button9.Text == " ")  //「空き」が正しい場所にある時
                {
                    EvenNum1 = true;
                }
                else            //「空き」が正しい場所にない時
                {
                    int index1 = Array.IndexOf(num, "9"); // 9(本来は空欄)のマスの配列場所特定

                    gap = 8 - index1;
                    if (gap % 2 == 0)
                    {
                        EvenNum1 = true;
                    }
                    else
                    {
                        EvenNum1 = false;
                    }
                }

                /// (ⅱ)完成までの置換回数の偶奇判定 ///

                for (var i = 0; i < num1.Length; i++)
                {
                    for (var j = i + 1; j < num1.Length; j++)
                    {
                        if (num1[i] > num1[j])
                        {
                            (num1[j], num1[i]) = (num1[i], num1[j]);
                            count++;
                        }
                    }
                }

                if (count % 2 == 0)
                {
                    EvenNum2 = true;
                }
                else
                {
                    EvenNum2 = false;
                }
            }
            while (EvenNum1 != EvenNum2);

            /// 最終判定(偶奇の一致判定) ///
            if (EvenNum1 == EvenNum2)
            {
                //ストップウォッチを開始する
                sw.Stop();
                sw.Reset();
                sw.Start();

                //ボタン表示
                button1.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                button6.Enabled = true;
                button7.Enabled = true;
                button8.Enabled = true;
                button9.Enabled = true;
            }
        }

        /// <summary>
        ///　次のステージへ遷移するボタン
        /// </summary>
        private void Button11_Click(object sender, EventArgs e)
        {
            // フォームを生成して、表示します
            form2 = new Form2();
            form2.Show();
        }
    }
}