using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using PlatinAppApi.Models;
using PlatinAppApi.Service;
using Newtonsoft.Json.Linq;
using SkiaSharp;

namespace PlatinAppApi
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        List<Product> produtos;

        public MainPage()
        {
            
            InitializeComponent();
            dataService = new DataService();

            //Grafico.Chart = new Microcharts.BarChart() { Entries = lista };

            AtualizaDados();

            Grafico.Chart = new Microcharts.DonutChart() { Entries = lista };

        }

        private async void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (Valida())
            {
                Product novoProduto = new Product
                {
                   name = txtName.Text.Trim(),
                    //Categoria = txtCategoria.Text.Trim(),
                    //Preco = Convert.ToDecimal(txtPreco.Text)
                };

                try
                {
                    await dataService.AddProdutoAsync(novoProduto);
                    LimpaProduto();
                    AtualizaDados();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Dados inválidos...", "OK");
            }
        }

        async void AtualizaDados()
        {
            produtos = await dataService.GetProdutosAsync();
            listaProdutos.ItemsSource = produtos.OrderBy(item => item.name).ToList();
        }

        private async void OnAtualizar(object sender, EventArgs e)
        {
            if (Valida())
            {
                try
                {
                    var mi = ((MenuItem)sender);
                    Product produtoAtualizar = (Product)mi.CommandParameter;

                    produtoAtualizar.name = txtName.Text;
                    //produtoAtualizar.Categoria = txtCategoria.Text;
                    //produtoAtualizar.Preco = Convert.ToDecimal(txtPreco.Text);

                    await dataService.UpdateProdutoAsync(produtoAtualizar);

                    LimpaProduto();
                    AtualizaDados();
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Erro", ex.Message, "OK");
                }
            }
            else
            {
                await DisplayAlert("Erro", "Dados inválidos...", "OK");
            }
        }

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Product produtoDeletar = (Product)mi.CommandParameter;
                await dataService.DeletaProdutoAsync(produtoDeletar);
                LimpaProduto();
                AtualizaDados();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void listaProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var produto = e.SelectedItem as Product;
            txtName.Text = produto.name;
            //txtCategoria.Text = produto.Categoria;
            //txtPreco.Text = produto.Preco.ToString();
        }

        private void LimpaProduto()
        {
            txtName.Text = "";
            //txtCategoria.Text = "";
            //txtPreco.Text = "";
        }

        private bool Valida()
        {
            //if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtCategoria.Text) && string.IsNullOrEmpty(txtPreco.Text))
            if (string.IsNullOrEmpty(txtName.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        List<Microcharts.Entry> lista = new List<Microcharts.Entry>
        {
            new Microcharts.Entry(200)
            {
                Label = "Produto 1",
                ValueLabel = "5",
                Color  =  SKColor.Parse("#FF00FF")

            },
              new Microcharts.Entry(250)
            {
                Label = "Produto 2",
                ValueLabel = "10",
                Color  =  SKColor.Parse("#0000CD")

            },
            new Microcharts.Entry(100)
            {
                Label = "Produto 3",
                ValueLabel = "3",
                Color  =  SKColor.Parse("#4B0082")

            },
            new Microcharts.Entry(150)
            {
                Label = "Produto 4",
                ValueLabel = "2",
                Color  =  SKColor.Parse("#800000")

            },
            new Microcharts.Entry(150)
            {
                Label = "Produto 5",
                ValueLabel = "8",
                Color  =  SKColor.Parse("#008080")

            }
        };
    }
}
