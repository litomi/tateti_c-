using System;
using System.Collections.Generic;

namespace tateti
{
    public static class Turno {
        
        //Devuelve un jugador para el primer turno
        public static Jugador sorteaTurno(List<Jugador> jugadores){
            Random random = new Random();
            return jugadores[random.Next(2)];
        }

        //Devuelve un jugador diferente para el siguiente turno
        public static void cambiarTurno(List<Jugador> jugadores, ref Jugador jugador){
            jugador = (jugadores[0] == jugador)? jugadores[1]:jugadores[0];
        }
    }
}