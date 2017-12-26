using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlatinAppApi.Models;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;
using static PlatinAppApi.Models.Product;
using System.Runtime.Serialization.Json;

namespace PlatinAppApi.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<Product>> GetProdutosAsync()
        {
            try
            {
                string url = "http://platinwebapi.somee.com/api/product/RetornaTodosProdutos";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<Product>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddProdutoAsync(Product produto)
        {
            try
            {
                

                string url = "http://localhost:49807/api/product/inserir/{0}";

                var uri = new Uri(string.Format(url, produto.id));

                var data = JsonConvert.SerializeObject(produto);
                var content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(uri, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir produto");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateProdutoAsync(Product produto)
        {
            string url = "http://localhost:49807/api/prdcab/editar/{0}";
            var uri = new Uri(string.Format(url, produto.id));

            var data = JsonConvert.SerializeObject(produto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;
            response = await client.PutAsync(uri, content);
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erro ao atualizar produto");
            }

        }

        public async Task DeletaProdutoPorIndiceAsync(int indice)
        {
            string url = "http://localhost:49807/api/product/excluir/{0}";
            await client.DeleteAsync(string.Concat(url, indice));
        }

        public async Task DeletaProdutoAsync(Product produto)
        {
            string url = "http://localhost:49807/api/product/excluir/{0}";
            var uri = new Uri(string.Format(url, produto.id));
            await client.DeleteAsync(uri);
        }
    }
}
