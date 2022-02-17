using System;
using Const = Constantes.Constantes;
using util = Util.Util;
namespace Piezas {
    public enum Tipo {REY, REINA, TORRE, ALFIL, CABALLO, PEON}
    public enum Color {BLANCA=1, NEGRA=0}
    public abstract class Pieza {
        public Color Color { get; private set; }
        public Tipo Tipo { get; private set; }
        public int X { get; protected set; }
        public int Y { get; protected set; }
        public Pieza(Color c, Tipo t) {
            Color = c;
            Tipo = t;
        }
        public void Mover(int x, int y) {
            X = x;
            Y = y;
        }
        public abstract bool Puede_Mover(int x, int y);
    }

    public class Torre : Pieza {
        public Torre(Color c) : base(c, Tipo.TORRE) { }
        public override bool Puede_Mover(int x, int y) {
            return !(x != X && y != Y);
        }
    }

    public class Rey: Pieza {
        public Rey(Color c): base(c, Tipo.REY) { }
        public override bool Puede_Mover(int x, int y) {
            return util.Abs(x)<=1 && util.Abs(y)<=1;
        }
    }

    public class Reina: Pieza {
        public Reina(Color c): base (c, Tipo.REINA) { }
        public override bool Puede_Mover(int x, int y) {
            
        }
    }
}
