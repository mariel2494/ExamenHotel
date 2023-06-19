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
    public class viewModelCrearHabitaciones : INotifyPropertyChanged
    {

        public viewModelCrearHabitaciones() {

            // Abrir las habitaciones 

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

            crearHabitacion = new Command(() =>
            {
                if (selection == "cabanias")
                {
                    Cabanias cab = new Cabanias(NumeroHabitacion, Piso, Cuartos)
                    {
                        nombrehab = "Cabanias"
                    };
                  ObjetoSeleccionado.agregarHabitacion(cab);
                   // listhab.Add(cab);
                }
                else
                {
                    Vip vip = new Vip(NumeroHabitacion,Piso,Cuartos)
                    {
                        nombrehab = "Vip"
                    };

                    ObjetoSeleccionado.agregarHabitacion(vip);
                   // listhab.Add(vip);
                }

                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaH);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                NumeroHabitacion = 0;
                Piso = 0;
                Cuartos = 0;
            });

            
        }
        public ObservableCollection<Hotel> listaH { get; set; } = new ObservableCollection<Hotel>();
        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "hotel.bin");

        int numeroHabitacion;

        public int NumeroHabitacion
        {

            get => numeroHabitacion;
            set
            {
                numeroHabitacion = value;
                var args = new PropertyChangedEventArgs(nameof(NumeroHabitacion));
                PropertyChanged?.Invoke(this, args);
            }

        }

        int piso;

        public int Piso
        {

            get => piso;
            set
            {
                piso = value;
                var args = new PropertyChangedEventArgs(nameof(Piso));
                PropertyChanged?.Invoke(this, args);
            }

        }

        int cuartos;

        public int Cuartos
        {

            get => cuartos;
            set
            {
                cuartos = value;
                var args = new PropertyChangedEventArgs(nameof(Cuartos));
                PropertyChanged?.Invoke(this, args);
            }

        }

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



        string selection;

        public string Selection
        {

            get => selection;
            set
            {
                selection = value;
                var args = new PropertyChangedEventArgs(nameof(Selection));
                PropertyChanged?.Invoke(this, args);
            }
        }



      //  public ObservableCollection<Habitaciones> listhab { get; set; } = new ObservableCollection<Habitaciones>();
        public Command crearHabitacion { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
