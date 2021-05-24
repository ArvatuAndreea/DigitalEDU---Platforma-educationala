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
    /// Interaction logic for ElevWindow.xaml
    /// </summary>
    public partial class ElevWindow : Window
    {
        public ElevWindow()
        {
            InitializeComponent();
        }

        private void Button_Lectii(object sender, RoutedEventArgs e)
        {
            LectiiWindow lw = new LectiiWindow();
            lw.Show();
        }

        private void Button_Absente(object sender, RoutedEventArgs e)
        {
            AbsenteWindow aw = new AbsenteWindow();
            aw.Show();
        }

        private void Button_Note(object sender, RoutedEventArgs e)
        {
            NoteWindow nw = new NoteWindow();
            nw.Show();
        }

        private void Button_Medii(object sender, RoutedEventArgs e)
        {
            MediiWindow mw = new MediiWindow();
            mw.Show();
        }
    }
}
