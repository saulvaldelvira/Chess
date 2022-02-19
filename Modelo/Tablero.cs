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
            tablero[0, 1] = new Caballo(Color.NEGRA, this);
            tablero[0, 2] = new Alfil(Color.NEGRA, this);
            tablero[0, 3] = new Reina(Color.NEGRA, this);
            tablero[0, 4] = new Rey(Color.NEGRA, this);
            tablero[0, 5] = new Alfil(Color.NEGRA, this);
            tablero[0, 6] = new Caballo(Color.NEGRA, this);
            tablero[0, 7] = new Torre(Color.NEGRA, this);

            for (int i = 0; i < DIM; ++i) {
                tablero[1, i] = new Peon(Color.NEGRA, this);
                tablero[6, i] = new Peon(Color.BLANCA, this);
            }

            tablero[7, 0] = new Torre(Color.BLANCA, this);
            tablero[7, 1] = new Caballo(Color.BLANCA, this);
            tablero[7, 2] = new Alfil(Color.BLANCA, this);
            tablero[7, 3] = new Reina(Color.BLANCA, this);
            tablero[7, 4] = new Rey(Color.BLANCA, this);
            tablero[7, 5] = new Alfil(Color.BLANCA, this);
            tablero[7, 6] = new Caballo(Color.BLANCA, this);
            tablero[7, 7] = new Torre(Color.BLANCA, this);

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
            if (tablero[nX, nY]!=null && p._Color == tablero[nX, nY]._Color)
                return false;
            return p.Puede_Mover(nX, nY) && CompruebaColisiones(p, nX, nY);
        }
        private bool CompruebaColisiones(Pieza p, int nX, int nY) {
            switch (p._Tipo) {
                case Tipo.TORRE:
                    return CompruebaColisionesLineaRecta(p, nX, nY);
                case Tipo.REY:
                    return true;
                case Tipo.REINA:
                    if (p.EsDiagonal(nX, nY))
                        return CompruebaColisionesDiagonales(p, nX, nY);
                    else
                        return CompruebaColisionesLineaRecta(p, nX, nY);
                case Tipo.ALFIL:
                    return CompruebaColisionesDiagonales(p, nX, nY);
                case Tipo.CABALLO:
                    return true;
                case Tipo.PEON:
                    return true;
            }
            return false;
        }
        private bool CompruebaColisionesLineaRecta(Pieza p, int nX, int nY) {
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
        private bool CompruebaColisionesDiagonales(Pieza p, int nX, int nY) {
            if (p.X < nX) {
                if (p.Y < nY) {
                    for(int i = p.X + 1, j = p.Y + 1; j < nY && i<nX; j++, i++) {
                        if (tablero[i,j] != null)
                            return false;
                    }
                } else {
                    for (int i = p.X + 1, j = p.Y - 1; j > nY && i < nX; j--, i++) {
                        if (tablero[i, j] != null)
                            return false;
                    }
                }
            } else {
                if(p.Y > nY) {
                    for (int i = p.X - 1, j = p.Y - 1; j > nY && i > nX; j--, i--) {
                        if (tablero[i, j] != null)
                            return false;
                    }
                } else {
                    for (int i = p.X - 1, j = p.Y + 1; j < nY && i > nX; j++, i--) {
                        if (tablero[i, j] != null)
                            return false;
                    }
                }
            }
            return true;
        }
    }

}
