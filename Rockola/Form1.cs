using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Rockola
{
    public partial class Form1 : Form
    {
        private WindowsMediaPlayer player;
        private Cancion cancion;
        private Lista listaEnlazadaCanciones;

        public Form1()
        {
            InitializeComponent();
            listaEnlazadaCanciones =  new Lista();
        }

        private void mostrarListado()
        {
            lstPlaylist.Items.Clear();
            if (!listaEnlazadaCanciones.esVacia())
            {

                Nodo auxnodo = listaEnlazadaCanciones.Primero;
                Cancion c = new Cancion();

                while (auxnodo != null)
                {
                    c = (Cancion)auxnodo.Datos;
                    lstPlaylist.Items.Add(c.Descripcion);
                    auxnodo = auxnodo.Sig;
                }
            }
            else
            {
                MessageBox.Show("La lista no tiene elementos");
            }
        }    

        //Boton de salir
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton de busqueda de archivos
        string[] nombre, ruta;
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                nombre = openFileDialog1.SafeFileNames;
                ruta = openFileDialog1.FileNames;
                for (int i = 0; i < ruta.Length; i++)
                {
                    cancion = new Cancion(ruta[i]);
                    listaEnlazadaCanciones.insertarAlInicio(cancion);
                    mostrarListado();
                }
            }
        }

        //Boton de detener
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        //Boton de siguiente
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.Items.Count == 0)
            {
                MessageBox.Show("Lista de reproducciòn vacìa");
            }
            else
            {
                string ultimo, actual;
                ultimo = (Convert.ToString(lstPlaylist.Items.Count - 1));
                actual = Convert.ToString(lstPlaylist.SelectedIndex.ToString());
                if (random == 1)
                {
                    int ultimon = lstPlaylist.Items.Count - 1;
                    Random rdn = new Random();
                    int shf = rdn.Next(0, ultimon);
                    lstPlaylist.SelectedIndex = shf;
                    Cancion c = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                    axWindowsMediaPlayer1.URL = c.Descripcion;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                }
                else
                {
                    if (actual.Equals(ultimo))
                    {
                        lstPlaylist.SelectedIndex = 0;
                        Cancion c = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                        axWindowsMediaPlayer1.URL = c.Descripcion;

                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else
                        lstPlaylist.SelectedIndex = lstPlaylist.SelectedIndex + 1;
                    Cancion cn = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                    axWindowsMediaPlayer1.URL = cn.Descripcion;

                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
        }

        //Random desactivado
        public int random = 0;
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            if (random == 0)
            {
                random = 1;
                pictureBox10.Visible = true;
            }
            else
            {
                random = 0;
                pictureBox8.Visible = true;
            }
        }

        //Random activado
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            if (random == 1)
            {
                random = 0;
                pictureBox10.Visible = false;
            }
            else
            {
                random = 1;
                pictureBox8.Visible = false;
            }
        }

        //Boton anterior
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (lstPlaylist.Items.Count == 0)
            {
                MessageBox.Show("No hay Archivos");
            }
            else
            {
                string actual, primero;
                primero = Convert.ToString(0);
                actual = Convert.ToString(lstPlaylist.SelectedIndex.ToString());
                if (random == 1)
                {
                    int ultimon = lstPlaylist.Items.Count - 1;
                    Random rdn = new Random();
                    int shf = rdn.Next(0, ultimon);
                    lstPlaylist.SelectedIndex = shf;
                    Cancion c = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                    axWindowsMediaPlayer1.URL = c.Descripcion;
                    axWindowsMediaPlayer1.Ctlcontrols.play();

                }
                else
                {
                    if (actual.Equals(primero))
                    {
                        lstPlaylist.SelectedIndex = lstPlaylist.Items.Count - 1;
                        Cancion c = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                        axWindowsMediaPlayer1.URL = c.Descripcion;

                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else
                        lstPlaylist.SelectedIndex = lstPlaylist.SelectedIndex - 1;
                    Cancion n = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
                    axWindowsMediaPlayer1.URL = n.Descripcion;
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                }
            }
        }

        //Boton de reproduccion
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Cancion c = (Cancion)listaEnlazadaCanciones.getElementoIndice(lstPlaylist.SelectedIndex);
            axWindowsMediaPlayer1.URL = c.Descripcion;
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        //Reproducir cancion al seleccionarla en la lista
        private void lstPlaylist_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1.URL = ruta[lstPlaylist.SelectedIndex];
            //axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        //Botón para eliminar
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            try
            {
                Cancion c = (Cancion)listaEnlazadaCanciones.eliminarElementoIndice(lstPlaylist.SelectedIndex);
                MessageBox.Show(c.Descripcion + " eliminado");
                axWindowsMediaPlayer1.Ctlcontrols.stop();
                mostrarListado();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
