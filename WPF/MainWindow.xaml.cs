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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
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

        private void Button_MouseEnter (object sender, MouseEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation (1, 1.2, new Duration (TimeSpan.FromSeconds (0.1)));

            ScaleTransform transform = new ScaleTransform ();
            Button.RenderTransform = transform;
            transform.CenterX = Button.ActualWidth / 2;
            transform.CenterY = Button.ActualHeight / 2;

            transform.BeginAnimation (ScaleTransform.ScaleXProperty, animation);
            transform.BeginAnimation (ScaleTransform.ScaleYProperty, animation);
        }

        private void Button_MouseLeave (object sender, MouseEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation (1.2, 1, new Duration (TimeSpan.FromSeconds (0.1)));

            ScaleTransform transform = new ScaleTransform ();
            Button.RenderTransform = transform;
            transform.CenterX = Button.ActualWidth / 2;
            transform.CenterY = Button.ActualHeight / 2;

            transform.BeginAnimation (ScaleTransform.ScaleXProperty, animation);
            transform.BeginAnimation (ScaleTransform.ScaleYProperty, animation);
        }
    }
}