using PlatinAppApi.Models;
using PlatinAppApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace PlatinAppApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VerCodigo : ContentPage
    {
        List<Inventario> codigos;
        DataService dataService;

        public VerCodigo()
        {
            InitializeComponent();
            dataService = new DataService();
            AtualizaCodigos();
        }

        ZXingBarcodeImageView barcode1;
        ZXingBarcodeImageView barcode2;

        public void ExibirCodigos()
        {
            barcode1 = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };
            barcode1.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode1.BarcodeOptions.Width = 400;
            barcode1.BarcodeOptions.Height = 400;
            barcode1.BarcodeOptions.Margin = 0;
            barcode1.BarcodeValue = "http://www.youtube.com/ata275";
            meusCodigos.Children.Add(barcode1);

            barcode2 = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
                Margin = new Thickness(10)
            };
            barcode2.BarcodeFormat = ZXing.BarcodeFormat.EAN_13;
            barcode2.BarcodeOptions.Width = 400;
            barcode2.BarcodeOptions.Height = 400;
            barcode2.BarcodeOptions.Margin = 0;
            barcode2.BarcodeValue = "1232797466045";
            meusCodigos.Children.Add(barcode2);
        }

        private void listaCodigos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //var produto = e.SelectedItem as Product;
            //txtName.Text = produto.name;
            //txtCategoria.Text = produto.Categoria;
            //txtPreco.Text = produto.Preco.ToString();
        }
        async void AtualizaCodigos()
        {
            codigos = await dataService.GetInventarioAsync();
            listaCodigos.ItemsSource = codigos.OrderBy(item => item.InvCodigo).ToList();
        }

        async void btnVoltarInventarioPage_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new InventarioPage());
        }

        private async void OnDeletar(object sender, EventArgs e)
        {
            try
            {
                var mi = ((MenuItem)sender);
                Inventario codigoDeletar = (Inventario)mi.CommandParameter;
                await dataService.DeletaInventarioAsync(codigoDeletar);
                AtualizaCodigos();
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "OK");
            }
        }

    }
}