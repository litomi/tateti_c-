using System;
using System.Collections.Generic;

namespace tateti {
    public class Procesos {

        //Se ejecuta la jugada según el tipo de jugador
        public sbyte  hacerJugada (Jugador jugador, char[] tab) {
            if (jugador.Tipo == "Humano") {
                return juegaHumano (tab);
            } else {
                return juegaCPU (jugador.Letra, tab);
            }
        }

        private sbyte  juegaCPU (char letra, char[] tab) {
            IA computadora = new IA (letra); //CPU
            computadora.leerTablero(tab, letra);
            return computadora.JuegaCPU ();
        }

        //
        private sbyte  juegaHumano (char[] tab) {
            sbyte jugada;

            Console.Write ("Ingrese jugada: ");
            while(true) {
                sbyte.TryParse(Console.ReadLine(), out jugada);                
                
                if (jugada > 0 && jugada < 10 && Tablero.casilleroLibre (tab, (sbyte)(jugada - 1))) {
                    jugada -= 1;
                    break;
                } else {
                    Console.Write ("Reingrese (1 - 9): ");
                }

            };

            return jugada;
        }

        //Asigna letra a cada jugador
        public void asignarLetraAjugador (List<Jugador> jugadores, Jugador jugadorTurno) {

            if (jugadorTurno.Tipo == "Humano") {
                seleccionarLetraHumano (jugadorTurno);
            } else {
                seleccionarLetraCPU (jugadorTurno);
            }

            for (int i = 0; i < 2; i++) {
                if (jugadores[i].Equals (jugadorTurno)) {
                    if (i == 0) {
                        jugadores[1].Letra = jugadores[0].Letra == 'X' ? 'O' : 'X';
                    } else {
                        jugadores[0].Letra = jugadores[1].Letra == 'X' ? 'O' : 'X';
                    }
                }
            }

        }

        //Selección de letra para jugador Cpu
        private void seleccionarLetraCPU (Jugador jugador) {
            Random random = new Random ();
            char[] letras = { 'X', 'O' };
            jugador.Letra = letras[random.Next (2)];
        }

        //Selección de la letra para jugador Humano
        private void seleccionarLetraHumano (Jugador jugador) {
            char letra = ' ';
            Console.Write ("\"{0}\" seleccione una letra('X' - '0'): ", jugador.Nombre);
            do {

                char.TryParse(Console.ReadLine().ToUpper(), out letra);

                if (letra == 'X' || letra == 'O') {
                    jugador.Letra = letra;
                    break;
                } else {
                    Console.Write ("Sólo 'X' ó 'O': ");
                }
            } while (true);
        }

        //Seleccionar tipo de juego
        public sbyte  seleccionarModalidad (List<Jugador> jugadores) {
            sbyte  opc = 0;
            Mensajes.Modalidad.Menu();
            do {
                sbyte.TryParse(Console.ReadLine(), out opc);

                if (opc > 0 && opc < 4) {
                    break;
                } else {
                    Mensajes.Modalidad.ErrorElec();
                }

            } while (true);

            switch (opc) {
                case 1:
                    jugadores[0].Tipo = jugadores[1].Tipo = "Humano";
                    break;

                case 2:
                    jugadores[0].Tipo = "Humano";
                    jugadores[1].Tipo = "CPU";
                    break;

                case 3:
                    jugadores[0].Tipo = jugadores[1].Tipo = "CPU";
                    break;
            }

            // Crea el nombre de cada jugador
            jugadores[0].nombramientoAuto (1);
            jugadores[1].nombramientoAuto (2);

            Mensajes.Modalidad.Elegida(jugadores);
            return opc;
        }

    }
}