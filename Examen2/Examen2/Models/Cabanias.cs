using System;
using System.Collections.Generic;
using System.Text;

namespace Examen2.Models
{
    [Serializable]
    public class Cabanias: Habitaciones
    {

        public Cabanias(int nh, int p, int c) { 
            this.numeroHabitacion=nh;
            this.piso = p;
            this.cuartos= c;
            calcularRenta();
        
        }
        public override void calcularRenta()
        {
            precioRenta = cuartos * 200;
        }
    }
}
