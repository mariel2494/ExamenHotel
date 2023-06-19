using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    [Serializable]
    public class Habitaciones
    {
        public int numeroHabitacion {get; set; }
        public int piso { get; set; }
        public int cuartos { get; set; }
        public double precioRenta { get; set; }

        public string nombrehab { get; set; }


        public virtual void calcularRenta()
        {

        }


        public override string ToString()
        {
            return $"Habitacion tipo:{nombrehab}\n Numero de Habitacion: {numeroHabitacion}\n Piso:{piso}\n Cantidad de cuartos: {cuartos}\n Precio: LPS. {precioRenta}\n";
        }

    }
}
