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
    public partial class ListaPersonas : ContentPage
    {
        public static string iddatos;
        public static string nombres;
        public static string apellidos;
        public static string correo;
        public static string edad;
        public static string direccion;  
        public ListaPersonas()
        {
            InitializeComponent();
            mostrarLista();
        }

        public async void mostrarLista()
        {
            var datoslist = await App.SQLiteDB.GetDatosAsync();
            if (datoslist != null)
            {
                listadatos.ItemsSource = datoslist;
            }
        }

        private void btnvolver_Clicked(object sender, EventArgs e)
        {
             Navigation.PushAsync(new datos());
        }

        private async void listadatos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var obj = (Datos)e.SelectedItem;

            if (!string.IsNullOrEmpty(obj.id.ToString()))
            {
                var datos2 = await App.SQLiteDB.GetDatosByIdAsync(obj.id);

                if (datos2 != null)
                {

                    iddatos = datos2.id.ToString();
                    nombres = datos2.Nombres;
                    apellidos = datos2.Apellidos;
                    edad = datos2.Edad.ToString();
                    correo = datos2.Correo.ToString();
                    direccion = datos2.Direccion.ToString();
                

                    var mandar = new Models.pasarDatos

                    {
                        idp = Convert.ToInt32(iddatos.ToString()),
                        Nombrep = nombres,
                        Edadp = Convert.ToInt32(edad.ToString()),
                        Apellidop = apellidos,
                        Correop = correo,
                        Direccionp = direccion,
                       

                    };

                    var segpage = new Actualizar();
                    segpage.BindingContext = mandar;
                    await Navigation.PushAsync(segpage);


                }


            }

            // await Navigation.PushAsync(new Actualizar());


        }
    }
}