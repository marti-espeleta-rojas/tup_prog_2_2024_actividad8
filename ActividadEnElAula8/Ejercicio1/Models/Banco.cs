using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
    public class Banco
    {
        #region Propiedades y relaciones de clases
        public int CantidadClientes
        {
            get
            {
                return clientes.Count;
            }
        }
        public int CantidadCuentas
        {
            get
            {
                return cuentas.Count;
            }
        }
        List<Persona> clientes = new List<Persona>();
        List<Cuenta> cuentas = new List<Cuenta>();
        #endregion
        #region Indexer
        public Cuenta this[int idx]
        {
            get
            {
                if (CantidadCuentas > idx && idx > 0)
                {
                    return cuentas[idx];
                }
                return cuentas[idx];
                //throw new IndexOutOfRangeException();
            }
        }
        #endregion

        #region Métodos de la clase
        public Cuenta AgregarCuenta(int num, int dni, string nombre)
        {
            Cuenta c = null;
            Persona p = new Persona(dni, nombre);
            if (clientes == null)
            {
                clientes.Add(p);
            }
            clientes.Sort();
            int idx = clientes.BinarySearch(p);
            if (idx >= 0)
            {
                c = new Cuenta(num, p);
            }
            else
            {
                clientes.Add(p);
                c = new Cuenta(num, p);
            }
            cuentas.Add(c);
            return c;
        }

        public Cuenta AgregarCuenta(Cuenta c)
        {
            cuentas.Add(c);
            return c;
        }

        public Cuenta VerCuentaPorNumero(int numeroCuenta)
        {
            Cuenta c = new Cuenta(numeroCuenta, null);
            cuentas.Sort();
            int idx = cuentas.BinarySearch(c);
            if (idx <= 0)
            {
                throw new CuentaInexistenteException();
            }
            return cuentas[idx];
        }

        public Persona VerCuentaPorDni(int dni)
        {
            Persona cli = new Persona(dni, "");
            clientes.Sort();
            int idx = clientes.BinarySearch(cli);
            if (idx >= 0)
            {
                return clientes[idx];
            }
            else
            {
                return null;
            }
        }

        public bool RestaurarCuenta(int numero, double saldo, DateTime fecha, Persona titular)
        {
            Cuenta cuenta = VerCuentaPorNumero(numero);
            if (cuenta == null)
            {
                cuenta = new Cuenta(numero, saldo, fecha, titular);
                cuentas.Add(cuenta);
                return true;
            }
            else
            {
                cuenta.Saldo = saldo;
                cuenta.Fecha = fecha;
                cuenta.Numero = numero;
                cuenta.Titular = titular;
                return true;
            }
        }
        #endregion
    }
}
