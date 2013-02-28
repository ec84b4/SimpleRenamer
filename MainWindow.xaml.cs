using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Button = System.Windows.Controls.Button;
using CheckBox = System.Windows.Controls.CheckBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;
using TextBox = System.Windows.Controls.TextBox;
using System.IO;

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

        //Main Window
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



        //codes start from here above is for graphic things.



        //For all part of program
        private string Path = "";

        bool IsDirectoryExist(string path)
        {
            return Directory.Exists(path);
        }

        private void ButtonVisibility(Button button)
        {
            if (Equals(button, Replace_Btn_Rename))
            {
                if (Directory.Exists(Path) && Replace_Tb_Source.Text != "" &&
                    (Replace_Cb_RenameFile.IsChecked == true || Replace_Cb_RenameFolder.IsChecked == true))
                {
                    button.IsEnabled = true;
                }
                else
                {
                    button.IsEnabled = false;
                }
            }
            else
            {
                if (Directory.Exists(Path) && Add_Tb_Source.Text != "" &&
                    (Add_Cb_RenameFile.IsChecked == true || Add_Cb_RenameFolder.IsChecked == true))
                {
                    button.IsEnabled = true;
                }
                else
                {
                    button.IsEnabled = false;
                }
            }
        }

        private void DisableProcessBtn(Button processBtn, TextBox sourceTb)
        {
            //While source TextBox is empty Rename Button will be disable.
            if (sourceTb.Text != "" && Equals(sourceTb, Path_Tb_Path))
                processBtn.IsEnabled = IsDirectoryExist(sourceTb.Text);
            else
                processBtn.IsEnabled = sourceTb.Text != "";
        }

        private void DisableProcessBtn(Button processBtn, CheckBox checkBoxFile, CheckBox checkBoxFolder)
        {
            //disable rename button if none of CheckBoxes about file and folder rename is checked.
            processBtn.IsEnabled = checkBoxFile.IsChecked == true || checkBoxFolder.IsChecked == true;
        }

        private void ProcessBtn_ToolTip(Button processBtn, CheckBox checkBoxFile, CheckBox checkBoxFolder)
        {
            //set ToolTip for Rename Buttons According to check boxes.
            string toolTipText = checkBoxFile.IsChecked == true && checkBoxFolder.IsChecked == true
                                     ? "Rename the name of Files and Folders"
                                     : checkBoxFile.IsChecked == true && checkBoxFolder.IsChecked == false
                                           ? "Rename the name of Files"
                                           : checkBoxFile.IsChecked == false && checkBoxFolder.IsChecked == true
                                                 ? "Rename the name of Folders"
                                                 : "";
            processBtn.ToolTip = toolTipText;
        }


        //Main Window
        private void Main_Loaded(object sender, RoutedEventArgs e)
        {
            Path_Tb_Path.Focus();

            ProcessBtn_ToolTip(Replace_Btn_Rename, Replace_Cb_RenameFile, Replace_Cb_RenameFolder);//Set ToolTip for Rename Button.
            ProcessBtn_ToolTip(Add_Btn_Rename, Add_Cb_RenameFile, Add_Cb_RenameFolder);//Set ToolTip for Rename Button.

        }


        //Path Part
        private void Path_Btn_SourceDir_Click(object sender, RoutedEventArgs e)
        {
            //by clicking the 'Source Folder' button a dialog opens to you can choose a directory.
            var selectPathDialog = new FolderBrowserDialog();
            DialogResult selectPathResult = selectPathDialog.ShowDialog();

            if (selectPathResult != System.Windows.Forms.DialogResult.OK) return;
            Path = selectPathDialog.SelectedPath;
            Path_Tb_Path.Text = Path;
        }
        private void Path_Tb_Path_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Path_Lbl_FakePath.Visibility = Path_Tb_Path.Text == "" ? Visibility.Visible : Visibility.Hidden; //if TextBox is not empty the label will be invisible

            Path_Tb_Path.TabIndex = Path_Tb_Path.Text == "" ? 1 : 2; //if TextBox is not empty when you press tab key it'll skip the 'Source Directory' button.

            ButtonVisibility(Replace_Btn_Rename);
            ButtonVisibility(Add_Btn_Rename);
        }
        private void Path_Lbl_FakePath_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Path_Tb_Path.Focus();//when you click on the text TextBox will be active
        }
        private void Path_Lbl_FakePath_MouseEnter(object sender, MouseEventArgs e)
        {
            Path_Tb_Path.BorderBrush = new SolidColorBrush(Color.FromRgb(86, 157, 229));
        }
        private void Path_Lbl_FakePath_MouseLeave(object sender, MouseEventArgs e)
        {
            Path_Tb_Path.BorderBrush = new SolidColorBrush(Color.FromRgb(202, 202, 202));

        }


        //Replace Part
        private void Replace_Tb_Source_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Replace_Lbl_FakeSource.Visibility = Replace_Tb_Source.Text == "" ? Visibility.Visible : Visibility.Hidden;//if source TextBox is not empty the label on the TextBox will be invisible

            ButtonVisibility(Replace_Btn_Rename);
        }
  /**/      private void Replace_Tb_Source_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter && Replace_Tb_Source.Text != "" &&Path_Tb_Path.Text)
            //{
            //    Replace_Btn_Rename_Click(sender, e);
            //}
        }
        private void Replace_Lbl_FakeSource_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Replace_Tb_Source.Focus();//when you click on the text TextBox will be active
        }
        private void Replace_Lbl_FakeSource_MouseEnter(object sender, MouseEventArgs e)
        {
            Replace_Tb_Source.BorderBrush = new SolidColorBrush(Color.FromRgb(86, 157, 229));
        }
        private void Replace_Lbl_FakeSource_MouseLeave(object sender, MouseEventArgs e)
        {
            Replace_Tb_Source.BorderBrush = new SolidColorBrush(Color.FromRgb(202, 202, 202));
        }


        private void Replace_tb_Target_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            Replace_Lbl_FakeTarget.Visibility = Replace_Tb_Target.Text == "" ? Visibility.Visible : Visibility.Hidden;//if target TextBox is not empty the label on the TextBox will be invisible
        }
  /**/      private void Replace_tb_Target_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void Replace_Lbl_FakeTarget_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Replace_Tb_Target.Focus();//when you click on the label TextBox will be active
        }
        private void Replace_Lbl_FakeTarget_MouseEnter(object sender, MouseEventArgs e)
        {
            Replace_Tb_Target.BorderBrush = new SolidColorBrush(Color.FromRgb(86, 157, 229));
        }
        private void Replace_Lbl_FakeTarget_MouseLeave(object sender, MouseEventArgs e)
        {
            Replace_Tb_Target.BorderBrush = new SolidColorBrush(Color.FromRgb(202, 202, 202));
        }

        private void Replace_Cb_RenameFile_Click(object sender, RoutedEventArgs e)
        {
            //Rename Button ToolTip according to the file and folder CheckBocxes
            ProcessBtn_ToolTip(Replace_Btn_Rename, Replace_Cb_RenameFile, Replace_Cb_RenameFolder);

            ButtonVisibility(Replace_Btn_Rename);
        }


        private void Replace_Cb_RenameFolder_Click(object sender, RoutedEventArgs e)
        {
            //Rename Button ToolTip according to the file and folder CheckBocxes
            ProcessBtn_ToolTip(Replace_Btn_Rename, Replace_Cb_RenameFile, Replace_Cb_RenameFolder);

            ButtonVisibility(Replace_Btn_Rename);
        }

        private void Replace_Btn_Clear_Click(object sender, RoutedEventArgs e)
        {
            Replace_Tb_Source.Text = "";
            //Replace_Lbl_FakeSource.Content = "Source Keyword";
            Replace_Tb_Target.Text = "";
            //Replace_Lbl_FakeTarget.Content = "Target Keyword";
            Replace_Cb_RenameFile.IsChecked = true;
            Replace_Cb_RenameFolder.IsChecked = false;
            Replace_Rb_CurrentDir.IsChecked = true;

            //DisableProcessBtn(Replace_Btn_Rename, Replace_Cb_RenameFile, Replace_Cb_RenameFolder);
        }



















    }
}
