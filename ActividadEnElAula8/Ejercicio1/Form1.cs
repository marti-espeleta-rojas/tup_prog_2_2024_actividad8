using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            banco.AgregarCuenta(1, 47175513, "Martiniano");
            banco.AgregarCuenta(2, 47175513, "Martiniano");
            banco.AgregarCuenta(4, 24264435, "Luciana");
            banco.AgregarCuenta(3, 22341639, "Ignacio");
            banco.AgregarCuenta(5, 22214232, "Alfonsina");
        }
        Banco banco = new Banco();
        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            lbxVer.Items.Clear();
            Cuenta cuenta;
            if (banco.CantidadCuentas > 0)
            {
                for (int i = 0; i < banco.CantidadCuentas; i++)
                {
                    cuenta = banco[i];
                    lbxVer.Items.Add(cuenta);
                }
            }
            else
            {
                MessageBox.Show("No existen cuentas en el banco actualmente.");
            }
        }

        private void btnImportarCuentas_Click(object sender, EventArgs e)
        {
            lbxVer.Items.Clear();
            //leemos la dirección y el nombre del archivo a abrir
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Importar Cuentas";
            open.Filter = "Archivos csv|*.csv";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamReader lector = null;
                try
                {
                    //creo el flujo de bytes para tomar el archivo (por su nombre), abrirlo y accederlo
                    fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);

                    //acá lo traducís
                    lector = new StreamReader(fs);

                    //leo la primer línea
                    string linea;
                    linea = lector.ReadLine();

                    //declaro una cuenta para poder agregarla a cuentas y persona para Persona
                    Cuenta cuenta = null;
                    //recorro el archivo leyendo string por string
                    while (lector.EndOfStream == false)
                    {
                        //leemos todas las líneas y para cada una splitteamos sus campos
                        linea = lector.ReadLine();
                        string[] campos = linea.Split(';');
                        int dni = Convert.ToInt32(campos[0].Trim());
                        string nombre = campos[1].Trim();
                        int numCuenta = Convert.ToInt32(campos[2].Trim());
                        double saldo = Convert.ToDouble(campos[3].Trim());
                        cuenta = banco.AgregarCuenta(numCuenta, dni, nombre);
                        cuenta.Saldo = saldo;
                    }
                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message + "Error al importar el archivo");
                }
                finally
                {
                    lector.Close();
                    fs.Close();
                }
            }
        }

        private void btnExportarCuentas_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            Cuenta cuenta = null;
            guardar.InitialDirectory = Application.StartupPath;
            guardar.Title = "Exportar Cuentas";
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamWriter sw = null;
                try
                {
                    fs = new FileStream("MiArchivo.csv", FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    for (int i = 0; i < banco.CantidadCuentas; i++)
                    {
                        cuenta = banco[i];
                        if (cuenta.Saldo > 10000)
                        {
                            string linea = $"{cuenta.Titular.DNI};{cuenta.Titular.Nombre};{cuenta.Numero};{cuenta.Saldo:F2}";
                            sw.WriteLine(linea);
                        }
                    }
                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message + "Error al exportar el archivo.");
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("banco.dat", FileMode.OpenOrCreate, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                if (fs.Length > 0)
                {
                    banco = bf.Deserialize(fs) as Banco;
                }
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message + "Error al importar el estado del programa.");
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream("ejercicio1.dat", FileMode.OpenOrCreate, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, banco);
            }
            catch (Exception ez)
            {
                MessageBox.Show(ez.Message + "No se ha podido guardar el estado del programa");
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "Backup";
            save.Filter = "Archivo csv|*.csv";
            if (save.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fs = new FileStream(save.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    string linea = $"TIPO: BANCO | CLIENTE | CUENTA";
                    sw.Write(linea);
                    linea = $"CLIENTE;DNI;NOMBRE";
                    sw.Write(linea);
                    linea = $"CUENTA;NUMERO;SALDO;FECHA;DNI;TITULAR";
                    sw.Write(linea);

                    #region Banco
                    linea = "BANCO;";
                    sw.WriteLine(linea);
                    #endregion

                    #region Clientes
                    for (int i = 0; i < banco.CantidadClientes; i++)
                    {
                        Persona cliente = banco[i].Titular;
                        linea = $"CLIENTE;{cliente.DNI};{cliente.Nombre}";
                        sw.WriteLine(linea);
                    }
                    #endregion

                    #region Cuentas
                    for (int j = 0; j < banco.CantidadCuentas; j++)
                    {
                        Cuenta c = banco[j];
                        linea = $"CUENTA;{c.Numero};{c.Titular.Nombre};{c.Titular.DNI};{c.Saldo:F2};{c.Fecha:dd/MM/yyyy}";
                        sw.WriteLine(linea);
                    }
                    #endregion

                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message);
                }
                finally
                {
                    if (sw != null) sw.Close();
                    if (fs != null) fs.Close();
                }
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            //leemos la dirección y el nombre del archivo a abrir
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Importar Cuentas";
            open.Filter = "Archivos csv|*.csv";
            if (open.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = null;
                StreamReader lector = null;
                try
                {
                    fs = new FileStream(open.FileName, FileMode.Open, FileAccess.Read);

                    lector = new StreamReader(fs);

                    string linea;
                    linea = lector.ReadLine();

                    Cuenta cuenta = null;
                    Persona cliente = null;
                    //recorro el archivo leyendo string por string
                    while (lector.EndOfStream == false)
                    {
                        linea = lector.ReadLine();
                        string[] campos = linea.Split(';');
                        int dni = Convert.ToInt32(campos[0].Trim());
                        string nombre = campos[1].Trim();
                        int numCuenta = Convert.ToInt32(campos[2].Trim());
                        double saldo = Convert.ToDouble(campos[3].Trim());
                        cliente = new Persona(dni, nombre);
                        cuenta = banco.VerCuentaPorNumero(numCuenta);
                        if (cuenta != null)
                        {
                            cuenta = new Cuenta(numCuenta, saldo, DateTime.Now, cliente);
                            banco.AgregarCuenta(cuenta);
                        }
                        else
                        {
                            banco.RestaurarCuenta(numCuenta, saldo, DateTime.Now, cliente);
                        }

                    }
                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message + "Error al importar el archivo");
                }
                finally
                {
                    lector.Close();
                    fs.Close();
                }
            }
        }
    }
}
