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
        int minas = 20; 

        // si el tag es 1 es que no hay bomba
        // si el tag es 2 es que sí hay bomba
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
            poneMinas();
        }

        private void poneMinas() {
            Random aleatorio = new Random();
            int x = 0, y = 0; 
            for (int i = 0; i < minas; i++)
            {
                x = aleatorio.Next(filas);
                y = aleatorio.Next(columnas);
                while (!matrizBotones[y, x].Tag.Equals("1"))
                {
                    x = aleatorio.Next(filas);
                    y = aleatorio.Next(columnas);
                }
                matrizBotones[y, x].Tag = "2";
                matrizBotones[y, x].Text = "B";
            }
        }

        private void chequeaBoton(object sender, EventArgs e)
         {
            (sender as Button).Enabled = false;
            Button b = (sender as Button);
            int columna  = b.Location.X /anchoBoton;
            int fila = b.Location.Y / anchoBoton;

            for (int i = -1; i < 2; i++) {
                for (int j = -1; j < 2; j++) {
                    if ((columna + j < columnas) && (columna + j >= 0) &&
                        (fila + i < filas) && (fila + i >= 0))
                    {
                        if (matrizBotones[columna + j, fila + i].BackColor != Color.Blue)
                        {
                            matrizBotones[columna + j, fila + i].BackColor = Color.Blue;
                            chequeaBoton(matrizBotones[columna + j, fila + i], e);
                        }
                    }
                }
            } 





            ////colorea en la fila del clic, el boton izquierdo y el derecho
            //matrizBotones[columna - 1, fila].BackColor = Color.Blue;
            //matrizBotones[columna, fila].BackColor = Color.Blue;
            //matrizBotones[columna + 1, fila].BackColor = Color.Blue;

            ////colorea en la fila superior del clic, el boton izquierdo, el central y el derecho
            //matrizBotones[columna - 1, fila - 1].BackColor = Color.Blue;
            //matrizBotones[columna, fila-1].BackColor = Color.Blue;
            //matrizBotones[columna + 1, fila-1].BackColor = Color.Blue;

            ////colorea en la fila inferior del clic, el boton izquierdo, el central y el derecho
            //matrizBotones[columna - 1, fila + 1].BackColor = Color.Blue;
            //matrizBotones[columna, fila + 1].BackColor = Color.Blue;
            //matrizBotones[columna + 1, fila + 1].BackColor = Color.Blue;

 
         }




























        ///*
        // * chequeaBoton es un METODO RECURSIVO
        // * esto significa que se llama a sí mismo
        // * Las precauciones con los métodos recursivos pasan por:
        // * 1º entender qué hace el método y porqué se hace recursivo
        // * 2º siempre tiene que tener una salida con un if - else porque sino se cuelga el programa
        // */


        //private void chequeaBoton(object sender, EventArgs e)
        //{
        //    Button b = (sender as Button);
        //    int columna = b.Location.X / anchoBoton;
        //    int fila = b.Location.Y / anchoBoton;
        //    for (int i = 0; i < 3; i++)
        //    {
        //        for (int j = 0; j < 3; j++)
        //        {
        //            int c = columna + j - 1;
        //            int f = fila + i - 1;
        //            if ((c >= 0) && (c < columnas) && (f >= 0) && (f < filas))
        //            {
        //                if (matrizBotones[c, f].BackColor != Color.Red)
        //                {
        //                    matrizBotones[c, f].BackColor = Color.Red;
        //                    chequeaBoton(matrizBotones[c, f], e);
        //                }
        //            }
        //        }
        //    }
        //}

    }
}
