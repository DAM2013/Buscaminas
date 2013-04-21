using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //declaro el array de botones
        Button[,] matrizBotones;

        public Form1()
        {
            InitializeComponent();
            int filas = 15;
            int columnas = 20;
            int anchoBoton = 20;

            this.Height = columnas * anchoBoton + 40;
            this.Width = filas * anchoBoton + 20;

            matrizBotones = new Button[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Button boton = new Button();
                    boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(i * anchoBoton, j * anchoBoton);
                    boton.Click += chequeaBoton;
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);
                }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {
            (sender as Button).Enabled = false;

        }
    }
}
