using PlatinAppApi.Hespers;
using PlatinAppApi.Models;
using PlatinAppApi.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace PlatinAppApi
{
    public partial class InventarioPage : ContentPage
    {

        DataService dataService;
        public InventarioPage()
        {
            InitializeComponent();

            dataService = new DataService();
        }

        private string titulo;

        private string _codigocapturado;

        public string CodigoCapturado
        {
            get { return _codigocapturado; }
            set
            {
                _codigocapturado = value;

                lblCodigo.Text = CodigoCapturado;
            }
        }

        bool iniCapt = false;
        bool exibindoMsg = false;

        ZXingScannerPage scanPage = null;
        
        public async Task Capturar()
        {
            scanPage = await Util.CapturarCodigoAsync(scanPage, "Escanear Codigo", ZXing.BarcodeFormat.EAN_13);// QR_CODE);

            try
            {
                if (!iniCapt)
                {
                    scanPage.OnScanResult += (resut) =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            try
                            {
                                if (exibindoMsg)
                                {
                                    return;
                                }

                                scanPage.IsScanning = false;

                                if (!string.IsNullOrEmpty(CodigoCapturado))
                                {
                                    return;
                                }

                                Util.Vibrar();

                                CodigoCapturado = resut.Text;
                                await Navigation.PopModalAsync();


                                Inventario inventario = new Inventario
                                {
                                    InvCodigo = CodigoCapturado
                                //Categoria = txtCategoria.Text.Trim(),
                                //Preco = Convert.ToDecimal(txtPreco.Text)
                            };

                                await dataService.AddInventarioAsync(inventario);
                            }
                            catch (Exception ex)
                            {
                                exibindoMsg = true;
                                await this.DisplayAlert("Atenção", "Codigo invalido tente novamente !", "ok");
                                exibindoMsg = false;
                            }

                        });
                    };
                    iniCapt = true;
                }
                CodigoCapturado = "";
                await Navigation.PushModalAsync(scanPage);
            }
            catch(Exception e)
            {

            }
        }

        public async Task CapturarQRCode()
        {
            scanPage = await Util.CapturarCodigoAsync(scanPage, "Escanear Codigo", ZXing.BarcodeFormat.QR_CODE);// QR_CODE);

            try
            {
                if (!iniCapt)
                {
                    scanPage.OnScanResult += (resut) =>
                    {
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            try
                            {
                                if (exibindoMsg)
                                {
                                    return;
                                }

                                scanPage.IsScanning = false;

                                if (!string.IsNullOrEmpty(CodigoCapturado))
                                {
                                    return;
                                }

                                Util.Vibrar();

                                CodigoCapturado = resut.Text;
                                await Navigation.PopModalAsync();


                                //Inventario inventario = new Inventario
                                //{
                                //    InvCodigo = CodigoCapturado
                                //    //Categoria = txtCategoria.Text.Trim(),
                                //    //Preco = Convert.ToDecimal(txtPreco.Text)
                                //};

                                //await dataService.AddInventarioAsync(inventario);
                            }
                            catch (Exception ex)
                            {
                                exibindoMsg = true;
                                await this.DisplayAlert("Atenção", "Codigo invalido tente novamente !", "ok");
                                exibindoMsg = false;
                            }

                        });
                    };
                    iniCapt = true;
                }
                CodigoCapturado = "";
                await Navigation.PushModalAsync(scanPage);
            }
            catch (Exception e)
            {

            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Capturar();
        }

        private async void btnCapturaQrCode_Clicked(object sender, EventArgs e)
        {
            await CapturarQRCode();
        }

        async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VerCodigo());

        }

        async void btnTodosCodigos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new TodosCodigos());

        }
        
        async void btnVoltarMainPage_Clicked(object sender, EventArgs args)
        {
          await  Navigation.PushModalAsync(new MainPage());
        }

        async void btnGraficoPage_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new GraficoPage());
        }

    }
}
