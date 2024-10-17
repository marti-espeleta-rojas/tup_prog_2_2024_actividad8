using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Cuenta : IComparable
    {
        #region Propiedades de la cuenta
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public DateTime Fecha { get; private set; }
        public Persona Titular { get; set; }
        #endregion
        #region Constructores
        public Cuenta(int numero, Persona titular)
        {
            Numero = numero;
            Titular = titular;
            Fecha = DateTime.Now;
            Saldo = 0;
        } 

        public Cuenta(int numero, double saldo, DateTime fecha, Persona titular)
        {
            Numero = numero;
            Saldo = saldo;
            Fecha = fecha;
            Titular = titular;
        }
        #endregion
        #region Métodos
        public int CompareTo(object obj)
        {
            Cuenta c = obj as Cuenta;
            if (c != null)
            {
                return Numero.CompareTo(c.Numero);
            }
            return 1;
        }

        public override string ToString()
        {
            return $"{Titular} {Numero} {Saldo:F2}";
        }
        #endregion
    }
}
