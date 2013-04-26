
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
        int minas = 40;

        // si el tag es 1 es que no hay bomba
        // si el tag es 2 es que sí hay bomba
        public Form1()
        {
            InitializeComponent();

            this.Height = filas * anchoBoton + 40;
            this.Width = columnas * anchoBoton + 20;

            matrizBotones = new Button[columnas, filas];

            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    Button boton = new Button();
                    //boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                    boton.Width = anchoBoton;
                    boton.Height = anchoBoton;
                    boton.Location = new Point(j * anchoBoton, i * anchoBoton);
                    boton.Click += chequeaBoton;
                    boton.Tag = "0";
                    matrizBotones[j, i] = boton;
                    panel1.Controls.Add(boton);
                }
            poneMinas();
            cuentaMinas();
        }

        private void cuentaMinas() 
        { 
            for (int i = 0; i < filas; i++)
                for (int j = 0; j < columnas; j++)
                {
                    int numeroBombas = 0;

                    for (int k = -1; k < 2; k++)
                    {
                        for (int m = -1; m < 2; m++)
                        {
                            int f = i + k;
                            int c = j + m;
                            if ((c < columnas) && (c >= 0) &&
                                (f < filas) && (f >= 0))
                            {
                                if (matrizBotones[c,f].Tag =="B" )
                                {
                                    numeroBombas++;
                                }
                            }
                        }
                    }
                    if ((matrizBotones[j, i].Tag != "B") &&
                        (numeroBombas > 0))
                    {
                        matrizBotones[j, i].Tag = numeroBombas.ToString();
                        matrizBotones[j, i].Text = numeroBombas.ToString();
                    }
                }
        } //fin del cuentaMinas


        private void poneMinas()
        {
            Random aleatorio = new Random();
            int x = 0, y = 0;
            for (int i = 0; i < minas; i++)
            {
                x = aleatorio.Next(filas);
                y = aleatorio.Next(columnas);
                while (!matrizBotones[y, x].Tag.Equals("0"))
                {
                    x = aleatorio.Next(filas);
                    y = aleatorio.Next(columnas);
                }
                matrizBotones[y, x].Tag = "B";
                matrizBotones[y, x].Text = "B";
                matrizBotones[y, x].BackColor = Color.Orange;
            }
        }

        private void chequeaBoton(object sender, EventArgs e)
        {
            //(sender as Button).Enabled = false;
            Button b = (sender as Button);
            int columna = b.Location.X / anchoBoton;
            int fila = b.Location.Y / anchoBoton;

            if (matrizBotones[columna, fila].Tag == "0")
            {
                b.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        int f = fila + i;
                        int c = columna + j;
                        if ((c < columnas) && (c >= 0) && (f< filas) && (f >= 0))     
                        {
                            if (matrizBotones[c, f].FlatStyle != System.Windows.Forms.FlatStyle.Flat)
                            {  
                                chequeaBoton(matrizBotones[c, f], e);
                            }
                        }
                    }
                }
            }
        }//fin del chequeaBoton

    }
}
