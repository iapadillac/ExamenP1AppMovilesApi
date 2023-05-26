using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Paginas.ConsumeAPI;
using Xamarin.Forms;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        public MainPage(string usuario, string clave)
        {
            InitializeComponent();
            Usuario = usuario;
            Clave= clave;
        }
        public MainPage(NameValueCollection datos)
        {
            InitializeComponent();
            Datos= datos;

        }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public NameValueCollection Datos { get; set; }

        public void Button_Clicked(object sender, EventArgs e)
        {
          
        }

        public void Button_Clicked_1(object sender, EventArgs e)
        {
           
        }
    }
}
