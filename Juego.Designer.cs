namespace Candy
{
    partial class Juego
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.puntaje = new System.Windows.Forms.Label();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnAtras = new System.Windows.Forms.Button();
            this.lblMejoresPuntajes = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Ink Free", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(603, 154);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Puntaje:";
            // 
            // puntaje
            // 
            this.puntaje.AutoSize = true;
            this.puntaje.BackColor = System.Drawing.Color.Transparent;
            this.puntaje.Font = new System.Drawing.Font("MS UI Gothic", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.puntaje.Location = new System.Drawing.Point(699, 157);
            this.puntaje.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.puntaje.Name = "puntaje";
            this.puntaje.Size = new System.Drawing.Size(18, 18);
            this.puntaje.TabIndex = 3;
            this.puntaje.Text = "0";
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.Location = new System.Drawing.Point(604, 50);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(151, 54);
            this.btnReiniciar.TabIndex = 4;
            this.btnReiniciar.Text = "REINICIAR";
            this.btnReiniciar.UseVisualStyleBackColor = true;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnAtras
            // 
            this.btnAtras.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.Location = new System.Drawing.Point(611, 409);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(144, 53);
            this.btnAtras.TabIndex = 5;
            this.btnAtras.Text = "ATRAS";
            this.btnAtras.UseVisualStyleBackColor = true;
            this.btnAtras.Click += new System.EventHandler(this.btnAtras_Click);
            // 
            // lblMejoresPuntajes
            // 
            this.lblMejoresPuntajes.AutoSize = true;
            this.lblMejoresPuntajes.BackColor = System.Drawing.Color.Transparent;
            this.lblMejoresPuntajes.Font = new System.Drawing.Font("MS UI Gothic", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMejoresPuntajes.Location = new System.Drawing.Point(605, 219);
            this.lblMejoresPuntajes.Name = "lblMejoresPuntajes";
            this.lblMejoresPuntajes.Size = new System.Drawing.Size(78, 17);
            this.lblMejoresPuntajes.TabIndex = 6;
            this.lblMejoresPuntajes.Text = "              ";
            this.lblMejoresPuntajes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Candy.Properties.Resources.fondo;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(852, 533);
            this.Controls.Add(this.lblMejoresPuntajes);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnReiniciar);
            this.Controls.Add(this.puntaje);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1194, 580);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 580);
            this.Name = "Juego";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Candy Crush";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label puntaje;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Label lblMejoresPuntajes;
    }
}

