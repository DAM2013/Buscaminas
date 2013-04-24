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
            

            this.Height = filas * anchoBoton + 40;
            this.Width = columnas * anchoBoton + 20;

            matrizBotones = new Button[columnas,filas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas ; j++)
                {
                    Button boton = new Button();
                    //boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(j * anchoBoton, i * anchoBoton);
                    boton.Click += chequeaBoton;
                    boton.Tag = "1";
                    matrizBotones[j, i] = boton;
                    panel1.Controls.Add(boton);
                }
        }

        /*
         * chequeaBoton es un METODO RECURSIVO
         * esto significa que se llama a sí mismo
         * Las precauciones con los métodos recursivos pasan por:
         * 1º entender qué hace el método y porqué se hace recursivo
         * 2º siempre tiene que tener una salida con un if - else porque sino se cuelga el programa
         */


        private void chequeaBoton(object sender, EventArgs e)
        {
            Button b = (sender as Button);
            int columna = b.Location.X / anchoBoton;
            int fila = b.Location.Y / anchoBoton;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int c = columna + j - 1;
                    int f = fila + i - 1;
                    if ((c >= 0) && (c < columnas) && (f >= 0) && (f < filas))
                    {
                        if (matrizBotones[c, f].BackColor != Color.Red)
                        {
                            matrizBotones[c, f].BackColor = Color.Red;
                            chequeaBoton(matrizBotones[c, f], e);
                        }
                    }
                }
            }
        }

    }
}
