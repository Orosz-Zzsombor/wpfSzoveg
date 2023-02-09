using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WpfApp1
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


        private void Betolt_Click(object sender, RoutedEventArgs e)
        {
            lblistaEgy.Items.Clear();
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Kérem válassza ki a betöltendő fájlt!";
            if (ofd.ShowDialog() == false)
            {
                return;
            }
            StreamReader fajlOlvaso = new StreamReader(ofd.FileName);
            String? olvasottSor;
            while (!fajlOlvaso.EndOfStream)
            {
                olvasottSor = fajlOlvaso.ReadLine();
                if (olvasottSor != "")
                {
                    lblistaEgy.Items.Add(olvasottSor);
                }
            }
            fajlOlvaso.Close();
        }

        private void btnElment_Click(object sender, RoutedEventArgs e)
        {
            lblistaKetto.Items.Clear();
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog()==true)
            {
                StreamWriter fajlIro = new StreamWriter(sfd.FileName);
                foreach  (Object aktObjektum in lblistaKetto.Items)
                {
                    fajlIro.WriteLine(aktObjektum.ToString());
                }
                fajlIro.Close();
            }
        }
    }
}
