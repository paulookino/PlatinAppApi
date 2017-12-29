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
    public partial class GraficoPage : ContentPage
    {
        DataService dataService;
        List<Product> produtos;

        public GraficoPage()
        {

            InitializeComponent();
            dataService = new DataService();

            //Grafico.Chart = new Microcharts.BarChart() { Entries = lista };

            Grafico.Chart = new Microcharts.DonutChart() { Entries = lista };

        }


        async void btnVoltarInventarioPage_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new InventarioPage());
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
