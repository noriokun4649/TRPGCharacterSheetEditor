using System;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;

namespace TRPG_PointCalculation
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        int tecpoint;
        int hobypoint;
        int tecpoint_nokori;
        int hobypoint_nokori;

        public MainWindow()
        {
            InitializeComponent();
            ((INotifyCollectionChanged)tec_list.Items).CollectionChanged += TecList_CollectionChanged;
            ((INotifyCollectionChanged)hoby_list.Items).CollectionChanged += HobyList_CollectionChanged;
            ((INotifyCollectionChanged)ability_list.Items).CollectionChanged += AbilityList_CollectionChanged;

            list.Items.Add(new string[] { "キック", "25" });
            list.Items.Add(new string[] { "組みつき", "25" });
            list.Items.Add(new string[] { "こぶし/パンチ", "50" });
            list.Items.Add(new string[] { "頭突き", "10" });
            list.Items.Add(new string[] { "投擲", "25" });
            list.Items.Add(new string[] { "マーシャルアーツ", "1" });
            list.Items.Add(new string[] { "拳銃", "20" });
            list.Items.Add(new string[] { "サブマシンガン", "15" });
            list.Items.Add(new string[] { "ショットガン", "30" });
            list.Items.Add(new string[] { "マシンガン", "15" });
            list.Items.Add(new string[] { "ライフル", "25" });
            list.Items.Add(new string[] { "応急手当", "30" });
            list.Items.Add(new string[] { "鍵開け", "1" });
            list.Items.Add(new string[] { "隠す", "15" });
            list.Items.Add(new string[] { "隠れる", "10" });
            list.Items.Add(new string[] { "聞き耳", "25" });
            list.Items.Add(new string[] { "忍び歩き", "10" });
            list.Items.Add(new string[] { "写真術", "10" });
            list.Items.Add(new string[] { "精神分析", "1" });
            list.Items.Add(new string[] { "追跡", "10" });
            list.Items.Add(new string[] { "登攀", "40" });
            list.Items.Add(new string[] { "図書館", "25" });
            list.Items.Add(new string[] { "目星", "25" });
            list.Items.Add(new string[] { "運転", "20" });
            list.Items.Add(new string[] { "機械修理", "20" });
            list.Items.Add(new string[] { "重機械操作", "1" });
            list.Items.Add(new string[] { "乗馬", "5" });
            list.Items.Add(new string[] { "水泳", "25" });
            list.Items.Add(new string[] { "制作", "5" });
            list.Items.Add(new string[] { "操縦", "1" });
            list.Items.Add(new string[] { "跳躍", "25" });
            list.Items.Add(new string[] { "電気修理", "10" });
            list.Items.Add(new string[] { "ナビゲート", "10" });
            list.Items.Add(new string[] { "変装", "1" });
            list.Items.Add(new string[] { "言いくるめ", "5" });
            list.Items.Add(new string[] { "信用", "15" });
            list.Items.Add(new string[] { "説得", "15" });
            list.Items.Add(new string[] { "母国語", "100" });
            list.Items.Add(new string[] { "医学", "5" });
            list.Items.Add(new string[] { "オカルト", "5" });
            list.Items.Add(new string[] { "化学", "1" });
            list.Items.Add(new string[] { "クトゥルフ神話", "0" });
            list.Items.Add(new string[] { "芸術", "5" });
            list.Items.Add(new string[] { "経理", "10" });
            list.Items.Add(new string[] { "考古学", "1" });
            list.Items.Add(new string[] { "コンピューター", "1" });
            list.Items.Add(new string[] { "心理学", "5" });
            list.Items.Add(new string[] { "生物学", "1" });
            list.Items.Add(new string[] { "地質学", "1" });
            list.Items.Add(new string[] { "電子工学", "1" });
            list.Items.Add(new string[] { "天文学", "1" });
            list.Items.Add(new string[] { "博物学", "10" });
            list.Items.Add(new string[] { "物理学", "1" });
            list.Items.Add(new string[] { "法律", "5" });
            list.Items.Add(new string[] { "薬学", "1" });
            list.Items.Add(new string[] { "歴史", "20" });
            list.Items.Add(new string[] { "ナイフ", "25" });
            ability_list.Items.Add(new string[] { "STR(筋力)", "3D6", "", "" });
            ability_list.Items.Add(new string[] { "CON(体力)", "3D6", "", "" });
            ability_list.Items.Add(new string[] { "POW(精神力)", "3D6", "", "" });
            ability_list.Items.Add(new string[] { "DEX(敏捷性)", "3D6", "", "" });
            ability_list.Items.Add(new string[] { "APP(外見)", "3D6+6", "", "" });
            ability_list.Items.Add(new string[] { "SIZ(体格)", "3D6+6", "", "" });
            ability_list.Items.Add(new string[] { "INT(知性)", "3D6+6", "", "" });
            ability_list.Items.Add(new string[] { "EDU(教育)", "3D6+3", "", "" });
            ability_list.Items.Add(new string[] { "年収・財産", "3D6", "", "" });
            point_list.Items.Add(new string[] { "SAN（正気度）", "POW×5", "" });
            point_list.Items.Add(new string[] { "幸運", "POW×5", "" });
            point_list.Items.Add(new string[] { "アイデア", "INT×5", "" });
            point_list.Items.Add(new string[] { "知識", "EDU×5", "" });
            point_list.Items.Add(new string[] { "耐久力", "(CON+SIZ)÷2", "" });
            point_list.Items.Add(new string[] { "マジックポイント", "POW×1", "" });
            point_list.Items.Add(new string[] { "職業技能ポイント", "EDU×20", "" });
            point_list.Items.Add(new string[] { "趣味技能ポイント", "INT×10", "" });
            point_list.Items.Add(new string[] { "回避", "DEX×2", "" });
            point_list.Items.Add(new string[] { "ダメージボーナス", "STR+SIZ", "" });
        }

        //----------技能追加じっそー----------
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                hobypoint = int.Parse(hoby.Text);
                tecpoint = int.Parse(tec.Text);
                tex_txt.Text = "職業ポイント残り：" + tecpoint.ToString();
                hoby_txt.Text = "趣味ポイント残り：" + hobypoint.ToString();
                Changed(tec_list.Items, "職業", tecpoint, tex_txt);
                Changed(hoby_list.Items, "趣味", hobypoint, hoby_txt);
            }
            catch
            {
                MessageBox.Show("半角数字で入力して！");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Add(tecpoint, "職業", tecpoint_nokori);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Add(hobypoint, "趣味", hobypoint_nokori);
        }

        private void Add(int point, string mode, int nokori)
        {
            try
            {
                if (point > 0)
                {
                    var window = new Add();
                    window.SendData(((string[])list.SelectedItem)[0], int.Parse(((string[])list.SelectedItem)[1]), mode, nokori, this);
                    window.Owner = this;
                    window.Show();
                }
                else
                {
                    MessageBox.Show("初期ポイントを設定して！");
                }
            }
            catch
            {
                MessageBox.Show("追加する技能を上の一覧から選択して！");
            }
        }

        public void AddData(int mode, string name, int defpoint, int addpoint, int sumpoint)
        {
            ListView listView;
            switch (mode)
            {
                default:
                    listView = tec_list;
                    break;
                case 2:
                    listView = hoby_list;
                    break;
            }
            listView.Items.Add(new string[] { name, defpoint.ToString(), addpoint.ToString(), sumpoint.ToString() });
        }

        private void Tec_list_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            foreach (string[] list in tec_list.Items)
            {
                MessageBox.Show(list[2]);
            }
        }
        private void TecList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changed(tec_list.Items, "職業", tecpoint, tex_txt);
        }
        private void HobyList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Changed(hoby_list.Items, "趣味", hobypoint, hoby_txt);
        }

        private void Changed(ItemCollection itemCollection, string mode, int point, TextBlock block)
        {
            var sum = 0;
            foreach (string[] list in itemCollection)
            {
                sum += int.Parse(list[2]);
            }
            var pointnokori = point - sum;
            block.Text = mode + "ポイント残り：" + pointnokori;
            switch (mode)
            {
                case "職業":
                    tecpoint_nokori = pointnokori;
                    break;
                case "趣味":
                    hobypoint_nokori = pointnokori;
                    break;
            }
        }

        private void Tec_del_Click(object sender, RoutedEventArgs e)
        {
            tec_list.Items.Remove(tec_list.SelectedItem);
        }

        private void Hoby_del_Click(object sender, RoutedEventArgs e)
        {

            hoby_list.Items.Remove(hoby_list.SelectedItem);
        }
        private void Load_Click(object sender, RoutedEventArgs e)
        {
            tec.Text = ((string[])point_list.Items[6])[2];
            hoby.Text = ((string[])point_list.Items[7])[2];
        }

        public bool[] Check(string name)
        {
            bool tec_cont = false;
            bool hoby_cont = false;
            foreach (string[] tec in tec_list.Items)
            {
                tec_cont = tec[0].Contains(name);
                if (tec_cont) break;
            }
            foreach (string[] hoby in hoby_list.Items)
            {
                hoby_cont = hoby[0].Contains(name);
                if (hoby_cont) break;
            }
            return new bool[] { tec_cont, hoby_cont };
        }

        private void Tec_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tecpoint > 0)
                {
                    var window = new Add();
                    window.EditData(((string[])tec_list.SelectedItem)[0], int.Parse(((string[])tec_list.SelectedItem)[1]), "職業", hobypoint_nokori, this, ((string[])tec_list.SelectedItem)[2]);
                    window.Owner = this;
                    window.Show();
                    tec_list.Items.Remove(tec_list.SelectedItem);
                }
                else
                {
                    MessageBox.Show("初期ポイントを設定して！");
                }
            }
            catch
            {
                MessageBox.Show("編集する技能を上の一覧から選択して！");
            }
        }

        private void Hoby_edit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (hobypoint > 0)
                {
                    var window = new Add();
                    window.EditData(((string[])hoby_list.SelectedItem)[0], int.Parse(((string[])hoby_list.SelectedItem)[1]), "趣味", hobypoint_nokori, this, ((string[])hoby_list.SelectedItem)[2]);
                    window.Owner = this;
                    window.Show();
                    hoby_list.Items.Remove(hoby_list.SelectedItem);
                }
                else
                {
                    MessageBox.Show("初期ポイントを設定して！");
                }
            }
            catch
            {
                MessageBox.Show("編集する技能を上の一覧から選択して！");
            }
        }
        //----------技能追加じっそー終わり----------

        //----------メニューじっそー----------

        private void Exit_menu_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Output_skill_Click(object sender, RoutedEventArgs e)
        {
            Output(SkillText());
        }

        private void Output_character_Click(object sender, RoutedEventArgs e)
        {
            Output(CharacterText());
        }

        private void Output_all_Click(object sender, RoutedEventArgs e)
        {
            Output(CharacterText() + SkillText());
        }
        private void Output(string text)
        {
            var outs = new Output();
            outs.SetText(text);
            outs.Owner = this;
            outs.Show();
        }

        private string CharacterText()
        {
            var output_text = "《プロフィール》\n";
            output_text += "性別:" + sex_box.Text + "\n";
            output_text += "年齢:" + age_box.Text + "\n";
            output_text += "職業:" + occupation_box.Text + "\n";
            output_text += "学位:" + degree_box.Text + "\n";
            output_text += "出身:" + from_box.Text + "\n";
            output_text += "精神的な障害:" + handicap_box.Text + "\n\n";
            output_text += "《能力値》\n";
            foreach (string[] list in ability_list.Items)
            {
                output_text += list[0] + ":" + list[3] + "\n";
            }
            output_text += "\n";
            foreach (string[] list in point_list.Items)
            {
                output_text += list[0] + ":" + list[2] + "\n";
            }
            output_text += "\n《持ち物》\n";
            output_text += "武器:" + arms_box.Text + "\n";
            output_text += "防具:" + armor_box.Text + "\n";
            output_text += "所持品:" + item_box.Text + "\n\n";
            return output_text;
        }

        private string SkillText()
        {
            var output_text = "《職業技能》\t" + tecpoint + "\n";
            foreach (string[] list in tec_list.Items)
            {
                output_text += list[0] + "　　初期値：" + list[1] + "　＋　" + list[2] + "　＝　" + list[3] + "\n";
            }
            output_text = output_text + "\n《趣味技能》　" + hobypoint + "\n";
            foreach (string[] list in hoby_list.Items)
            {
                output_text += list[0] + "　　初期値：" + list[1] + "　＋　" + list[2] + "　＝　" + list[3] + "\n";
            }
            return output_text;
        }


        //----------メニューじっそ終わりー----------

        //----------キャラ作成じっそー----------
        private void AbilityList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                var str = int.Parse(((string[])ability_list.Items[0])[3]);
                var con = int.Parse(((string[])ability_list.Items[1])[3]);
                var pow = int.Parse(((string[])ability_list.Items[2])[3]);
                var dex = int.Parse(((string[])ability_list.Items[3])[3]);
                var siz = int.Parse(((string[])ability_list.Items[5])[3]);
                var ints = int.Parse(((string[])ability_list.Items[6])[3]);
                var edu = int.Parse(((string[])ability_list.Items[7])[3]);



                var oldRule = new int[] { pow * 5, pow * 5, ints * 5, edu * 5, (con + siz) / 2, pow * 1, edu * 20, ints * 10, dex * 2, str + siz };

                for (int i = 0; i < point_list.Items.Count; i++)
                {
                    var item = (string[])point_list.Items[i];

                    var output = oldRule[i].ToString();
                    if (item[0].Equals("ダメージボーナス"))
                    {
                        output = GetDamageBonus(oldRule[i]);
                    }

                    point_list.Items[i] = new string[] { item[0], item[1], output };
                }
            }
            catch
            {

            }
        }

        private string GetDamageBonus(int num)
        {
            if (num <= 12)
            {
                return "-1D6";
            }
            else if (num <= 16)
            {
                return "-1D4";
            }
            else if (num <= 24)
            {
                return "±0";
            }
            else if (num <= 32)
            {
                return "+1D4";
            }
            else if (num <= 40)
            {
                return "+1D6";
            }
            else if (num <= 56)
            {
                return "+2D6";
            }
            else if (num <= 72)
            {
                return "+3D6";
            }
            else
            {
                return "";
            }
        }

        private void Dice_button_Click(object sender, RoutedEventArgs e)
        {
            var count = ability_list.Items.Count;
            for (int i = 0; i < count; i++)
            {
                var item = (string[])ability_list.Items[i];
                var sum = 0;
                var text = "";
                var roll = item[1].Split('+');
                foreach (var id in Dice(roll[0]))
                {
                    sum += id;
                    text += "　" + id;
                }
                if (roll.Length > 1)
                {
                    sum += int.Parse(roll[1]);
                    text += "　" + roll[1];
                }
                if (!item[0].Equals("年収・財産"))
                {
                    ability_list.Items[i] = new string[] { item[0], item[1], text, sum.ToString() };
                }
                else
                {
                    var money = GetMoney(sum);
                    ability_list.Items[i] = new string[] { item[0], item[1], text, "年収：" + money[0] + "\n財産：" + money[1] };
                }

            }
        }

        private string[] GetMoney(int para)
        {
            var data = new int[] { 150, 200, 250, 300, 350, 400, 450, 500, 600, 700, 800, 900, 1000, 2000, 3000, 5000 };
            para -= 3;
            return new string[] { data[para] + "万", data[para] * 5 + "万" };
        }

        private int[] Dice(string text)
        {
            var sp = text.Split('D');
            return Dice(int.Parse(sp[0]), int.Parse(sp[1]));
        }
        private int[] Dice(int count, int roll)
        {
            var output = new int[count];
            for (int i = 0; i < count; i++)
            {
                var rand = new Random(CreateRandomSeed());
                output[i] = rand.Next(1, roll);
            }
            return output;
        }
        public int CreateRandomSeed()
        {
            var bs = new byte[4];
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bs);
            }
            return BitConverter.ToInt32(bs, 0);
        }

        private void Tec_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                var text = tec.Text;
                if (text.Equals("")) text = "0";
                tecpoint = int.Parse(text);
                tex_txt.Text = "職業ポイント残り：" + tecpoint.ToString();
                Changed(tec_list.Items, "職業", tecpoint, tex_txt);
            }
            catch (FormatException)
            {
                MessageBox.Show("半角数字でおｋ？");
            }
        }

        private void Hoby_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                var text = hoby.Text;
                if (text.Equals("")) text = "0";
                hobypoint = int.Parse(text);
                hoby_txt.Text = "趣味ポイント残り：" + hobypoint.ToString();
                Changed(hoby_list.Items, "趣味", hobypoint, hoby_txt);
            }
            catch (FormatException)
            {
                MessageBox.Show("半角数字でおｋ？");
            }
        }

        private void Dice_hide_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)dice_hide.IsChecked)
            {
                ability_list.Columns[1].Visibility = Visibility.Hidden;
            }
            else
            {
                ability_list.Columns[1].Visibility = Visibility.Visible;
            }
        }

        private void Dice_ans_hide_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)dice_ans_hide.IsChecked)
            {
                ability_list.Columns[2].Visibility = Visibility.Hidden;
            }
            else
            {
                ability_list.Columns[2].Visibility = Visibility.Visible;
            }
        }

        private void Cal_hide_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)cal_hide.IsChecked)
            {
                point_list.Columns[1].Visibility = Visibility.Hidden;
            }
            else
            {
                point_list.Columns[1].Visibility = Visibility.Visible;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBoxResult.Yes != MessageBox.Show("終了するとすべてのデータは消えます。\n\n終了してよろしいですか？", "終了しますか？", MessageBoxButton.YesNo, MessageBoxImage.Information))
            {
                e.Cancel = true;
                return;
            }
        }

    }
}
