using PMT03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PMT03
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class datos : ContentPage
    {
        public datos()
        {
            InitializeComponent();
        }

        private async void btnguardar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
             

                Datos datos = new Datos
                {
                    Nombres = txtnombres.Text,
                    Apellidos = txtapellidos.Text,
                    Edad = int.Parse(txtedad.Text),
                    Correo = txtcorreo.Text,
                    Direccion = txtDireccion.Text,
                    
                };
                await App.SQLiteDB.SaveDatosAsync(datos);

                txtnombres.Text = "";
                txtapellidos.Text = "";
                txtedad.Text = "";
                txtedad.Text = "";
                txtDireccion.Text = "";
              
                await DisplayAlert("Registro", "Se guardo de manera exitosa los datos", "Ok");

            }
            else
            {
                await DisplayAlert("Advertencia", "Ingresar todos los datos", "Ok");
            }
        }

        private async void btnvolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnlista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaPersonas());
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtnombres.Text))
            {
                respuesta = false;
            }
            if (string.IsNullOrEmpty(txtapellidos.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtedad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtcorreo.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }

            else
            {
                respuesta = true;
            }
            return respuesta;
        }


    }
}