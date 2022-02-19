using System;

namespace Modelo {
    public enum Tipo { REY, REINA, TORRE, ALFIL, CABALLO, PEON }
    public enum Color { BLANCA = 1, NEGRA = 0 }
    /**
     * Clase abstracta Pieza
     */
    public abstract class Pieza {
        public Color _Color { get; private set; }
        public Tipo _Tipo { get; private set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Tablero _Tablero { get; }
        public Pieza(Color c, Tipo t, Tablero tab) {
            _Color = c;
            _Tipo = t;
            _Tablero = tab;
        }
        /**
         * Actualiza el valor de X e Y
         */
        public void Mover(int x, int y) {
            X = x;
            Y = y;
        }
        public abstract bool Puede_Mover(int x, int y);
        public bool EsLineaRecta(int x, int y) {
            return !(x != X && y != Y);
        }
        public bool EsDiagonal(int x, int y) {
            return Abs(x - X) == Abs(y - Y);
        }
        protected static int Abs(int i) {
            return i < 0 ? -i : i;
        }
    }
    public class Torre: Pieza {
        public Torre(Color c, Tablero tab) : base(c, Tipo.TORRE, tab) { }
        public override bool Puede_Mover(int x, int y) {
            return EsLineaRecta(x, y);
        }
    }
    public class Rey: Pieza {
        public Rey(Color c, Tablero tab) : base(c, Tipo.REY, tab) { }
        public override bool Puede_Mover(int x, int y) {
            return Abs(x) <= 1 && Abs(y) <= 1;
        }
    }
    public class Reina: Pieza {
        public Reina(Color c, Tablero tab) : base(c, Tipo.REINA, tab) { }
        public override bool Puede_Mover(int x, int y) {
            return EsLineaRecta(x, y) || EsDiagonal(x, y);
        }
    }
    public class Alfil: Pieza {
        public Alfil(Color c, Tablero tab) : base(c, Tipo.ALFIL, tab) { }
        public override bool Puede_Mover(int x, int y) {
            return EsDiagonal(x, y);
        }
    }
    public class Peon: Pieza {
        public Peon(Color c, Tablero tab) : base(c, Tipo.PEON, tab) { }
        public override bool Puede_Mover(int x, int y) {
            if (Abs(x - X) == 1) {
                if (_Color == Color.NEGRA)
                    if (y - Y == -1 && _Tablero.GetPieza(x, y) != null && _Tablero.GetPieza(x, y)._Color == Color.BLANCA)
                        return true;
                else
                    if(y-Y == 1 && _Tablero.GetPieza(x, y) != null && _Tablero.GetPieza(x, y)._Color == Color.NEGRA)
                        return true;
            }
            if (x == X) {
                if (_Color == Color.NEGRA)
                    if (y - Y == -1)
                        return true;
               else
                   if (y - Y == 1)
                       return true;
            }
            return false;
        }
    }
    public class Caballo: Pieza {
        public Caballo(Color c, Tablero tab) : base(c, Tipo.ALFIL, tab) { }
        public override bool Puede_Mover(int x, int y) {
            bool result = Abs(y - Y) == 2 && Abs(x - X) == 1;
            result = result || (Abs(y - Y) == 1 && Abs(x - X) == 2);
            return result;
        }
    }
}
