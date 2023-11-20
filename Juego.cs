using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy
{
    public partial class Juego : Form
    {
        // Instancias de clases y listas para el juego
        Tablero tab;
        List<Point> secuencia = new List<Point>();
        List<Puntaje> mejoresPuntajes = new List<Puntaje>();
        PictureBox[,] matPictureBox;
        private String nickname;

        public Juego(String nickname)
        {
            //Método generado automaticamente
            InitializeComponent();
            //Mi objeto tablero
            tab = new Tablero(8, 8, 6);
            matPictureBox = new PictureBox[tab.cantidadFil, tab.cantidadCol];
            pintarTablero();
            this.nickname = nickname;
            cargarPuntajesDesdeArchivo();

            actualizarTableroPuntuaciones();
        }

        // Método para pintar el tablero en el formulario
        public void pintarTablero()
        {
            //Matriz de imágenes
            PictureBox[,] matPictureBox = new PictureBox[tab.cantidadFil, tab.cantidadCol];

            int y = 25;
            for (int i = 0; i < tab.cantidadFil; i++)
            {
                int x = 25;
                for (int j = 0; j < tab.cantidadCol; j++)
                {
                    PictureBox pictureAux = new PictureBox();
                    pictureAux.Image = seleccionarRecursoCaramelo(tab.valores[i, j]);
                    pictureAux.Location = new System.Drawing.Point(x, y);
                    pictureAux.Name = $"pictureBox{i}{j}";
                    pictureAux.Size = new System.Drawing.Size(50, 50);
                    pictureAux.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    matPictureBox[i, j] = pictureAux;
                    
                    //Mostrar en form
                    Controls.Add(pictureAux);

                    pictureAux.Click += PictureBox_Click;

                    x += 50;
                }
                y += 50;
            }
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // El evento se dispara cuando se hace clic en un PictureBox
            PictureBox carameloSeleccionado = sender as PictureBox;

            // Obtiene la posición (fila, columna) del caramelo seleccionado en el tablero
            Point posicionSeleccionada = obtenerPosicion(carameloSeleccionado);
            secuencia.Add(posicionSeleccionada);

            // Verificar si la selección forma una secuencia consecutiva válida e incrementa el puntaje según la longitud de la secuencia
            if (esSecuenciaConsecutivaValida(posicionSeleccionada))
            {
                int valorActual = int.Parse(puntaje.Text);
                int incrementoPuntaje;

                switch (secuencia.Count)
                {
                    case 3:
                        incrementoPuntaje = 6;
                        break;
                    case 4:
                        incrementoPuntaje = 10;
                        break;
                    case 5:
                        incrementoPuntaje = 15;
                        break;
                    default:
                        incrementoPuntaje = 0;
                        break;
                }

                int nuevoValor = valorActual + incrementoPuntaje;
                puntaje.Text = nuevoValor.ToString();

                eliminarCasillas();
                desplazarCaramelosAbajo();
                llenarCasillasVacias();
                actualizarAparienciaDelTablero();
                secuencia.Clear();
            }
            else
            {
                // Penaliza con -5 al puntaje si la secuencia no es válida
                int valorActual = int.Parse(puntaje.Text);
                int nuevoValor = valorActual - 5;
                puntaje.Text = nuevoValor.ToString();
                secuencia.Clear();
            }

            // Verifica si hay secuencias válidas en el tablero y termina el juego en caso de que no
            if (!verificarSecuenciasValidas())
            {
                MessageBox.Show("¡Juego terminado! No hay secuencias válidas.", "Juego terminado");
                registrarPuntaje();
                reiniciarJuego();
            }
        }

        // Método para obtener la posición (fila, columna) de un PictureBox en el tablero
        private Point obtenerPosicion(PictureBox pictureBox)
        {
            int tamanoCaramelo = 50;
            int fila = (pictureBox.Top - 25) / tamanoCaramelo;
            int columna = (pictureBox.Left - 25) / tamanoCaramelo;

            return new Point(fila, columna);
        }

        // Verifica si hay secuencias validas
        private bool esSecuenciaConsecutivaValida(Point posicion)
        {
            int x = posicion.X;
            int y = posicion.Y;
            int tipoCaramelo = tab.valores[x, y];

            bool val = true;
            bool val2 = true;
            int i = 1;
            int j = 1;
            int cont = 1;

            // Buscar en la dirección derecha de la posición actual
            while (val)
            {
                if (x + i < tab.cantidadFil && tab.valores[x + i, y] == tipoCaramelo)
                {
                    secuencia.Add(new Point(x + i, y));
                    cont++;
                    i++;
                }
                else
                {
                    val = false;
                }
            }

            // Buscar en la dirección izquierda de la posición actual
            val = true;
            i = 1;
            while (val)
            {
                if (x - i >= 0 && tab.valores[x - i, y] == tipoCaramelo)
                {
                    secuencia.Add(new Point(x - i, y));
                    cont++;
                    i++;
                }
                else
                {
                    val = false;
                }
            }

            // Verificar si hay una secuencia consecutiva válida en la dirección vertical
            if (cont > 2 && cont < 6)
            {
                return true;
            }

            secuencia.Clear();
            secuencia.Add(new Point(x, y));
            cont = 1;

            // Buscar en la dirección abajo de la posición actual
            while (val2)
            {
                if (y + j < tab.cantidadCol && tab.valores[x, y + j] == tipoCaramelo)
                {
                    secuencia.Add(new Point(x, y + j));
                    cont++;
                    j++;
                }
                else
                {
                    val2 = false;
                }
            }

            // Buscar en la dirección arriba de la posición actual
            val2 = true;
            j = 1;
            while (val2)
            {
                if (y - j >= 0 && tab.valores[x, y - j] == tipoCaramelo)
                {
                    secuencia.Add(new Point(x, y - j));
                    cont++;
                    j++;
                }
                else
                {
                    val2 = false;
                }
            }

            // Verificar si hay una secuencia consecutiva válida en la dirección horizontal
            if (cont > 2 && cont < 6)
            {
                return true;
            }

            return false;
        }

        // Marcar como espacio vacío
        private void eliminarCasillas()
        {
            foreach (Point casilla in secuencia)
            {
                tab.valores[casilla.X, casilla.Y] = -1;
            }
        }

        private void desplazarCaramelosAbajo()
        {
            // Realizar el desplazamiento mientras haya movimientos por hacer
            int movimientosRealizados;
            do
            {
                movimientosRealizados = 0;
                for (int columna = 0; columna < tab.cantidadCol; columna++)
                {
                    for (int fila = tab.cantidadFil - 2; fila >= 0; fila--)
                    {
                        if (tab.valores[fila, columna] != -1 && tab.valores[fila + 1, columna] == -1)
                        {
                            tab.valores[fila + 1, columna] = tab.valores[fila, columna];
                            tab.valores[fila, columna] = -1;
                            movimientosRealizados++;
                        }
                    }
                }
            } while (movimientosRealizados > 0);
        }

        // Generar un nuevo valor de caramelo (usando Random) y le asigna el valor a la casilla vacía
        private void llenarCasillasVacias()
        {
            Random rand = new Random();

            for (int j = 0; j < tab.cantidadCol; j++)
            {
                for (int i = tab.cantidadFil - 1; i >= 0; i--)
                {
                    if (tab.valores[i, j] == -1)
                    {
                        int nuevoCaramelo = rand.Next(6);
                        tab.valores[i, j] = nuevoCaramelo;
                    }
                }
            }
        }

        // Actualiza la imagen del PictureBox con el nuevo valor de caramelo
        private void actualizarAparienciaDelTablero()
        {
            for (int i = 0; i < tab.cantidadFil; i++)
            {
                for (int j = 0; j < tab.cantidadCol; j++)
                {
                    int valorCaramelo = tab.valores[i, j];
                    string nombrePictureBox = $"pictureBox{i}{j}";
                    PictureBox pictureBox = Controls.Find(nombrePictureBox, true).FirstOrDefault() as PictureBox;
                    pictureBox.Image = seleccionarRecursoCaramelo(valorCaramelo);
                }
            }
        }

        // Recorre todo el tablero y verifica si hay secuencias válidas
        private bool verificarSecuenciasValidas()
        {
            for (int i = 0; i < tab.cantidadFil; i++)
            {
                for (int j = 0; j < tab.cantidadCol; j++)
                {
                    if (esSecuenciaConsecutivaValida(new Point(i, j)))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void registrarPuntaje()
        {
            String nickname = this.nickname;
            int puntuacion = int.Parse(puntaje.Text);
            DateTime fecha = DateTime.Now;
            Puntaje nuevoPuntaje = new Puntaje(nickname, puntuacion, fecha);

            // Agregar el nuevo puntaje a la lista de puntajes
            mejoresPuntajes.Add(nuevoPuntaje);

            // Ordenar la lista de puntajes de mayor a menor y si la lista contiene más de 5 puntajes, eliminar el puntaje más bajo
            mejoresPuntajes = mejoresPuntajes.OrderByDescending(p => p.puntuacion).ToList();
            if (mejoresPuntajes.Count > 5)
            {
                mejoresPuntajes.RemoveAt(5);
            }

            guardarPuntajesEnArchivo();
            actualizarTableroPuntuaciones();
        }

        private void guardarPuntajesEnArchivo()
        {
            // Ruta del archivo .txt donde deseas guardar la lista de puntajes
            string rutaArchivo = "mejores_puntajes.txt";
            using (StreamWriter writer = new StreamWriter(rutaArchivo))
            {
                // Recorre la lista de puntajes y escribe cada puntaje en una línea del archivo
                foreach (Puntaje puntaje in mejoresPuntajes)
                {
                    string linea = $"{puntaje.nickname},{puntaje.puntuacion},{puntaje.fecha}";
                    writer.WriteLine(linea);
                }
            }
        }

        private void cargarPuntajesDesdeArchivo()
        {
            string rutaArchivo = "mejores_puntajes.txt";
            using (StreamReader reader = new StreamReader(rutaArchivo))
            {
                string linea;
                while ((linea = reader.ReadLine()) != null)
                {
                    // Divide cada línea en sus partes (nickname, puntuación, fecha)
                    string[] partes = linea.Split(',');

                    if (partes.Length == 3)
                    {
                        string nickname = partes[0];
                        int puntuacion = int.Parse(partes[1]);
                        DateTime fecha = DateTime.Parse(partes[2]);

                        // Crea un nuevo puntaje y agrégalo a la lista
                        mejoresPuntajes.Add(new Puntaje(nickname, puntuacion, fecha));
                    }
                }
            }
        }

        private void actualizarTableroPuntuaciones()
        {
            string puntajesTexto = "Mejores puntajes:\n";

            foreach (Puntaje puntaje in mejoresPuntajes)
            {
                string puntajeFormatado = $"{puntaje.nickname} - {puntaje.puntuacion} - {puntaje.fecha:yyyy/MM/dd}\n";

                // Agrega el puntaje formateado a la cadena de texto
                puntajesTexto += puntajeFormatado;
            }
            lblMejoresPuntajes.Text = puntajesTexto;
        }

        // Establecer todas las casillas del tablero a -1 (vacías) y las llena con nuevos caramelos
        private void reiniciarJuego()
        {
            for (int i = 0; i < tab.cantidadFil; i++)
            {
                for (int j = 0; j < tab.cantidadCol; j++)
                {
                    tab.valores[i, j] = -1;
                }
            }

            llenarCasillasVacias();
            actualizarAparienciaDelTablero();

            // Limpia la lista de selecciones
            secuencia.Clear();

            // Restablece el puntaje a cero
            puntaje.Text = "0";
        }

        // Manejar el clic en el botón de reinicio
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            reiniciarJuego();
        }

        // Volver al formulario de inicio al hacer clic en el botón "Atrás"
        private void btnAtras_Click(object sender, EventArgs e)
        {
            Inicio iniciojuego = new Inicio();
            iniciojuego.Show();
            this.Close();
        }

        private Image seleccionarRecursoCaramelo(int recurso)
        {
            switch (recurso)
            {
                case 0:
                    return global::Candy.Properties.Resources._0;
                case 1:
                    return global::Candy.Properties.Resources._1;
                case 2:
                    return global::Candy.Properties.Resources._2;
                case 3:
                    return global::Candy.Properties.Resources._3;
                case 4:
                    return global::Candy.Properties.Resources._4;
                default:
                    return global::Candy.Properties.Resources._5;
            }
        }
    }
}
