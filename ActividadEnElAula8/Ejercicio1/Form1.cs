using Ejercicio1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
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
        }
        Banco banco = new Banco();
        private void btnVerCuentas_Click(object sender, EventArgs e)
        {
            //try
            //{
                //banco.AgregarCuenta(2, 47175513, "Maria");
                //banco.AgregarCuenta(4, 68432563, "Maxima");
                //banco.AgregarCuenta(1, 34364435, "Jose");
                //banco.AgregarCuenta(3, 23657463, "Fili");
                //banco.AgregarCuenta(5, 45345234, "Ayun");
                Cuenta cuenta;
                for (int i = 0; i < banco.CantidadCuentas; i++)
                {
                    cuenta = banco[i];
                    lbxVer.Items.Add(cuenta);
                }
            //}
            //catch (IndexOutOfRangeException ez)
            //{
            //    MessageBox.Show("Índice fuera de los límites de capacidad de la lista.");
            //}
            //catch (Exception ez)
            //{
            //    MessageBox.Show(ez.Message);
            //}
        }

        private void btnImportarCuentas_Click(object sender, EventArgs e)
        {
            //leemos la dirección y el nombre del archivo a abrir
            OpenFileDialog open = new OpenFileDialog();
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

                    //declaro una cuenta para poder agregarla a cuentas
                    Cuenta cuenta;
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

                        //a la cuenta creada (o la existente encontrada) le actualizamos el saldo
                        cuenta = banco.AgregarCuenta(numCuenta, dni, nombre);
                        cuenta.Saldo += saldo;
                    }  
                }
                catch (Exception ez)
                {
                    MessageBox.Show(ez.Message);
                }
                finally
                {
                    fs.Close();
                    lector.Close();
                }
            }
        }

        private void btnExportarCuentas_Click(object sender, EventArgs e)
        {
            SaveFileDialog guardar = new SaveFileDialog();
            Cuenta cuenta;
            guardar.InitialDirectory = Application.StartupPath;
            FileStream fs = null;
            StreamWriter escritor = null;
            if (guardar.ShowDialog() == DialogResult.OK)
            {
                fs = new FileStream(guardar.FileName, FileMode.Open, FileAccess.Write);
                for (int i = 0; i < banco.CantidadCuentas; i++)
                {
                    
                }
            }
        }
    }
}
