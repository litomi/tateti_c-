using System;
using System.Collections.Generic;

namespace tateti {
    class Juego {

        static void Main (string[] args) {

            char[] tab = Tablero.tablero;

            Jugador jugadorDeTurno;
            Procesos procesos = new Procesos ();

            List<Jugador> jugadores = new List<Jugador> ();

            Jugador jugador_1 = new Jugador ();
            Jugador jugador_2 = new Jugador ();

            jugadores.Add (jugador_1);
            jugadores.Add (jugador_2);

            sbyte jugada;

            //Presentación
            Console.WriteLine (Mensajes.present);
            Tablero.dibujarTablero (Tablero.tab_coordenadas);

            //Seleccionar modalidad de juego
            procesos.seleccionarModalidadJuego (jugadores);

            //Sortea turno 
            jugadorDeTurno = Turno.sorteaTurno (jugadores);

            //Se asigna letra a cada jugador
            procesos.asignarLetraAjugador (jugadores, jugadorDeTurno);           

            //El bucle se quiebra si el tablero está lleno o si hay ganador.
            while (true) {
                Console.WriteLine (jugadorDeTurno.mostrarDatos ());
                jugada = procesos.hacerJugada (jugadorDeTurno, tab);
                Tablero.cargarJugada (tab, jugada, jugadorDeTurno.Letra);
                Tablero.dibujarTablero (tab);

                if (Tablero.esGanador (tab, jugadorDeTurno.Letra)) {
                    Mensajes.Resultado.Ganador(jugadorDeTurno);
                    break;
                } else {
                    if (!Tablero.tableroLleno (tab)) {
                        Turno.cambiaTurno (jugadores, ref jugadorDeTurno);
                    } else {
                        Mensajes.Resultado.Empate();
                        break;
                    }
                }
            }

            Mensajes.Fin ();

            Console.ReadLine ();

        }
    }
}