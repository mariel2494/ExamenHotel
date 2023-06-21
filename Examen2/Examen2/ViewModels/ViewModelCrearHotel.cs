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
    public class ViewModelCrearHotel : INotifyPropertyChanged
    {

       public ViewModelCrearHotel()
        {
            // Rutina para abrir el archivo de listas 

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
                Console.WriteLine("Sin archivo por cargar de Hoteles");

            }

            crearHotel = new Command(() => {


                Hotel h = new Hotel()
                {
  
                    nombre = this.nombre,
                    fechaFundacion=this.fechaFundacion,
                    ubicacion=this.ubicacion,
                    
                };

                listaH.Add(h);
                // Rutina para Serializar las Listas de Hoteles
                BinaryFormatter formateador = new BinaryFormatter();
                MemoryStream memoria = new MemoryStream();
                formateador.Serialize(memoria, listaH);
                byte[] datoSerializados = memoria.ToArray();
                memoria.Close();

                File.WriteAllBytes(ruta, datoSerializados);

                Nombre = string.Empty;
                Ubicacion = string.Empty;

            });

        }

        DateTime fechaMin = new DateTime(1990, 1, 1);

        public DateTime FechaMin
        {

            get => fechaMin;
            set
            {
                fechaMin = value;
                var args = new PropertyChangedEventArgs(nameof(FechaMin));
                PropertyChanged?.Invoke(this, args);
            }

        }
        public ObservableCollection<Hotel> listaH { get; set; } = new ObservableCollection<Hotel>();

        string ruta = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "hotel.bin");


        string nombre;
        public string Nombre
        {

            get => nombre;
            set
            {
                nombre = value;
                var args = new PropertyChangedEventArgs(nameof(Nombre));
                PropertyChanged?.Invoke(this, args);
            }
        }


        DateTime fechaFundacion;

        public DateTime FechaFundacion
        {

            get => fechaFundacion;
            set
            {
                fechaFundacion = value;
                var args = new PropertyChangedEventArgs(nameof(FechaFundacion));
                PropertyChanged?.Invoke(this, args);
            }
        }


        string ubicacion;

        public string Ubicacion
        {

            get => ubicacion;
            set
            {
                ubicacion = value;
                var args = new PropertyChangedEventArgs(nameof(Ubicacion));
                PropertyChanged?.Invoke(this, args);
            }
        }

        public Command crearHotel { get; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
