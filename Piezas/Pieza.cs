using System;
namespace Piezas {
    public enum Tipo { REY, REINA, TORRE, ALFIL, CABALLO, PEON }
    public enum Color { BLANCA = 1, NEGRA = 0 }
    /**
     * Clase abstracta Pieza
     */
    public abstract class Pieza {
        public Color Color { get; private set; }
        public Tipo Tipo { get; private set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Pieza(Color c, Tipo t) {
            Color = c;
            Tipo = t;
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
        public Torre(Color c) : base(c, Tipo.TORRE) { }
        public override bool Puede_Mover(int x, int y) {
            return EsLineaRecta(x, y);
        }
    }

    public class Rey: Pieza {
        public Rey(Color c) : base(c, Tipo.REY) { }
        public override bool Puede_Mover(int x, int y) {
            return Abs(x) <= 1 && Abs(y) <= 1;
        }
    }
    public class Reina: Pieza {
        public Reina(Color c) : base(c, Tipo.REINA) { }
        public override bool Puede_Mover(int x, int y) {
            return EsLineaRecta(x, y) || EsDiagonal(x, y);
        }
    }
    public class Alfil: Pieza {
        public Alfil(Color c) : base(c, Tipo.ALFIL) { }
        public override bool Puede_Mover(int x, int y) {
            return EsDiagonal(x, y);
        }
    }
    public class Peon: Pieza {
        public Peon(Color c) : base(c, Tipo.PEON) { }
        public override bool Puede_Mover(int x, int y) {
            if(Abs(x-X) == 1 && )
            return Abs(y - Y) == 1;
        }

        public override bool Puede_Mover(int x, int y, Tablero t) {
            if (Abs(x - X) == 1 && )
                return Abs(y - Y) == 1;
        }
    }
}
