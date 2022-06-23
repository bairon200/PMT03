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
    public partial class Actualizar : ContentPage
    {
        public Actualizar()
        {
            InitializeComponent();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var datos = await App.SQLiteDB.GetDatosByIdAsync(int.Parse(txtIddatos.Text));
            if (datos != null)
            {
                await App.SQLiteDB.DeleteDatosAsync(datos);
                await DisplayAlert("Registro", "Se Elimino de manera exitosa", "ok");
            }

            await Navigation.PushAsync(new ListaPersonas());
        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
          

            Datos Actualizar = new Datos
            {
                id = int.Parse(txtIddatos.Text),
                Nombres = txtnombre.Text,
                Edad = int.Parse(txtedad.Text),
                Apellidos = txtapellido.Text,
                Correo = txtcorreo.Text,    
                Direccion = txtDireccion.Text,


            };

            await App.SQLiteDB.SaveDatosAsync(Actualizar);

            await DisplayAlert("Actualizacion", "Informacion Actualizada", "Ok");

            await Navigation.PushAsync(new ListaPersonas());
        }

    

        private void btnvolver_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ListaPersonas());
        }
    }
}