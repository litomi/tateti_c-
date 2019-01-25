using System;
using System.Collections.Generic;

namespace tateti {
    public static class Tablero {

        public static char[] tablero = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public static char[] tab_coordenadas = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        //Dibuja tablero
        public static void dibujarTablero (char[] _t) {
            string Tablero = "\t\t---------\n\t\t[{0}][{1}][{2}]\n\t\t[{3}][{4}][{5}]\n\t\t[{6}][{7}][{8}]\n\t\t---------\n";
            Console.WriteLine (Tablero, _t[0], _t[1], _t[2], _t[3], _t[4], _t[5], _t[6], _t[7], _t[8]);
        }

        //Verifica si el tablero es ganador
        public static bool esGanador (char[] t, char l) {
            return (
                //Horizontales
                (t[0] == l && t[1] == l && t[2] == l) ||
                (t[3] == l && t[4] == l && t[5] == l) ||
                (t[6] == l && t[7] == l && t[8] == l) ||

                //Verticales
                (t[0] == l && t[3] == l && t[6] == l) ||
                (t[1] == l && t[4] == l && t[7] == l) ||
                (t[2] == l && t[5] == l && t[8] == l) ||

                //Diagonales
                (t[0] == l && t[4] == l && t[8] == l) ||
                (t[2] == l && t[4] == l && t[6] == l)
            );
        }

        //Verifica si el casillero correspondiente a la jugada está libre
        public static bool casilleroLibre (char[] tablero, sbyte jugada) {
            return tablero[jugada] == ' ';
        }

        //Carga la jugada en el tablero
        public static void cargarJugada (char[] tablero, sbyte jugada, char letra) {
            tablero[jugada] = letra;
        }

        //
        public static bool tableroLleno (char[] tab) {
            sbyte contador = 0;
            foreach (char c in tab) {
                if (c != ' ') {
                    contador++;
                }
            }
            return contador == 9;
        }
    }
}