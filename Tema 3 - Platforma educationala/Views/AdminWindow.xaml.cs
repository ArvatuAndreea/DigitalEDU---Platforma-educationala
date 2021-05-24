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

namespace Tema_3___Platforma_educationala.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void AdminElevi_Click(object sender, RoutedEventArgs e)
        {
            AdminElevWindow w = new AdminElevWindow();
            w.Show();
        }

        private void AdminProfesori_Click(object sender, RoutedEventArgs e)
        {
            AdminProfWindow w = new AdminProfWindow();
            w.Show();
        }

        private void AdminMaterii_Click(object sender, RoutedEventArgs e)
        {
            AdminSubjectWindow w = new AdminSubjectWindow();
            w.Show();
        }

        private void ListaElevi_Click(object sender, RoutedEventArgs e)
        {
            ListaEleviWindow window = new ListaEleviWindow();
            window.Show();
        }

        private void ListaProfesori_Click(object sender, RoutedEventArgs e)
        {
            ListaProfesoriWindow window = new ListaProfesoriWindow();
            window.Show();
        }

        private void ListaAdministratori_Click(object sender, RoutedEventArgs e)
        {
            ListaAdministratoriWindow window = new ListaAdministratoriWindow();
            window.Show();
        }
    }
}
