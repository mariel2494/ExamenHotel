using Examen2.Models;
using Examen2.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Examen2.ViewModels
{
    public class viewModelMenu : INotifyPropertyChanged
    {

        public viewModelMenu()
        {


            lista.Add(new Menus()
            {

                nombre = "Crear Hotel",
                urlcategoria = "hotel.png"

            });

            lista.Add(new Menus()
            {

                nombre = "Crear Habitacion",
                urlcategoria = "oportunidad.png"

            });


            lista.Add(new Menus()
            {

                nombre = "Ver Habitacion",
                urlcategoria = "llavero.png"

            });




            redirigirCategoria = new Command(() => {

                switch (ObjetoSeleccionado.nombre)
                {

                    case "Crear Hotel":

                        var pagina = new viewCrearHotel();
                        Application.Current.MainPage.Navigation.PushAsync(pagina);

                        break;

                    case "Crear Habitacion":

                        var pagina1 = new viewCrearHabitacion();
                        Application.Current.MainPage.Navigation.PushAsync(pagina1);

                        break;

                    case "Ver Habitacion":

                        var pagina3 = new viewVerHabitacion();
                        Application.Current.MainPage.Navigation.PushAsync(pagina3);

                        break;

                    default:

                        Application.Current.MainPage.DisplayAlert("Error", "Objeto no Encontrado", "OK");

                        break;



                }


            });


        }

        Menus objetoSeleccionado;
        public Menus ObjetoSeleccionado
        {

            get => objetoSeleccionado;
            set
            {
                objetoSeleccionado = value;
                OnPropertyChanged(nameof(ObjetoSeleccionado));
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<Menus>lista { get; set; } = new ObservableCollection<Menus>();

        public Command redirigirCategoria { get; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
