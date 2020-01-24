using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MiPrimeraAppPGL
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Inicializar();
        }

        private void Inicializar()
        {
            btntexto.Clicked += Btntexto_Clicked;
            btnotrapagina.Clicked += Btnotrapagina_Clicked;
            btntexto2.Clicked += Btntexto2_Clicked;
        }

        private void Btntexto2_Clicked(object sender, EventArgs e)
        {
            metodo2();
        }

        private void Btnotrapagina_Clicked(object sender, EventArgs e)
        {
            //otra pagina
            Navigation.PushAsync(new Page1());
        }

        private async void Btntexto_Clicked(object sender, EventArgs e)
        {
          

            wsclient client = new wsclient();
            var result = await client.Get<webservice>("http://test.productosecoplas.cl/");
            if (result != null)
            lblTitle.Text = $"{result.id}";
            lblId.Text = result.usuario;
            lblBody.Text = result.contrasena;
            {
            }
        }

        private async void metodo2()
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://test.productosecoplas.cl/");

            string jsonData = @"{""first_name"" : ""Sashell"", ""last_name"" : ""hijo de haskell"",  ""phone"" : ""555-555-555"",  ""email"" : ""blancavergas@gmail.com"", ""address"" : ""revolucion 205"", ""city"" : ""mexico"", ""state"" : ""MX""}";

            try
            {
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync("", content);

                // this result string should be something like: "{"token":"rgh2ghgdsfds"}"
                var result = await response.Content.ReadAsStringAsync();

            }
            catch (Exception er)
            {
                var lb = er.ToString();
                var js = "xs";
            }



        }


    }
}
