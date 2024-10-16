using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Persona : IComparable
    {
        public int DNI { get; set; }
        public string Nombre { get; set; }

        public Persona(int dni, string nombre)
        {
            Nombre = nombre;
            DNI = dni; 
        }

        public int CompareTo(object obj)
        {
            Persona p = obj as Persona;
            if (p != null)
            {
                return DNI.CompareTo(p.DNI);
            }
            return 1;
        }
    }
}
