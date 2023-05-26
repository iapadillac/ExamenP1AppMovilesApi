using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Paginas.Login
{
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
        }
        private void Buttoon_Clicked(object sender, EventArgs e)
        {
            //abrir una nueva pagina misma que se coloca en la cima de la pila de paginas
            var datos = new NameValueCollection();
            datos.Add("usuario", "PEPE");
            datos.Add("clave", "1234");

            var mp = new MainPage();
            mp.Datos = datos;
            mp.Usuario = "Homer";
            mp.Clave = "donuts";

            Navigation.PushAsync(mp);
        }
    }
}