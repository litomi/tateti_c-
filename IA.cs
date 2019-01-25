using System;

namespace tateti {
    public class IA {
        private int[, ] matrizAmiga = new int[3, 3];
        private int[, ] matrizEnemiga = new int[3, 3];
        private int[, ] m_123 = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 } };
        private int[] casillerosLibres;

        public char Letra { get; set; }

        private int[, ] tuplas_riesgo = { { 0, 1, 1 }, { 1, 0, 1 }, { 1, 1, 0 } };

        //Constructor
        public IA (char letra) {
            Letra = letra;
        }

        //Lee tablero-vector char[]- y convierte a matrices de enteros
        public void leerTablero (char[] tablero, char letra) {
            sbyte contador_1 = 0, contador_2 = 0;
            int[] tempCasillerosLibres = new int[9];

            for (sbyte f = 0; f < 3; f++) {

                for (sbyte c = 0; c < 3; c++) {

                    //Carga valores en una matriz bidimensional según casilleros 'amigos' ocupados
                    matrizAmiga[f, c] = (tablero[contador_1] == letra) ? 1 : 0;

                    //Carga valores en una matriz bidimensional según casilleros 'enemigos' ocupados
                    matrizEnemiga[f, c] = (tablero[contador_1] != letra && tablero[contador_1] != ' ') ? 1 : 0;

                    //Casilleros libres
                    if (tablero[contador_1] == ' ') {
                        tempCasillerosLibres[contador_2++] = m_123[f, c];
                    }

                    contador_1++; //incrementa contador

                }
            }
            casillerosLibres = new int[contador_2];
            for (sbyte i = 0; i < casillerosLibres.Length; i++) {
                casillerosLibres[i] = tempCasillerosLibres[i];
            }
        }

        //
        private bool tableroEmpezado () {
            for (sbyte f = 0; f < 3; f++) {
                for (sbyte c = 0; c < 3; c++) {
                    if (matrizAmiga[f, c] != ' ' || matrizEnemiga[f, c] != ' ') {
                        return true;
                    }
                }
            }
            return false;
        }

        //Revisa si alguna línea tiene dos casilleros ocupados por la misma letra
        //y sugiere una jugada
        private sbyte evaluaTablero (int[, ] matriz) {

            for (sbyte f = 0; f < 3; f++) {
                for (sbyte c = 0; c < 3; c++) {
                    //Filas
                    if (
                        matriz[f, 0] == tuplas_riesgo[c, 0] &&
                        matriz[f, 1] == tuplas_riesgo[c, 1] &&
                        matriz[f, 2] == tuplas_riesgo[c, 2]
                    ) {
                        if (this.esCasillaLibre ((sbyte) m_123[f, c])) {
                            return (sbyte) m_123[f, c];
                        }
                    }

                    //Columnas
                    if (
                        matriz[0, f] == tuplas_riesgo[c, 0] &&
                        matriz[1, f] == tuplas_riesgo[c, 1] &&
                        matriz[2, f] == tuplas_riesgo[c, 2]
                    ) {
                        if (this.esCasillaLibre ((sbyte) m_123[c, f])) {
                            return (sbyte) m_123[c, f];
                        }
                    }

                    //Diagonal principal
                    if (
                        matriz[0, 0] == tuplas_riesgo[c, 0] &&
                        matriz[1, 1] == tuplas_riesgo[c, 1] &&
                        matriz[2, 2] == tuplas_riesgo[c, 2] &&
                        f == 0
                    ) {
                        if (this.esCasillaLibre ((sbyte) m_123[c, c])) {
                            return (sbyte) m_123[c, c];
                        }
                    }

                    //Diagonal secundaria
                    if (
                        matriz[0, 2] == tuplas_riesgo[c, 0] &&
                        matriz[1, 1] == tuplas_riesgo[c, 1] &&
                        matriz[2, 0] == tuplas_riesgo[c, 2] &&
                        f == 0
                    ) {
                        if (this.esCasillaLibre ((sbyte) m_123[c, 2 - c])) {
                            return (sbyte) m_123[c, 2 - c];
                        }
                    }
                }
            }

            return -1;
        }

        private sbyte juegaEnEsquina () {

            int[] esquinas = { 0, 2, 6, 8 };

            foreach (sbyte esq in esquinas) {
                if (this.esCasillaLibre (esq)) {
                    return esq;
                }
            }

            return -1;
        }

        public bool esCasillaLibre (sbyte jugada) {
            foreach (sbyte c in casillerosLibres) {
                if (jugada == c) {
                    return true;
                }
            }
            return false;
        }

        public sbyte JuegaCPU () {
            sbyte jugada;
            Random random = new Random ();
            /*
                -Si tablero empezado:
                    -Ver estado tablero Enemigo
                    -Si hay riesgo
                            -Jugar para defender
                    Sino: 
                        -Ver estado tablero Amigo
                        -Si hay líneas casi completas
                            -Jugar a ganar.
                        -Sino:                            
                            Si centro vacío:
                                -Jugar en el centro                                         
                            -Sino:
                                -Sí esquinas disponibles
                                   -Jugar esquina
                                -Sino:
                                    Jugar al azar en casilleros libres
                                -FinSi
                            -FinSi
                        -FinSi
                    -FinSi
                -Sino:
                    -Jugar en el centro
                -FinSi
            */

            if (tableroEmpezado ()) {
                jugada = evaluaTablero (matrizAmiga);
                if (jugada != -1) {
                    return jugada;
                } else {
                    jugada = evaluaTablero (matrizEnemiga);
                    if (jugada != -1) {
                        return jugada;
                    } else {
                        if (this.esCasillaLibre (4)) {
                            return 4;
                        } else {
                            jugada = juegaEnEsquina ();
                            if (jugada != -1) {
                                return jugada;
                            } else {
                                return (sbyte) casillerosLibres[random.Next (casillerosLibres.Length)];
                            }
                        }
                    }
                }
            } else {
                return 4;
            }
        }
    }
}