using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Paginas.ConsumeAPI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageAPI : ContentPage
    {
        public PageAPI()
        {
            InitializeComponent();
        }
        //private Models.Proveedor[] Proveedores { get; set; }

        private string Url = "https://appmovilesapi.alejandropadi12.repl.co/proveedor/";
        private void Button_Clicked(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var json = wc.DownloadString(Url + txtId.Text);
                var proveedor = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Proveedor>(json);

                if (proveedor != null)
                {

                    txtId.Text = proveedor.pro_cedula_ruc;
                    txtNombre.Text = proveedor.pro_nombre;
                    txtDireccion.Text = proveedor.pro_direccion;
                    txtCiudad.Text = proveedor.pro_ciudad;
                    txtTelefono.Text = proveedor.pro_telefono;
                    txtCorreo.Text = proveedor.pro_correo;
                }
                else
                {
                    lblDatos.Text = "REGISTROS NO ENCONTRADO";
                    txtNombre.Text = "";
                    txtDireccion.Text = "";
                    txtCiudad.Text = "";
                    txtTelefono.Text = "";
                    txtCorreo.Text = "";

                }
            }
        }
        private string Urlinsert = "https://appmovilesapi.alejandropadi12.repl.co/nuevoproveedor";
        private void Button_Clicked_1(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Proveedor
                {
                    pro_cedula_ruc = txtId.Text,
                    pro_nombre = txtNombre.Text,
                    pro_direccion = txtDireccion.Text,
                    pro_ciudad = txtCiudad.Text,
                    pro_telefono = txtTelefono.Text,
                    pro_correo = txtCorreo.Text,
                    pro_credito_contado = Credito.IsToggled,
                    pro_estado = Estado.IsToggled
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Urlinsert, "POST", json);
                lblDatos.Text = "DATOS INSERTADOS CON EXITO";
            }
        }
        private string Urlactualizar = "https://appmovilesapi.alejandropadi12.repl.co/editproveedor";
        private void Button_Clicked_2(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                var datos = new Models.Proveedor
                {
                    pro_cedula_ruc = txtId.Text,
                    pro_nombre = txtNombre.Text,
                    pro_direccion = txtDireccion.Text,
                    pro_ciudad = txtCiudad.Text,
                    pro_telefono = txtTelefono.Text,
                    pro_correo = txtCorreo.Text,
                    pro_credito_contado = Credito.IsToggled,
                    pro_estado = Estado.IsToggled
                };
                var json = Newtonsoft.Json.JsonConvert.SerializeObject(datos);
                wc.UploadString(Urlactualizar, "PUT", json);
                lblDatos.Text = "REGISTRO ACTUALIZADO CON EXITO";
                txtId.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
            }
        }
        private string Urlborrar = "https://appmovilesapi.alejandropadi12.repl.co/proveedor";
        private void Button_Clicked_3(object sender, EventArgs e)
        {
            using (var wc = new WebClient())
            {
                wc.Headers.Add("Content-Type", "application/json");
                wc.UploadString(Urlborrar + "/" + txtId.Text, "DELETE", "");
                lblDatos.Text = "DATO ELIMINADO CON EXITO";
                txtId.Text = "";
                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtCiudad.Text = "";
                txtTelefono.Text = "";
                txtCorreo.Text = "";
            }
        }
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry entry = (Entry)sender;
            string input = entry.Text;

            if (input.Length > 10)
            {
                entry.Text = input.Substring(0, 10); // Trunca la entrada a 10 caracteres
                entry.CursorPosition = 10; // Coloca el cursor al final del texto
            }
        }
    }
}