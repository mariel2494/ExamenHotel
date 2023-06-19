using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    [Serializable]
    public class Vip: Habitaciones
    {
        public Vip(int nh, int p, int c)
        {
            this.numeroHabitacion = nh;
            this.piso = p;
            this.cuartos = c;
            calcularRenta();

        }
        public override void calcularRenta()
        {
            precioRenta = cuartos * 300;
        }
    }
}
