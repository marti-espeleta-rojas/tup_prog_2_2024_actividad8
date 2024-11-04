using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1.Models
{
    [Serializable]
    public class CuentaInexistenteException : ApplicationException
    {
        public CuentaInexistenteException():base() { }
        public CuentaInexistenteException(string message) : base(message) { }
        public CuentaInexistenteException(string message, Exception inner):base(message, inner) { }
    }
}
