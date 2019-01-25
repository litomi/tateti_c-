using System;
namespace tateti
{
    public class Jugador{
        private static int contador = 1;

        public string Nombre { get; set; }

        public char Letra{ get; set;}

        public string Tipo{ get; set;}

        public void nombramientoAuto () {
            Nombre = string.Format ("{0}_{1}", (Tipo == "Humano")?"Humano":"CPU", contador);
            contador++;
        }

        public string mostrarDatos(){
            return String.Format("{0} -> '{1}'", Nombre, Letra );
        }
    }
}