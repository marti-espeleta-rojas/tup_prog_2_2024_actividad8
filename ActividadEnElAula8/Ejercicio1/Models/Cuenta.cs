using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    public class Cuenta : IComparable
    {
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public DateTime Fecha { get; set; }
        public Persona Titular { get; set; }

        public Cuenta(int numero, Persona titular)
        {
            Numero = numero;
            Titular = titular;
        } 

        public Cuenta(int numero, double saldo, DateTime fecha, Persona titular)
        {
            Numero = numero;
            Saldo = saldo;
            Fecha = fecha;
            Titular = titular;
        }

        public int CompareTo(object obj)
        {
            Cuenta c = obj as Cuenta;
            if (c != null)
            {
                return Numero.CompareTo(c.Numero);
            }
            return 1;
        }
    }
}
