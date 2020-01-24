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
        wsclient client;

        public MainPage()
        {
            InitializeComponent();
             
            Inicializar();
        }
       
        private void Inicializar()
        {
            btntexto.Clicked += Btntexto_Clicked;
            btntexto2.Clicked += Btnotrapagina_Clicked;
           

        }


        private void Btnotrapagina_Clicked(object sender, EventArgs e)
        {
            //otra pagina
            Navigation.PushAsync(new Page1());
        }

        private async void Btntexto_Clicked(object sender, EventArgs e)
        {
            client = new wsclient();
            client.url = "http://appmovilgeo.azurewebsites.net/";
            string Usuario = txtUsuario.Text;
            string password = txtPass.Text;
            var person = new Person();
            person.Name = Usuario;
            person.pass = password;

            if (Usuario != null && password != null)
            {
                var json = JsonConvert.SerializeObject(person);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var login = await client.Post<webservice>(data);
                
                Console.WriteLine(login);

                if (login != null) { 
                
                
                }
               
                
            }
        }



    }

    class Person
    {
        public string Name { get; set; }
        public string pass { get; set; }

        public override string ToString()
        {
            return $"{Name}: {pass}";
        }
    }
}
