using System;
using System.Collections.Generic;

namespace tateti
{
    public static class Turno {
        
        public static Jugador sorteaTurno(List<Jugador> jugadores){
            Random random = new Random();
            return jugadores[random.Next(2)];
        }

        public static void cambiaTurno(List<Jugador> jugadores, ref Jugador jugador){
            jugador = (jugadores[0] == jugador)? jugadores[1]:jugadores[0];
        }
    }
}