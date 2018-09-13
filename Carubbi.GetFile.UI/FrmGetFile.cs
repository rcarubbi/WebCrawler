using Carubbi.GetFile.ClassLibrary;
using Carubbi.ImageDownloader;
using Carubbi.ServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Carubbi.GetFile.UI
{
    public partial class FrmGetFile : Form
    {
        private List<IUrlParser> _plugins;

        public FrmGetFile()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            var selectedSource = _plugins.FirstOrDefault(p => p.Name == cboSource.SelectedItem.ToString());
            var quantity = int.Parse(txtQuantity.Text);
            ThreadPool.SetMaxThreads(5, 5);
            var files = selectedSource.Parse(txtTerm.Text, quantity);
            foreach (var file in files)
            {
                FlushLog();
                ThreadPool.GetAvailableThreads(out var availableThreadsCount, out _);
                if (availableThreadsCount > 0)
                {
                    var unused = new WaitCallback(CallBackRequisicao);
                    ThreadPool.QueueUserWorkItem(CallBackRequisicao, new object[] { file, txtDestination.Text });
                }
                Thread.Sleep(200);
            }

            AddLog("------- Requisição concluída ------");   
        }

        private void CallBackRequisicao(object parameters)
        {
            var arguments = (object[])parameters;
            var file = (string)arguments[0];
            var destination = (string)arguments[1];
            try
            {
                var downloader = new Downloader(file, destination);
                downloader.Download();
                AddLog($"File saved from {file} to {destination}");
            }
            catch(Exception ex)
            {
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
        }

        private void FrmGetFile_Load(object sender, EventArgs e)
        {
            LoadSources();
        }

        private void LoadSources()
        {
           _plugins = ImplementationResolver.GetPlugins<IUrlParser>();
            cboSource.DataSource = _plugins.Select(p => p.Name).ToList();
        }
    }
}
