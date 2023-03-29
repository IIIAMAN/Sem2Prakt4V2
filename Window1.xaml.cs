using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prakticheskaya4
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public string vvod;
        public Window1()
        {
            InitializeComponent();
            StrokaNewOkno.Text = null;
        }

        private void ButtonAddNewOkno_Click(object sender, RoutedEventArgs e)
        {
            vvod = StrokaNewOkno.Text;
            DialogResult = true;
        }

        private void StrokaNewOkno_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
