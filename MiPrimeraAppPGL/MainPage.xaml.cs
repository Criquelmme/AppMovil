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



    }
}
