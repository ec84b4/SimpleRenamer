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
using System.Windows.Shapes;
using System.Collections;
using simple_rename;
using CheckBox = System.Windows.Controls.CheckBox;
using MessageBox = System.Windows.MessageBox;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Simple_Renamer
{
    /// <summary>
    /// Interaction logic for AskToReplace.xaml
    /// </summary>
    public partial class AskToReplace : Window
    {
        public AskToReplace()
        {
            InitializeComponent();
        }
        

        private void GClose_Img_Close_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GClose.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 122, 204));

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/closew.png");
            image.EndInit();
            GClose_Img_Close.Source = image;
        }

        private void GClose_Img_Close_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AskFrom.Close();
        }

        private void GClose_MouseLeave(object sender, MouseEventArgs e)
        {
            GClose.Background = null;

            BitmapImage image = new BitmapImage();
            image.BeginInit();
            image.UriSource = new Uri("pack://siteoforigin:,,,/Resources/close.png");
            image.EndInit();
            GClose_Img_Close.Source = image;
        }

        private void GClose_MouseEnter(object sender, MouseEventArgs e)
        {
            GClose.Background = new SolidColorBrush(Colors.White);
        }

        private void GHeader_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }




        public void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilesList.Items.Count > 1)
                while (FilesList.Items.Count > 1)
                {
                    for (int i = 1; i < FilesList.Items.Count; i++)
                    {
                        FilesList.Items.RemoveAt(i);
                    }                    
                }

        }

        public string AskPath = "";
        public bool RenameFileIsChecked = false;
        public bool RenameFolderIsChecked = false;
        public bool UseCurrentDirIsChecked = false;
        public string Tb_Source;
        public string Tb_Target;
        public bool IsReplace = true; //is it from Replace part or add part true = replace  false = Add
        public bool IsAddToEnd = true;
        public int Result = 0;


        private void AskFrom_Loaded(object sender, RoutedEventArgs e)
        {
            if (IsReplace)
                AddCheckBoxesReplace();
            else
                AddCheckBoxesAdd();
        }

        private void AddCheckBoxesReplace()
        {
            MainWindow main = new MainWindow();
            string path = AskPath;
            var dirinfo = new DirectoryInfo(path);
            var entries = dirinfo.GetFileSystemInfos("**",
                                                     UseCurrentDirIsChecked
                                                         ? SearchOption.TopDirectoryOnly
                                                         : SearchOption.AllDirectories);

            for (int i = 0; i < entries.Count(); i++)
            {
                if (Directory.Exists(entries[i].FullName) && RenameFolderIsChecked && entries[i].Name.Contains(Tb_Source))
                {
                    FilesList.Items.Add(new CheckBox {/* Name = namess[i],*/ Content = entries[i].FullName, MinWidth = 405, IsChecked = true });
                }
                else if (RenameFileIsChecked && Directory.Exists(entries[i].FullName) == false && entries[i].Name.Contains(Tb_Source))
                {
                    FilesList.Items.Add(new CheckBox {/* Name = namess[i],*/ Content = entries[i].FullName, MinWidth = 405, IsChecked = true });
                }
            }


            Result = FilesList.Items.OfType<CheckBox>().Count(i => i.IsChecked == true) - 1;
            Lbl_TEXT.Content = "There is '" + Result + "' " + FileOrFolderText() + " To rename, select the " +
                               FileOrFolderText() + " you want to rename.";
        }

        private void AddCheckBoxesAdd()
        {
            MainWindow main = new MainWindow();
            string path = AskPath;
            var dirinfo = new DirectoryInfo(path);
            var entries = dirinfo.GetFileSystemInfos("**",
                                                     UseCurrentDirIsChecked
                                                         ? SearchOption.TopDirectoryOnly
                                                         : SearchOption.AllDirectories);

            for (int i = 0; i < entries.Count(); i++)
            {
                if (Directory.Exists(entries[i].FullName) && RenameFolderIsChecked)
                {
                    FilesList.Items.Add(new CheckBox {/* Name = namess[i],*/ Content = entries[i].FullName, MinWidth = 405, IsChecked = true });
                }
                else if (RenameFileIsChecked && Directory.Exists(entries[i].FullName) == false)
                {
                    FilesList.Items.Add(new CheckBox {/* Name = namess[i],*/ Content = entries[i].FullName, MinWidth = 405, IsChecked = true });
                }
            }


            Result = FilesList.Items.OfType<CheckBox>().Count(i => i.IsChecked == true) - 1;
            Lbl_TEXT.Content = "There is '" + Result + "' " + FileOrFolderText() + " To rename, select the " +
                               FileOrFolderText() + " you want to rename.";
        }


        string FileOrFolderText()
        {
            return RenameFolderIsChecked && RenameFileIsChecked
                       ? "File and Folder"
                       : RenameFileIsChecked && !RenameFolderIsChecked
                             ? "Files"
                             : !RenameFileIsChecked && RenameFolderIsChecked ? "Folders" : "File/Folder";
        }

        private void List_Cb_SelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (object item in FilesList.Items)
            {
                CheckBox checkBox = item as CheckBox;
                checkBox.IsChecked = false;
            }
        }

        private void List_Cb_SelectAll_Checked(object sender, RoutedEventArgs e)
        {
            foreach (object item in FilesList.Items)
            {
                CheckBox checkBox = item as CheckBox;
                checkBox.IsChecked = true;
            }
        }

        private void Btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            //string path = AskPath;
            //var dirinfo = new DirectoryInfo(path);
            //var entries = dirinfo.GetFileSystemInfos("**",
            //                                         UseCurrentDirIsChecked
            //                                             ? SearchOption.TopDirectoryOnly
            //                                             : SearchOption.AllDirectories);
            ////foreach (CheckBox checkBox in FilesList.Items.Cast<object>().Select(item => item as CheckBox).Where(checkBox => checkBox != null && checkBox.IsChecked == true))
            //foreach (object item in FilesList.Items)
            //{
            //    CheckBox checkBox = item as CheckBox;
            //    if (checkBox == null || checkBox.IsChecked != true) continue;
            //    for (int i = 0; i < entries.Count(); i++)
            //    {
            //        if ((string)checkBox.Content != entries[i].FullName) continue;
            //        string newName = entries[i].Name.Replace(Tb_Source, Tb_Target);
            //        int newnameLength = entries[i].FullName.Length - entries[i].Name.Length;
            //        string newFullName = entries[i].FullName.Remove(newnameLength) + newName;
            //        if (Directory.Exists(entries[i].FullName) && entries[i].FullName != newFullName && RenameFolderIsChecked)
            //        {
            //            Directory.Move(checkBox.Content.ToString(), newFullName);
            //        }
            //        else if (entries[i].FullName != newFullName && RenameFileIsChecked &&
            //                 Directory.Exists(entries[i].FullName) == false)
            //        {
            //            File.Move(checkBox.Content.ToString(), newFullName);
            //        }
            //    }
            //}
            AskFrom.Close();
        }

        private void RenameReplace()
        {
            Result = FilesList.Items.OfType<CheckBox>().Count(i => i.IsChecked == true) - 1;
            MessageBoxResult ask =
                MessageBox.Show(
                    "'" + Result.ToString() + "' " + FileOrFolderText() +
                    " are selected are you sure you want to rename them ?", "Simple Renamer", MessageBoxButton.YesNo,
                    MessageBoxImage.Information);
            if (ask == MessageBoxResult.No) return;

            string path = AskPath;
            var dirinfo = new DirectoryInfo(path);
            var entries = dirinfo.GetFileSystemInfos("**",
                                                     UseCurrentDirIsChecked
                                                         ? SearchOption.TopDirectoryOnly
                                                         : SearchOption.AllDirectories);
            //foreach (CheckBox checkBox in FilesList.Items.Cast<object>().Select(item => item as CheckBox).Where(checkBox => checkBox != null && checkBox.IsChecked == true))
            foreach (object item in FilesList.Items)
            {
                CheckBox checkBox = item as CheckBox;
                if (checkBox == null || checkBox.IsChecked != true) continue;
                for (int i = 0; i < entries.Count(); i++)
                {
                    if ((string)checkBox.Content != entries[i].FullName) continue;
                    string newName = entries[i].Name.Replace(Tb_Source, Tb_Target);
                    int newnameLength = entries[i].FullName.Length - entries[i].Name.Length;
                    string newFullName = entries[i].FullName.Remove(newnameLength) + newName;
                    if (Directory.Exists(entries[i].FullName) && entries[i].FullName != newFullName && RenameFolderIsChecked)
                    {
                        Directory.Move(entries[i].FullName, entries[i].FullName + "1");
                        Directory.Move(entries[i].FullName + "1", newFullName);
                    }
                    else if (entries[i].FullName != newFullName && RenameFileIsChecked &&
                             Directory.Exists(entries[i].FullName) == false)
                    {
                        File.Move(entries[i].FullName, entries[i].FullName + "1");
                        File.Move(entries[i].FullName + "1", newFullName);
                    }
                }
            }

            MessageBox.Show("'" + Result.ToString() + "' " + FileOrFolderText() + " successfully renamed!",
                            "Simple Renamer", MessageBoxButton.OK, MessageBoxImage.Information);
            AskFrom.Close();
        }

        private void RenameAdd()
        {
            Result = FilesList.Items.OfType<CheckBox>().Count(i => i.IsChecked == true) - 1;
            MessageBoxResult ask =
                MessageBox.Show(
                    "'" + Result.ToString() + "' " + FileOrFolderText() +
                    " are selected are you sure you want to rename them ?", "Simple Renamer", MessageBoxButton.YesNo,
                    MessageBoxImage.Information);
            if (ask == MessageBoxResult.No) return;

            string path = AskPath;
            var dirinfo = new DirectoryInfo(path);
            var entries = dirinfo.GetFileSystemInfos("**",
                                                     UseCurrentDirIsChecked
                                                         ? SearchOption.TopDirectoryOnly
                                                         : SearchOption.AllDirectories);
            //foreach (CheckBox checkBox in FilesList.Items.Cast<object>().Select(item => item as CheckBox).Where(checkBox => checkBox != null && checkBox.IsChecked == true))
            foreach (object item in FilesList.Items)
            {
                CheckBox checkBox = item as CheckBox;
                if (checkBox == null || checkBox.IsChecked != true) continue;
                for (int i = 0; i < entries.Count(); i++)
                {
                    if ((string)checkBox.Content != entries[i].FullName) continue;
                    string nameOfFformat = System.IO.Path.GetExtension(entries[i].FullName);
                    string nameOfFirst = entries[i].Name.Substring(0 ,entries[i].Name.Length - nameOfFformat.Length);
                    string newName = IsAddToEnd
                                         ? nameOfFirst + Tb_Source + nameOfFformat
                                         : Tb_Source + entries[i].Name;
                    int newnameLength = entries[i].FullName.Length - entries[i].Name.Length;
                    string newFullName = entries[i].FullName.Remove(newnameLength) + newName;
                    if (Directory.Exists(entries[i].FullName) && entries[i].FullName != newFullName && RenameFolderIsChecked)
                    {
                        Directory.Move(entries[i].FullName, entries[i].FullName + "1");
                        Directory.Move(entries[i].FullName + "1", newFullName);
                    }
                    else if (entries[i].FullName != newFullName && RenameFileIsChecked && Directory.Exists(entries[i].FullName) == false)
                    {
                        File.Move(entries[i].FullName, entries[i].FullName + "1");
                        File.Move(entries[i].FullName + "1", newFullName);
                    }
                }
            }

            MessageBox.Show("'" + Result.ToString() + "' " + FileOrFolderText() + " successfully renamed!",
                            "Simple Renamer", MessageBoxButton.OK, MessageBoxImage.Information);
            AskFrom.Close();

        }

        private void Btn_Rename_Click(object sender, RoutedEventArgs e)
        {
            if (IsReplace)
                RenameReplace();
            else
                RenameAdd();

        }




    }
}
