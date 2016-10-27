using Carubbi.GetFile.ClassLibrary;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Carubbi.GetFile.UI
{
    public partial class frmGetFile : Form
    {
        private static ManualResetEvent[] resetEvents;

        private int _indiceArquivo;
        private int _indicePasta;
        private bool hasFiles = true;
        public frmGetFile()
        {
            InitializeComponent();
            
        }
      


        private void btnRequisitar_Click(object sender, EventArgs e)
        {

            ThreadPool.SetMaxThreads(5, 5);
            
            int pastaDe = Convert.ToInt32(txtPastaDe.Text);
            int availableThreadsCount, completionPortThreads;
          
            _indicePasta = pastaDe;
            _indiceArquivo = 1;
            while (hasFiles)
            {
                FlushLog();
                ThreadPool.GetAvailableThreads(out availableThreadsCount, out completionPortThreads);
                if (availableThreadsCount > 0)
                {
                    WaitCallback callBack = new WaitCallback(CallBackRequisicao);
                    ThreadPool.QueueUserWorkItem(CallBackRequisicao, new object[] { _indiceArquivo++, _indicePasta, txtUrl.Text, txtDestino.Text});
                }
                Thread.Sleep(500);
            }


            //    
            //while(hasFiles)
            //{
            //    int availableThreadsCount, completionPortThreads;
            //    ThreadPool.GetAvailableThreads(out availableThreadsCount, out completionPortThreads);
                 
            //    if (availableThreadsCount > 0)
            //    {
            //       resetEvents[availableThreadsCount-1] = new ManualResetEvent(false);
            //       WaitCallback callBack = new WaitCallback(CallBackRequisicao);
            //       ThreadPool.QueueUserWorkItem(CallBackRequisicao, _indiceArquivo++);
            //       Thread.Sleep(999999999);
            //    }
                
            //}
         

            
            AddLog("------- Requisição concluída ------");
            
        }

        void CallBackRequisicao(object parameters)
        {

            int indiceArquivo = (int)((object[])parameters)[0];
            int indicePasta = (int)((object[])parameters)[1];
            string url = (string)((object[])parameters)[2];
            string destino = (string)((object[])parameters)[3];
            try
            {
                RequisicaoWeb requisicao = new RequisicaoWeb(url, destino, indicePasta, indiceArquivo);
                requisicao.Requisitar();
                AddLog(string.Format("pasta {0} - arquivo {1} gravado com sucesso", indicePasta, indiceArquivo));
            }
            catch
            {
                AddLog(string.Format(" ------ Proxima pasta - {0} -------", indicePasta + 1));
                Interlocked.Increment(ref _indicePasta);
                int pastaAte = Convert.ToInt32(txtPastaAte.Text);
                if (_indicePasta > pastaAte)
                {
                    lock (this)
                    {
                        hasFiles = false;
                    }
                }
            }
        }


        List<string> Log = new List<string>();
        private void AddLog(string mensagem)
        {
            Log.Add(mensagem);
        }

        private void FlushLog()
        {
            foreach (string mensagem in Log)
                lstLog.Items.Insert(0, mensagem);
        }

      
        #region hiddenFeatures
        bool muda = false;
        private void lblLinks_DoubleClick(object sender, EventArgs e)
        {
            txtDestino.Text = @"C:\teste\[1]\[2].jpg";
            if (muda)
            {

                txtUrl.Text = "http://www.cnnamador.com/img/[1]/photos/[2].jpg";
            }
            else
            {
                txtUrl.Text = "Http://www.qualitypage.com/asians/[1]/[2].jpg";
            }
            muda = !muda;
        }
        #endregion

    }
}
