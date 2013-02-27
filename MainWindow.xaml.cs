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

namespace simple_rename
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

        //close icon
        //close grid
        private void GMain_G_Close_MouseEnter(object sender, MouseEventArgs e)
        {
            GMain_G_Close.Background = new SolidColorBrush(Colors.White);
        }
        private void GMain_G_Close_MouseLeave(object sender, MouseEventArgs e)
        {
            GMain_G_Close.Background = null;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/close.png");
            image.EndInit();
            Gmain_GClose_Img_Close.Source = image;
        }

        //close image
        private void Gmain_GClose_Img_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GMain_G_Close.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 122, 204));

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/closew.png");
            image.EndInit();
            Gmain_GClose_Img_Close.Source = image;
        }
        private void Gmain_GClose_Img_Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Main.Close();
        }

        //maximize icon
        //maximize grid
        private void GMain_G_Max_MouseEnter(object sender, MouseEventArgs e)
        {
            //GMain_G_Max.Background = new SolidColorBrush(Colors.White);
        }
        private void GMain_G_Max_MouseLeave(object sender, MouseEventArgs e)
        {
            //GMain_G_Max.Background = null;

            //BitmapImage image = new BitmapImage();
            //image.BeginInit();
            //image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/max.png");
            //image.EndInit();
            //Gmain_GClose_Img_Max.Source = image;
        }

        //minimize icon
        //minimize grid
        private void GMain_G_Min_MouseEnter(object sender, MouseEventArgs e)
        {
            GMain_G_Min.Background = new SolidColorBrush(Colors.White);
        }
        private void GMain_G_Min_MouseLeave(object sender, MouseEventArgs e)
        {
            GMain_G_Min.Background = null;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/min.png");
            image.EndInit();
            Gmain_GClose_Img_Min.Source = image;
        }

        //minimize image
        private void Gmain_GClose_Img_Min_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GMain_G_Min.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 122, 204));

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/minw.png");
            image.EndInit();
            Gmain_GClose_Img_Min.Source = image;
        }
        private void Gmain_GClose_Img_Min_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            WindowState = WindowState.Minimized;
        }


        //Title bar
        private void GHead_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void Main_Activated(object sender, EventArgs e)
        {
            GHead.Background = new SolidColorBrush(Color.FromRgb(52, 180, 163));
            Main.BorderBrush = new SolidColorBrush(Color.FromRgb(52, 180, 163));
        }

        private void Main_Deactivated(object sender, EventArgs e)
        {
            GHead.Background = new SolidColorBrush(Color.FromRgb(235, 235, 235));
            Main.BorderBrush = new SolidColorBrush(Color.FromRgb(172, 172, 172));
        }





    }
}
