using System;
using System.Collections.Generic;

namespace tateti {
    public static class Mensajes {

        private static string marco = "\n\t{0}\n\t{1}\n\t{2}\n\t{3}\n\t{0}\n";
        public static string present = String.Format (marco,
            "======================================",
            "Juego del TA-TE-TÍ",
            "Gana quién complete una línea vertical",
            "horizontal o diagonal"
        );

        public static class Resultado {

            public static void Ganador (Jugador ganador) {
                Console.WriteLine ("\t¡El ganador es ({0}){1}!", ganador.Letra, ganador.Nombre);
            }

            public static void Empate () {
                Console.SetCursorPosition(50, 50);
                Console.WriteLine ("\tNo hay ganador, es un empate.");
            }

        }
        public static void Fin () {
            Console.WriteLine ("\nFIN DEL PROGRAMA.\n");
        }

        public static class Modalidad {

            public static void Menu () {
                Console.WriteLine ("Menú de modalidad:");
                Console.WriteLine ("\t1.- Jugador vs Jugador\n\t2.- Jugador vs CPU\n\t3.- CPU vs CPU");
                Console.Write ("\t>>  ");
            }

            public static void ErrorElec () {
                Console.Write ("Selecccione entre 1 y 3: ");
            }

            public static void Elegida (List<Jugador> jugadores) {
                string esqueleto = "\n{0}\n'{1}' contra '{2}'\n{3}\n";

                Console.WriteLine (
                    esqueleto,
                    "-------------------Modalidad-----------------------",
                    jugadores[0].Nombre.ToUpper (),
                    jugadores[1].Nombre.ToUpper (),
                    "---------------------------------------------------"
                );

            }

        }

    }
}