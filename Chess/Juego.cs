using System;
using Modelo;
namespace Chess {
    public class Juego {
        private Tablero _Tablero;
        private bool _HaTerminado;
        private Color _Turno;
        public Juego() {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            _Tablero = new Tablero();
            _HaTerminado = false;
            _Turno = Color.BLANCA;
        }
        public void Run() {
            WriteTablero();
        }
        private void Loop() {
            WriteTablero();
        }

        private void WriteTablero() {
            int i, j;
            Console.Write(" ");
            for(i=0; i<Tablero.DIM; i++)
                Console.Write("___");
            Console.Write("\n");
            for (i = 0; i < Tablero.DIM; i++) {
                Console.Write('|');
                for (j = 0; j < Tablero.DIM; j++)
                    Console.Write((_Tablero.GetPieza(i, j)==null? "  ": _Tablero.GetPieza(i, j).ToString()) +"|");
                Console.Write("\n ");
                for (j = 0; j < Tablero.DIM; j++)
                    Console.Write("___");
                Console.Write("\n");
            }
               
        }
    }
}
