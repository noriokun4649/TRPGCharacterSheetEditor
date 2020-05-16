using System.Windows;
using System.Windows.Controls;

namespace TRPG_PointCalculation
{
    /// <summary>
    /// add.xaml の相互作用ロジック
    /// </summary>
    public partial class Add : Window
    {
        private string name;
        private int marumarupointd;
        private int defpoint;
        private int nokoripoint;
        private int sumpoint;
        private int addpoint;
        private string maru;
        private bool editmode;
        private int index;
        private MainWindow mainWindow;

        public Add()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void SendData(string name, int point, string maru, int marumarupointd, MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            defpoint = point;
            this.name = name;
            this.marumarupointd = marumarupointd;
            this.maru = maru;
            name_txt.Text = "技能名：" + name;
            def.Text = "技能初期値：" + defpoint;
            marumarupoint.Text = maru + "ポイント残り：" + this.marumarupointd;
            nokori.Text = "割り振り後の" + maru + "ポイント：" + this.marumarupointd;
            sumpoint = defpoint + addpoint;
            sum.Text = "技能値合計：" + sumpoint;
            input.Focus();
            editmode = false;
        }

        public void EditData(string name, int point, string maru, int marumarupointd, MainWindow mainWindow, string addpoint,int index)
        {
            SendData(name, point, maru, marumarupointd, mainWindow);
            this.marumarupointd = marumarupointd + int.Parse(addpoint);
            marumarupoint.Text = maru + "ポイント残り：" + this.marumarupointd;
            nokori.Text = "割り振り後の" + maru + "ポイント：" + this.marumarupointd;
            editmode = true;
            this.index = index;
            input.Text = addpoint;
            input.Focus();
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (input.Text != "")
                {
                    addpoint = int.Parse(input.Text);
                    nokoripoint = marumarupointd - addpoint;
                    nokori.Text = "割り振り後の" + maru + "ポイント：" + nokoripoint;
                    sumpoint = defpoint + addpoint;
                    sum.Text = "技能値合計：" + sumpoint;
                }
            }
            catch
            {
                MessageBox.Show("半角数字でおｋ？");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (sumpoint < 100)
            {
                if (nokoripoint >= 0)
                {
                    if (!editmode)
                    {
                        var check = mainWindow.Check(name);
                        if (!(check[0] || check[1]))
                        {
                            mainWindow.AddData(maru == "職業" ? 1 : 2, name, defpoint, addpoint, sumpoint);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show((check[0] ? "職業" : "趣味") + "技能に既に追加されてる！");
                        }
                    }
                    else
                    {
                        mainWindow.AddData(maru == "職業" ? 1 : 2, name, defpoint, addpoint, sumpoint,index);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("割り振り後の" + maru + "ポイントがマイナスになる！");
                }
            }
            else
            {
                MessageBox.Show("ふれるポイントは99以下！");
            }
        }
    }
}
