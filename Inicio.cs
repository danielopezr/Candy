using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Candy
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        // Maneja el evento Click del botón "Inicio" para ir al formulario de juego.
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Verifica si los espacios de texto están vacíos y asigna valores predeterminados
            if (string.IsNullOrWhiteSpace(txtNickname.Text))
            {
                txtNickname.Text = "GHEST";
            }

            String nickname = txtNickname.Text;
            Juego juegoCandy = new Juego(nickname);
            juegoCandy.Show();
            this.Hide();
        }

        // Evita que se ingresen caracteres que no son letras (excepto la tecla de retroceso) y limita a 5 el numero de letras
        private void txtNickname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }

            if (txtNickname.Text.Length >= 5 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        // Convierte automáticamente el texto ingresado a mayúsculas y establece el cursor al final del texto
        private void txtNickname_TextChanged(object sender, EventArgs e)
        {
            txtNickname.Text = txtNickname.Text.ToUpper();
            txtNickname.SelectionStart = txtNickname.Text.Length;
        }
    }
}
