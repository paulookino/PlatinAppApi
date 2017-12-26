using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using PlatinAppApi.Models;

namespace PlatinAppApi.Service
{
    public class DataService
    {
        HttpClient client = new HttpClient();

        public async Task<List<PrdCab>> GetProdutosAsync()
        {
            try
            {
                string url = "http://localhost:49807/api/prdcab/listar";
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<PrdCab>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddProdutoAsync(PrdCab produto)
        {
            try
            {
                

                string url = "http://localhost:49807/api/prdcab/inserir/{0}";

                var uri = new Uri(string.Format(url, produto.Ide));

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

        public async Task UpdateProdutoAsync(PrdCab produto)
        {
            string url = "http://localhost:49807/api/prdcab/editar/{0}";
            var uri = new Uri(string.Format(url, produto.Ide));

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
            string url = "http://localhost:49807/api/prdcab/excluir/{0}";
            await client.DeleteAsync(string.Concat(url, indice));
        }

        public async Task DeletaProdutoAsync(PrdCab produto)
        {
            string url = "http://localhost:49807/api/prdcab/excluir/{0}";
            var uri = new Uri(string.Format(url, produto.Ide));
            await client.DeleteAsync(uri);
        }
    }
}
