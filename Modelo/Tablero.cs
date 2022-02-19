using System;

namespace Modelo {
    public struct Numero_Piezas {
        const int REY = 1;
        const int REINA = 1;
        const int TORRE = 2;
        const int ALFIL = 2;
        const int CABALLO = 2;
        const int PEON = 8;
    }
    public class Tablero {
        public static int DIM = 8;
        private Pieza[,] tablero;
        public Tablero() {
            tablero = new Pieza[DIM, DIM];
            InicializaTablero();
        }
        /**
         * Inicializa el tablero a su estado inicial.
         */
        private void InicializaTablero() {
            for (int i = 0; i < DIM; i++)
                for (int j = 0; j < DIM; j++)
                    tablero[i, j] = null;
            tablero[0, 0] = new Torre(Color.NEGRA, this);

            tablero[0, 4] = new Rey(Color.NEGRA, this);

            tablero[DIM - 1, 0] = new Torre(Color.BLANCA, this);

            tablero[DIM - 1, 4] = new Rey(Color.BLANCA, this);

        }
        public Pieza GetPieza(int x, int y) {
            return tablero[x, y];
        }
        /**
         * 
         */
        public bool PuedeMover(int x, int y, int nX, int nY) {
            if (nX >= DIM || nY >= DIM || nX < 0 || nY < 0)
                return false;
            if (x == nX && y == nY)
                return false;
            Pieza p = tablero[x, y];
            return p.Puede_Mover(nX, nY) && CompruebaColisiones(p, nX, nY);
        }

        private bool CompruebaColisiones(Pieza p, int nX, int nY) {
            switch (p._Tipo) {
                case Tipo.TORRE:
                    return CompruebaColisionesTorre(p, nX, nY);
                case Tipo.REY:
                    return CompruebaColisionesRey(p, nX, nY);
            }
            return false;
        }
        private bool CompruebaColisionesTorre(Pieza p, int nX, int nY) {
            if (p.X == nX) {
                if (nY < p.Y) {
                    for (int i = p.Y - 1; i > nY; i--)
                        if (tablero[p.X, i] != null)
                            return false;
                } else {
                    for (int i = p.Y + 1; i < nY; i++)
                        if (tablero[p.X, i] != null)
                            return false;
                }
            } else {
                if (nX < p.X) {
                    for (int i = p.X - 1; i > nX; i--)
                        if (tablero[i, p.Y] != null)
                            return false;
                } else {
                    for (int i = p.X + 1; i < nX; i++)
                        if (tablero[i, p.Y] != null)
                            return false;
                }
            }
            return true;
        }
        private bool CompruebaColisionesRey(Pieza p, int nX, int nY) {
            Pieza aux = tablero[nX, nY];
            return aux == null || aux._Color != p._Color;
        }
    }

}
