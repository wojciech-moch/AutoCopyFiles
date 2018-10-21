using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace AutoCopyFiles
{
   /// <summary>
   /// Logika interakcji dla klasy MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();
      }

      private void Window_Loaded(object sender, RoutedEventArgs e)
      {
         FileSystemWatcher fsw = new FileSystemWatcher();
         fsw.Path = "D:\\test";
         fsw.NotifyFilter = NotifyFilters.LastWrite;
         fsw.Filter = "*.txt";
         fsw.Changed += Fsw_Changed;
         fsw.EnableRaisingEvents = true;
      }

      private void Fsw_Changed(object sender, FileSystemEventArgs e)
      {
         if (e.ChangeType == WatcherChangeTypes.Changed)
         {
            Dispatcher.BeginInvoke(DispatcherPriority.Background,
               new Action(() => lbxEvents.Items.Add($"Copied file {e.FullPath} to folder d:\\")));

            System.IO.File.Copy(e.FullPath, System.IO.Path.Combine("d:\\", e.Name), true);
         }  
            
      }
   }
}
