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

namespace lin_eindopdracht
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private controller controller;
        public MainWindow()
        {
            InitializeComponent();

            controller = new controller(canvas);

            this.KeyDown += new KeyEventHandler(OnButtonKeyDown);
        }

        private void OnButtonKeyDown(object sender, KeyEventArgs e)
        {
            Key k = e.Key;
            switch (k)
            {
                case Key.Up:
                    //move up
                    break;
                case Key.Down:
                    //move back
                    break;
                case Key.Left:
                    //move left
                    break;
                case Key.Right:
                    //move right
                    break;
                case Key.Q:
                    //Q
                    break;
                case Key.E:
                    //E
                    break; 
            }
        }
    }
}
