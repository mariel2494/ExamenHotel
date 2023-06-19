using Examen2.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Xamarin.Forms;

namespace Examen2.ViewModels
{
    public class viewModelVerHabitacion
    {

       public viewModelVerHabitacion()
        {
            try
            {
                /*Abir y leer el archivo */
                byte[] data = File.ReadAllBytes(ruta);
                MemoryStream memory = new MemoryStream(data);
                BinaryFormatter formater = new BinaryFormatter();
                listaH = (ObservableCollection<Hotel>)formater.Deserialize(memory);
                memory.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Sin archivo por cargar de Personas");

            }

            verHabitacion = new Command(() =>
            {
                objetoSeleccionado.ToString();

                Application.Current.MainPage.DisplayAlert("Habitaciones Disponibles", ObjetoSeleccionado.getHabitaciones(), "Cerrar");
                Resultado = objetoSeleccionado.getHabitaciones();

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaH);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);
               // objetoSeleccionado.getHabitaciones();

            });
        }
        public ObservableCollection<Hotel> listaH { get; set; } = new ObservableCollection<Hotel>();
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "hotel.bin");

        Hotel objetoSeleccionado;

        public Hotel ObjetoSeleccionado
        {

            get => objetoSeleccionado;
            set
            {
                objetoSeleccionado = value;
                var args = new PropertyChangedEventArgs(nameof(ObjetoSeleccionado));
                PropertyChanged?.Invoke(this, args);
            }

        }

        string resultado;

        public string Resultado
        {

            get => resultado;
            set
            {
                resultado = value;
                var args = new PropertyChangedEventArgs(nameof(Resultado));
                PropertyChanged?.Invoke(this, args);
            }

        }



        public Command verHabitacion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
