using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace Carubbi.GetFile.ClassLibrary
{
    public class RequisicaoWeb
    {
        private HttpWebRequest _request;
        private BinaryWriter _writer;

        public RequisicaoWeb(string url, string destino, int indicePasta, int indiceArquivo)
        {
            Url = url;
            Destino = destino;
            IndicePasta = indicePasta;
            IndiceArquivo = indiceArquivo;

        }

        public string Url
        {
            get;
            set;
        }

        public string Destino
        {
            get;
            set;
        }

        public int IndicePasta
        {
            get;
            set;
        }

        public int IndiceArquivo
        {
            get;
            set;
        }

     

        public void Requisitar()
        {
            _request = (HttpWebRequest)WebRequest.Create(ResolverCaminho(Url, IndicePasta, IndiceArquivo));
           _request.Method = "GET";
           _request.ContentType = "image/jpeg";
           WebResponse _response = _request.GetResponse();
           GravarArquivo(_response.GetResponseStream(), Destino, IndicePasta, IndiceArquivo);
        }

        


        private string ResolverCaminho(string caminho, int indicePasta, int indiceArquivo)
        {
            string caminhoRetorno = string.Empty;
            caminhoRetorno = caminho.Replace("[1]", indicePasta.ToString()).Replace("[2]", indiceArquivo.ToString());
            return caminhoRetorno;
        }

        private void GravarArquivo(Stream dados, string Destino, int indicePasta, int indiceArquivo)
        {
            string caminho = ResolverCaminho(Destino, indicePasta, indiceArquivo);

            string pasta = Path.GetDirectoryName(caminho);
            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            if (!File.Exists(caminho))
            {
                FileStream fs = File.Create(caminho);
                _writer = new BinaryWriter(fs);
                int Length = 256;
                Byte[] buffer = new Byte[Length];
                int bytesRead = dados.Read(buffer, 0, Length);
                // write the required bytes
                while (bytesRead > 0)
                {
                    _writer.Write(buffer, 0, bytesRead);
                    bytesRead = dados.Read(buffer, 0, Length);
                }
                _writer.Close();
                fs.Close();
            }
        
        }

    }
}
