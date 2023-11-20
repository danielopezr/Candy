using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candy
{
    internal class Puntaje
    {
        public String nickname { get; set; }
        public int puntuacion { get; set; }
        public DateTime fecha { get; set; }

        public Puntaje(String nickname, int puntuacion, DateTime fecha)
        {
            this.nickname = nickname;
            this.puntuacion = puntuacion;
            this.fecha = fecha;
        }
    }
}
