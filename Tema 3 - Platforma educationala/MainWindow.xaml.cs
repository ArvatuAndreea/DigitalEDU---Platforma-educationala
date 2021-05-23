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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tema_3___Platforma_educationala.Views;

namespace Tema_3___Platforma_educationala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Profesor(object sender, RoutedEventArgs e)
        {
            ProfesorWindow pw = new ProfesorWindow();
            pw.Show();
        }

        private void Button_Elev(object sender, RoutedEventArgs e)
        {
            ElevWindow ew = new ElevWindow();
            ew.Show();
        }

        private void Button_Admin(object sender, RoutedEventArgs e)
        {
            AdminWindow aw = new AdminWindow();
            aw.Show();
        }
    }
}
