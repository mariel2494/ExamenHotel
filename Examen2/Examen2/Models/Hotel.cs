using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Examen2.Models
{
    [Serializable]
    public class Hotel
    {

        public string nombre { get; set; }
        public DateTime fechaFundacion { get; set; }
        public string ubicacion { get; set; }

      public List<Habitaciones> listhab { get; } = new List<Habitaciones>();
       // public ObservableCollection<Habitaciones> listhab { get; set; } = new ObservableCollection<Habitaciones>();

      public void agregarHabitacion(Habitaciones hab)
    {
        listhab.Add(hab);
     }

        public override string ToString()
        {
            return $" {nombre} - {ubicacion} ";
        }

        public string getHabitaciones()
        {
            string reporte = "";

            foreach (Habitaciones x in listhab)
            {

                reporte += x.ToString() + "\n";

            }

            return reporte;
        }


    }
}
