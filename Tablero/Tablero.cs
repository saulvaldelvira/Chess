using Piezas;
using Const = Constantes.Constantes;
namespace Tablero {
    
    public class Tablero {
        public static int DIM = Const.DIM;
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
            tablero[0, 0] = new Torre(Color.NEGRA);

            tablero[0, 4] = new Rey(Color.NEGRA);

            tablero[DIM-1, 0] = new Torre(Color.BLANCA);

            tablero[DIM-1, 4] = new Rey(Color.BLANCA);

        }
        /**
         * 
         */
        public bool PuedeMover(int x, int y, int nX, int nY) {
            if (nX >= Const.DIM || nY >= Const.DIM || nX < 0 || nY < 0)
                return false;
            if (x == nX && y == nY)
                return false;
            Pieza p = tablero[x, y];
            return p.Puede_Mover(nX, nY) && CompruebaColisiones(p, nX, nY);
        }

        private bool CompruebaColisiones(Pieza p, int nX, int nY) {
            switch (p.Tipo) {
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
                    for (int i = p.Y-1; i > nY; i--)
                        if (tablero[p.X, i] != null)
                            return false;
                } else {
                    for (int i = p.Y+1; i < nY; i++)
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
            return aux == null || aux.Color != p.Color;
        }
    }
}
