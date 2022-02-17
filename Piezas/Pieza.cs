using System;

namespace Piezas {
    public enum Tipo {REY, REINA, TORRE, ALFIL, CABALLO, PEON}
    public enum Color {BLANCA=1, NEGRA=0}
    public abstract class Pieza {
        public Color Color { get; private set; }
        public Tipo Tipo { get; private set; }
        public Pieza(Color c, Tipo t) {
            Color = c;
            Tipo = t;
        }
    }

    public class Torre: Pieza {
        public Torre(Color c): base(c, Tipo.TORRE){

        }
    }
}
