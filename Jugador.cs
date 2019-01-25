using System;
namespace tateti
{
    public class Jugador{
        public string Nombre { get; set; }

        //Letra con la que juega
        public char Letra{ get; set;}

        //Humano - Cpu
        public string Tipo{ get; set;}

        public void nombramientoAuto(sbyte contador){
            Nombre = string.Format("Jugador {0}({1})", contador, Tipo);
        }

        public string mostrarDatos(){
            return String.Format("{0} -> '{1}'", Nombre, Letra );
        }
    }
}