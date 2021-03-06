﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrdenamientoForma
{
    public partial class Form2 : Form
    {
        static int f, c;
        Ordenamiento orden = new Ordenamiento();
        public Form2(int figura, int columna)
        {
            InitializeComponent();
            f = figura;
            c = columna;
            Cant = c * f;
            IniciarTabla();
        }
        int Cant;
        int[,] arreglo;
        void IniciarTabla()
        {
            arreglo = new int[f, c];
            Tabla.ColumnCount = c;
            for (int i = 0; i < f; i++)
            {
                Tabla.Rows.Add();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int[] Numero;
        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            try
            {
                int cant = c * f;
                Numero = new int[cant];
                int p=0, r=0;
                string g = ObtenerDatos();
                AsignarValoresIniciales(ref p,ref r);
                MessageBox.Show(g, "Numeros ordenados");
            }
            catch (Exception ex)
            {
                MessageBox.Show(""+ex);
            }
            
        }
        void AsignarValoresIniciales(ref int primer, ref int ultimo)
        {
            for (int i = 0; i < Numero.Length; i++)
            {
                if(i==0)
                {
                    primer = Numero[i];
                }
                ultimo = Numero[i];
            }
        }
        string ObtenerDatos()
        {
            int cant = c * f;
            //Numero= new int[cant];
            int cont = 0;
            for (int fila = 0; fila < Tabla.Rows.Count-1; fila++)
            { 
                for (int col = 0; col < Tabla.Rows[fila].Cells.Count; col++)
                {
                    Numero[cont] = int.Parse(Tabla.Rows[fila].Cells[col].Value.ToString());
                    cont++;
                }
            }
            OrdenamientoRapido(Numero, cant);
            string g="";
            for (int i = 0; i < Cant; ++i)
            {
                g+= ($"{Numero[i]},");
            }
            return g;
        }
        
        static int cont;
        private static int OrdenamientoRapido(int[] datos, int numero)
        {
            cont = 0;
            OrdenamientoRapido(datos, 0, numero - 1);
            return cont;
        }
        public static void OrdenamientoRapido(int[] datos, int inf, int sup)
        {
            if (sup > inf)
            {
                int pivote = datos[sup];
                int i = inf - 1;
                int j = sup;
                do
                {
                    while (datos[++i] < pivote) ;
                    while (datos[--j] > pivote) ;
                    if (i < j)
                        swap(datos, i, j);
                }
                while (i < j);
                swap(datos, i, sup);
                OrdenamientoRapido(datos, inf, i - 1);
                OrdenamientoRapido(datos, i + 1, sup);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            int cont = 0;
            int cant = c * f;
            Random ram = new Random();
            Numero = new int[cant];
            for (int j = 0; j < f; j++)
            {
                for (int i = 0; i < c; i++)
                {
                    
                    var Value = ram.Next(0, 20);
                    Tabla.Rows[j].Cells[i].Value = Value;
                    Numero[cont] = Value;
                    cont++;
                }
            }
            try
            {
                string g = ObtenerDatos();
                MessageBox.Show(g, "Numeros ordenados");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static void swap(int[] datos, int i, int j)
        {
            int aux = datos[i];
            datos[i] = datos[j];
            datos[j] = aux;
            cont++; // variable global
        }
    }
}
