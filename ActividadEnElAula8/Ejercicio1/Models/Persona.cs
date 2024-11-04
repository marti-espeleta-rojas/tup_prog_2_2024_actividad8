using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
    public class Persona : IComparable<Persona>
    {
        #region Propiedades
        public int DNI { get; set; }
        public string Nombre { get; set; }
        #endregion

        #region Constructor
        public Persona(int dni, string nombre)
        {
            Nombre = nombre;
            DNI = dni; 
        }
        #endregion
        public int CompareTo(Persona p)
        {
            if (p != null)
            {
                return DNI.CompareTo(p.DNI);
            }
            return 1;
        }

        public override string ToString()
        {
            return $"{DNI} {Nombre}";
        }
    }
}
