using Carubbi.Extensions;
using Carubbi.GetFile.ClassLibrary;
using Carubbi.ServiceLocator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Carubbi.GetFile.UI
{
    public partial class FrmGetFile : Form
    {
     
        private List<IUrlParser> _plugins;
        private bool _isIdle;
        public FrmGetFile()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (_isIdle)
            {
                _isIdle = false;
                btnDownload.Text = "Cancel";
                downloadTask.RunWorkerAsync(new object[] { cboSource.SelectedItem.ToString(), txtTerm.Text, txtQuantity.Text });
            }
            else
            {
                downloadTask.CancelAsync();
                btnDownload.Enabled = false;
            }
        }

        private void DownloadTask_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnDownload.Enabled = true;
            Done();
        }

        private void Done()
        {
            btnDownload.Text = "Download";
            AddLog("------- Requisição concluída ------");
            FlushLog();
            _isIdle = true;
        }

        private void DownloadTask_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            FlushLog();
        }

        private void DownloadTask_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var parameters = (object[]) e.Argument;

            Start(parameters[0].ToString(), parameters[1].ToString(), parameters[2].To(0));
        }

        private void Start(string parserName, string term, int quantity)
        {
            var selectedSource = _plugins.FirstOrDefault(p => p.Name == parserName);
            AddLog("Parsing sources...");
            downloadTask.ReportProgress(1);
            var files = selectedSource.Parse(term, quantity);
            ThreadPool.SetMaxThreads(5, 5);

            foreach (var file in files)
            {
                if (downloadTask.CancellationPending)
                {
                    break;
                }

                downloadTask.ReportProgress(50);
                var availableThreads = 0;
                do
                {
                    Thread.Sleep(200);
                    ThreadPool.GetAvailableThreads(out var availableThreadsCount, out _);
                    availableThreads = availableThreadsCount;
                } while (availableThreads == 0);

                var unused = new WaitCallback(CallBackRequisicao);
                ThreadPool.QueueUserWorkItem(CallBackRequisicao, new object[] { file, txtDestination.Text });
            }
        }

        private void CallBackRequisicao(object parameters)
        {
            var arguments = (object[])parameters;
            var file = (DownloadInfo)arguments[0];
            var destination = (string)arguments[1];
            var output = Path.Combine(destination, file.OutputFileName);
            try
            {
                var downloader = new Downloader(file.Url, output) ;
                downloader.Download();

                if (!downloadTask.CancellationPending)
                    AddLog($"File saved from {file.Url} to {output}");

            }
            catch (Exception ex)
            {
                if (!downloadTask.CancellationPending)
                    AddLog($" ------ Error: {ex.Message} -------");
            }
        }

        private readonly List<string> _log = new List<string>();

        private void AddLog(string mensagem)
        {
            _log.Add(mensagem);
        }

        private void FlushLog()
        {

            foreach (var mensagem in _log)
                lstLog.Items.Insert(0, mensagem);

            _log.Clear();
        }

        private void FrmGetFile_Load(object sender, EventArgs e)
        {
            _isIdle = true;
            LoadSources();
        }

        private void LoadSources()
        {
            downloadTask.DoWork += DownloadTask_DoWork;
            downloadTask.ProgressChanged += DownloadTask_ProgressChanged;
            downloadTask.RunWorkerCompleted += DownloadTask_RunWorkerCompleted;
            _plugins = ImplementationResolver.GetPlugins<IUrlParser>();
            cboSource.DataSource = _plugins.Select(p => p.Name).ToList();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            _log.Clear();
            lstLog.Items.Clear();
        }
    }
}
