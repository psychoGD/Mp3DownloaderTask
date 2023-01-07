using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using System.Windows.Shapes;

namespace DownloaderTaskClassWork
{
    /// <summary>
    /// Interaction logic for progressUC.xaml
    /// </summary>
    public partial class progressUC : UserControl
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public Uri uri { get; set; }
        public string path { get; set; }
        private Task task { get; set; }

        private static AutoResetEvent _workerEvent = new AutoResetEvent(false);
        public progressUC(Uri uri,string path,string filename)
        {
            InitializeComponent();
            this.DataContext = DataContext;
            FileName = filename;
            this.uri = uri;
            this.path = path;

            Start();
        }

        private void Start()
        {
            using (WebClient wc = new WebClient())
            {
                wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(wc_DownloadProgressChanged);
                wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                
                //First Param is link of file
                //Second Param is save adress 
                wc.DownloadFileAsync(uri, this.path);
                
                //Download Link For Test https://mp3semti.com/dinle/Mabel-Matiz-Antidepresan?indir=1
            }
        }

        private void Wc_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Music Downloaded Succesfully");
            App.mainWindow.ListboxMain.Items.Remove(this);
        }

        // Event to track the progress
        void wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }
    }
}
