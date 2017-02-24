using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LojaAPIClient
{
    class Program
    {

        static void Main(string [] args)
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:30176/api/carrinho/1");
            request.Method = "POST";

            string xml = "<Carrinho xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns='http://schemas.datacontract.org/2004/07/Loja.Models'><Endereco i:nil='true'/><Id>1</Id><Produtos><Produto><Id>123</Id><Nome>Produto criado com POST</Nome><Preco>100</Preco><Quantidade>1</Quantidade></Produto></Produtos></Carrinho> ";

            byte[] xmlbytes = Encoding.UTF8.GetBytes(xml);
            request.GetRequestStream().Write(xmlbytes, 0, xmlbytes.Length);

            request.ContentType = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.WriteLine(conteudo);
            Console.Read();

        }

        static void TestPOSTJson(string[] args)
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:30176/api/carrinho/1");
            request.Method = "POST";

            string json = "{'Produtos':[{'Id':6237,'Preco':4000.0,'Nome':'Xbox','Quantidade':3}],'Endereço':'Rua Vergueiro 3185, 8 andar, Sao Paulo','Id':2}";

            byte[] jsonbytes = Encoding.UTF8.GetBytes(json);
            request.GetRequestStream().Write(jsonbytes, 0, jsonbytes.Length);

            request.ContentType = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.WriteLine(conteudo);
            Console.Read();

        }

        static void TestGet(string[] args)
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:30176/api/carrinho/1");
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.WriteLine(conteudo);
            Console.Read();

        }

        static void TestGetJson(string[] args)
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:30176/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/json";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.WriteLine(conteudo);
            Console.Read();

        }

        static void TestGetXML(string[] args)
        {
            string conteudo;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:30176/api/carrinho/1");
            request.Method = "GET";
            request.Accept = "application/xml";

            WebResponse response = request.GetResponse();
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                conteudo = reader.ReadToEnd();
            }

            Console.WriteLine(conteudo);
            Console.Read();

        }

    }
}
