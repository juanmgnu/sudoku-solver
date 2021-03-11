using System;

namespace SudokuSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sólo sirve para sudokus de 9x9, pero se podría adaptar a otros. 

            int[,] sudokuVacio = new int[,]
            {
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                                       
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                                       
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 }
            };

            int[,] sudokuFacil = new int[,]
            {
                { 7, 8, 0,   4, 0, 0,   1, 2, 0 },
                { 6, 0, 0,   0, 7, 5,   0, 0, 9 },
                { 0, 0, 0,   6, 0, 1,   0, 7, 8 },

                { 0, 0, 7,   0, 4, 0,   2, 6, 0 },
                { 0, 0, 1,   0, 5, 0,   9, 3, 0 },
                { 9, 0, 4,   0, 6, 0,   0, 0, 5 },

                { 0, 7, 0,   3, 0, 0,   0, 1, 2 },
                { 1, 2, 0,   0, 0, 7,   4, 0, 0 },
                { 0, 4, 9,   2, 0, 6,   0, 0, 7 }
            };

            int[,] sudokuFacilMalo = new int[,]
{
                { 7, 1, 0,   4, 0, 0,   1, 2, 0 },
                { 6, 1, 0,   0, 7, 5,   0, 0, 9 },
                { 0, 0, 0,   6, 0, 1,   0, 7, 8 },

                { 0, 0, 7,   0, 4, 0,   2, 6, 0 },
                { 0, 0, 1,   0, 1, 0,   9, 3, 0 },
                { 9, 0, 4,   0, 6, 0,   0, 0, 5 },

                { 0, 7, 0,   3, 1, 0,   0, 1, 2 },
                { 1, 2, 0,   0, 0, 7,   4, 0, 1 },
                { 0, 4, 9,   2, 0, 6,   0, 1, 7 }
};

            int[,] sudokuDificil = new int[,]
            {
                { 0, 0, 6,   0, 1, 0,   0, 0, 0 },
                { 0, 2, 0,   0, 0, 9,   0, 0, 0 },
                { 5, 7, 0,   0, 0, 0,   0, 0, 0 },
                                        
                { 0, 0, 1,   2, 6, 0,   0, 4, 8 },
                { 0, 0, 0,   0, 0, 3,   0, 7, 0 },
                { 0, 0, 0,   0, 0, 0,   0, 0, 0 },
                                        
                { 6, 0, 0,   0, 4, 1,   0, 8, 0 },
                { 0, 0, 0,   3, 0, 0,   0, 0, 2 },
                { 0, 3, 4,   0, 9, 0,   0, 0, 6 }
            };

            int[,] sudokuExperto = new int[,]
            {
                { 8, 2, 0,   0, 5, 0,   0, 9, 1 },
                { 4, 0, 0,   2, 0, 0,   0, 0, 3 },
                { 0, 0, 0,   0, 0, 9,   0, 0, 0 },

                { 0, 6, 0,   8, 0, 0,   2, 0, 0 },
                { 3, 0, 0,   0, 6, 0,   0, 0, 8 },
                { 0, 0, 8,   0, 0, 5,   0, 7, 0 },

                { 0, 0, 0,   6, 0, 0,   0, 0, 0 },
                { 1, 0, 0,   0, 0, 7,   0, 0, 2 },
                { 2, 8, 0,   0, 9, 0,   0, 4, 7 }
            };

            Console.WriteLine("Tablero original:\n");
            HerramientasDeTablero.MostrarTablero(sudokuFacil);

            bool ok = HerramientasDeTablero.Resolver(sudokuFacil);

            Console.WriteLine($"¿Se pudo resolver el tablero? {ok}\nNuevo tablero:\n");
            HerramientasDeTablero.MostrarTablero(sudokuFacil);
        }
    }
}
