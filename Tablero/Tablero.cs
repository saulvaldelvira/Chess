using Piezas;

namespace Tablero {
    internal struct Numero_Piezas {
        const int REY = 1;
        const int REINA = 1;
        const int TORRE = 2;
        const int ALFIL = 2;
        const int CABALLO = 2;
        const int PEON = 8;
    }
    public class Tablero {
        private Pieza[,] tablero;
        public Tablero() {
            tablero = new Pieza[8,8];
            InicializaTablero();
        }

        private void InicializaTablero() {
            for (int i = 0; i < tablero.Length; i++)
                for (int j = 0; j < tablero.Length; j++)
                    tablero[i, j] = null;
            tablero[0, 0] = new Pieza(Color.NEGRA, Tipo.TORRE);
        }
    }
}
