using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 *  NOMBRE:
 *  APELLIDOS: 
 *  ESTO ES UNA PRUEBA DE GITHUB 
 * 
 */

namespace Buscaminas
{
    public partial class Form1 : Form
    {
        //declaro el array de botones
        Button[,] matrizBotones;
        int filas = 15;
        int columnas = 20;
        int anchoBoton = 20;
        public Form1()
        {
            InitializeComponent();
            

            this.Height = columnas * anchoBoton + 40;
            this.Width = filas * anchoBoton + 20;

            matrizBotones = new Button[filas, columnas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Button boton = new Button();
                    //boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(i * anchoBoton, j * anchoBoton);
                    boton.Click += chequeaBoton;
                    boton.Tag = 1;
                    matrizBotones[i, j] = boton;
                    panel1.Controls.Add(boton);
                }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            int columna  = b.Location.X /anchoBoton;
            int fila = b.Location.Y / anchoBoton;

            //colorea en la fila del clic, el boton izquierdo y el derecho
            matrizBotones[columna - 1, fila].BackColor = Color.Blue;
            matrizBotones[columna, fila].BackColor = Color.Blue;
            matrizBotones[columna + 1, fila].BackColor = Color.Blue;

            //colorea en la fila superior del clic, el boton izquierdo, el central y el derecho
            matrizBotones[columna - 1, fila - 1].BackColor = Color.Blue;
            matrizBotones[columna, fila-1].BackColor = Color.Blue;
            matrizBotones[columna + 1, fila-1].BackColor = Color.Blue;

            //colorea en la fila inferior del clic, el boton izquierdo, el central y el derecho
            matrizBotones[columna - 1, fila + 1].BackColor = Color.Blue;
            matrizBotones[columna, fila + 1].BackColor = Color.Blue;
            matrizBotones[columna + 1, fila + 1].BackColor = Color.Blue;


        }
    }
}
