using AltoHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;



namespace DownloaderTaskClassWork
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static AutoResetEvent _workerEvent = new AutoResetEvent(false);

        public MainWindow()
        {
            InitializeComponent();
            App.mainWindow = this;
        }
        public static WebClient webC { get; set; }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var uri = new Uri(LinkTxtB.Text);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            string path = Path.GetFullPath(
                Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location,
                $@"..\..\..\Music\{filename}.mp3"));

            //
            var usercontrol = new progressUC(uri, path, filename);
            ListboxMain.Items.Add(usercontrol);


            //Original Working code
            //using (WebClient wc = new WebClient())
            //{
            //    wc.DownloadProgressChanged += wc_DownloadProgressChanged;
            //Burada eger data yukleyirikse Data/File seklinde yuklediyimize gore olani secirik
            //    wc.DownloadDataCompleted += Wc_DownloadDataCompleted;

            //    //First Param is link of file
            //    //Second Param is save adress 
            //    wc.DownloadFileAsync(uri, path);


            //    //Download Link For Test https://mp3semti.com/dinle/Mabel-Matiz-Antidepresan?indir=1
            //}
        }



        //For Test

        //private void WebC_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        //{
        //    MessageBox.Show("Test");
        //}

        //private void WebC_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        //{
        //    this.Close();
        //}

        //private void Wc_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
        //{
        //    MessageBox.Show("Music Downloaded Succesfully");

        //}

        //// Event to track the progress
        //void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    progressBar.Value = e.ProgressPercentage;
        //}


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var selectedItem = ListboxMain.SelectedItem as progressUC;
        //}
    }
}
