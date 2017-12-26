using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using PlatinAppApi.Models;
using PlatinAppApi.Service;

namespace PlatinAppApi
{
    public partial class MainPage : ContentPage
    {
        DataService dataService;
        List<PrdCab> produtos;

        public MainPage()
        {
            
            InitializeComponent();
            dataService = new DataService();
            AtualizaDados();
        }

        private async void btnAdicionar_Clicked(object sender, EventArgs e)
        {
            if (Valida())
            {
                PrdCab novoProduto = new PrdCab
                {
                    Des = txtDes.Text.Trim(),
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
            listaProdutos.ItemsSource = produtos.OrderBy(item => item.Des).ToList();
        }

        private async void OnAtualizar(object sender, EventArgs e)
        {
            if (Valida())
            {
                try
                {
                    var mi = ((MenuItem)sender);
                    PrdCab produtoAtualizar = (PrdCab)mi.CommandParameter;

                    produtoAtualizar.Des = txtDes.Text;
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
                PrdCab produtoDeletar = (PrdCab)mi.CommandParameter;
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
            var produto = e.SelectedItem as PrdCab;
            txtDes.Text = produto.Des;
            //txtCategoria.Text = produto.Categoria;
            //txtPreco.Text = produto.Preco.ToString();
        }

        private void LimpaProduto()
        {
            txtDes.Text = "";
            //txtCategoria.Text = "";
            //txtPreco.Text = "";
        }

        private bool Valida()
        {
            //if (string.IsNullOrEmpty(txtNome.Text) && string.IsNullOrEmpty(txtCategoria.Text) && string.IsNullOrEmpty(txtPreco.Text))
            if (string.IsNullOrEmpty(txtDes.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
