using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Prakticheskaya4
{
    public partial class MainWindow : Window
    {
        List<NewTypeDate> kek = new List<NewTypeDate>();
        public int summa = 0;
        public bool danet;

        public MainWindow()
        {
            InitializeComponent();
            NameZametka.Text = null;
            PriceZametka.Text = null;
            jpj();
        }

        private void jpj()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (File.Exists(desktop + "\\Zametka1.json"))
            {
                DataPick.SelectedDate = DateTime.Now;
            }
            else
            {
                File.AppendAllText(desktop + "\\Zametka1.json", "{ }");
                jpj();
            }
        }

        public void obnovlenie()
        {
            summa = 0;
            Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
            var jojo = deserialize;

            if (ComboBox.Items.Count > 0)
            {
                ComboBox.ItemsSource = null;
            }

            foreach (var item in jojo)
            {
                if (DataPick.Text == item.Key)
                {
                    ComboBox.ItemsSource = item.Value;

                }

                foreach (var item2 in item.Value)
                {
                    if (TypeZametka.Items.Contains(item2.TypeName))
                    {

                    }
                    else
                    {
                        TypeZametka.Items.Add(item2.TypeName);
                    }
                }

                foreach (var item1 in item.Value)
                {
                    if (item1.Vichet == false)
                    {
                        var rer = Int32.Parse(item1.Money);
                        summa = summa - rer;

                        LabelItog.Content = "Итог: " + summa;
                    }
                    else
                    {
                        var rer = Int32.Parse(item1.Money);
                        summa = summa + rer;

                        LabelItog.Content = "Итог: " + summa;
                    }
                }
            }

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
            var jojo = deserialize;


            NewTypeDate selected = ComboBox.SelectedItem as NewTypeDate;
            if (selected != null)
            {
                NameZametka.Text = selected.Name;
                TypeZametka.Text = selected.TypeName;
                if (selected.Vichet == false)
                {
                    int pomeh = Int32.Parse(selected.Money);
                    PriceZametka.Text = (pomeh * -1).ToString();
                }
                else
                {
                    PriceZametka.Text = selected.Money;
                }
            }
        }

        private void nachalo()
        {
            Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
            var jojo = deserialize;

            foreach (var item in jojo)
            {
                if (item.Key == DataPick.Text)
                {
                    jojo[item.Key].Add(kek.LastOrDefault());
                    ComboBox.ItemsSource = item.Value;
                    SerDeser.MySerialize(jojo);
                    kek.Clear();
                    summa = 0;

                    foreach (var item1 in item.Value)
                    {
                        if (item1.Vichet == false)
                        {
                            int fgf = Int32.Parse(item1.Money);
                            summa = summa - fgf;

                            LabelItog.Content = "Итог: " + summa;
                        }
                        else
                        {
                            int fgf = Int32.Parse(item1.Money);
                            summa = summa + fgf;

                            LabelItog.Content = "Итог: " + summa;
                        }
                    }
                }
            }
            NameZametka.Text = null;
            PriceZametka.Text = null;
            obnovlenie();
        }

        private void eshenachalo()
        {
            Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
            var jojo = deserialize;

            kek.Clear();
            if (Int32.Parse(PriceZametka.Text) > 0)
            {
                danet = true;
            }
            else
            {
                danet = false;
            }
            kek.Add(new NewTypeDate(NameZametka.Text, TypeZametka.SelectedItem.ToString(), PriceZametka.Text, danet));

            jojo.Add(DataPick.Text, kek);

            foreach (var item in jojo)
            {
                ComboBox.ItemsSource = item.Value;
                break;
            }

            SerDeser.MySerialize(jojo);
            NameZametka.Text = null;
            PriceZametka.Text = null;

            summa = 0;
            foreach (var item in jojo)
            {
                foreach (var item1 in item.Value)
                {
                    if (item1.Vichet == false)
                    {
                        int zxc = Int32.Parse(item1.Money);
                        summa = summa - zxc;

                        LabelItog.Content = "Итог: " + summa;
                    }
                    else
                    {
                        int zxc = Int32.Parse(item1.Money);
                        summa = summa + zxc;

                        LabelItog.Content = "Итог: " + summa;
                    }

                }
            }
            NameZametka.Text = null;
            PriceZametka.Text = null;
            obnovlenie();
        }

        private void NameZametka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TypeZametka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void PriceZametka_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
                var jojo = deserialize;

                if (Int32.Parse(PriceZametka.Text) > 0)
                {
                    danet = true;
                }
                else
                {
                    danet = false;
                }

                kek.Add(new NewTypeDate(NameZametka.Text, TypeZametka.SelectedItem.ToString(), PriceZametka.Text, danet));

                if (jojo.Count == 0)
                {
                    eshenachalo();
                    return;
                }
                else
                {
                    foreach (var item in jojo)
                    {
                        if (item.Key == DataPick.SelectedDate.Value.ToShortDateString())
                        {
                            nachalo();
                            break;
                        }
                    }
                    foreach (var item in jojo)
                    {
                        if (item.Key != DataPick.SelectedDate.Value.ToShortDateString())
                        {
                            eshenachalo();
                            break;
                        }
                    }
                }
                obnovlenie();
            }
            catch (Exception)
            {

            }
        }

        private void ButtonRename_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
                var jojo = deserialize;

                foreach (var item in jojo)
                {
                    if (item.Key == DataPick.Text)
                    {
                        NewTypeDate selected = ComboBox.SelectedItem as NewTypeDate;
                        foreach (var item1 in item.Value)
                        {
                            if (selected != null)
                            {
                                if (item1.Name == selected.Name)
                                {
                                    item1.Name = NameZametka.Text;
                                    int save = Int32.Parse(PriceZametka.Text);
                                    item1.Money = PriceZametka.Text;
                                    item1.TypeName = TypeZametka.Text;

                                    if (save > 0)
                                    {
                                        item1.Vichet = true;
                                    }
                                    else
                                    {
                                        item1.Vichet = false;
                                    }

                                    SerDeser.MySerialize(jojo);
                                    obnovlenie();
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                ButtonRename_Click(sender, e);
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<NewTypeDate>> deserialize = SerDeser.MyDeserialize<Dictionary<string, List<NewTypeDate>>>();
                var jojo = deserialize;

                if (ComboBox.Items.Count > 0)
                {
                    LabelItog.Content = "Итог: 0";
                }

                foreach (var item in jojo)
                {
                    if (item.Key == DataPick.Text)
                    {
                        jojo[item.Key].Remove(item.Value[ComboBox.SelectedIndex]);
                        SerDeser.MySerialize(jojo);
                        obnovlenie();
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void ButtonAddNewType_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.ShowDialog();

            if (window.vvod != null)
            {
                List<string> qwq = new List<string>();

                foreach (var item in TypeZametka.Items)
                {
                    qwq.Add(item.ToString());
                }
                if (qwq.Contains(window.vvod.ToString()))
                {
                    MessageBox.Show("Такой тип уже есть");
                }
                else
                {
                    TypeZametka.Items.Add(window.vvod.ToString());
                }
            }
        }

        private void DataPick_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                obnovlenie();
            }
            catch (Exception)
            {
                DataPick_SelectedDateChanged(sender, e);
            }

        }
    }
}
