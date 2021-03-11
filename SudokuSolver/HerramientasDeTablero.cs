using System;

namespace SudokuSolver
{
    public static class HerramientasDeTablero
    {
        /// <summary>
        /// Muestra el tablero de una forma amigable.
        /// </summary>
        /// <param name="tablero">El tablero a imprimir.</param>
        public static void MostrarTablero(int[,] tablero)
        {
            for (int fila = 0; fila < tablero.GetLength(0); fila++)
            {
                // Si estoy en la cuarta fila (la número 3 contando desde 0), imprimo un separador.
                if (fila % 3 == 0 && fila != 0)
                {
                    Console.WriteLine("- - - - - - - - - - - -");
                }

                for (int columna = 0; columna < tablero.GetLength(1); columna++)
                {
                    // Si estoy en la cuarta columna, imprimo un separador.
                    if (columna % 3 == 0 && columna != 0)
                    {
                        Console.Write(" | ");
                    }

                    // Si estamos en la última columna, imprimo el valor y salto a la siguiente línea. 
                    if (columna == 8)
                    {
                        Console.WriteLine(tablero[fila, columna]);
                    }
                    // Si no, imprimo el valor y me quedo en la misma línea. 
                    else
                    {
                        Console.Write($"{tablero[fila, columna]} ");
                    }
                }
            }

            // Dejamos dos espacios luego de imprimir el tablero.
            Console.WriteLine("\n");
        }


        /// <summary>
        /// Resuelve el tablero utilizando el algoritmo backtracking (recursivo).
        /// </summary>
        /// <param name="tablero">El tablero a resolver.</param>
        /// <returns><c>true</c> si se pudo resolver el tablero; <c>false</c> en caso contrario.</returns>
        public static bool Resolver(int[,] tablero)
        {
            // Buscamos una celda vacía.
            Posicion posicion = BuscarCeldaVacia(tablero);

            // Caso base: no encontré celda vacía. Terminé.
            if (posicion == null)
            {
                return true;
            }
            // Encontré una celda vacía para insertar un número.
            else
            {
                for (int numero = 1; numero <= 9; numero++)
                {
                    // Si puedo ingresar ese número en esa posición...
                    if (InsercionValida(tablero, numero, posicion))
                    {
                        // lo ingreso...
                        tablero[posicion.Fila, posicion.Columna] = numero;

                        // e intento resolver el tablero desde esta posición. 
                        if (Resolver(tablero))
                        {
                            return true;
                        }

                        // Si no pude ... dejo esa celda en 0. 
                        tablero[posicion.Fila, posicion.Columna] = 0;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// Itera por el tablero y busca una celda vacía (que tenga un 0).
        /// </summary>
        /// <param name="tablero">El tablero en el cual se quiere buscar una celda.</param>
        /// <returns>Una <c>Posicion</c>, que contiene la fila y la columna de la celda vacía.</returns>
        private static Posicion BuscarCeldaVacia(int[,] tablero)
        {
            // Obtengo la cantidad de filas y columnas del tablero.
            int cantidadDeFilas = tablero.GetLength(0);
            int cantidadDeColumnas = tablero.GetLength(1);

            // Paso por todas las filas.
            for (int fila = 0; fila < cantidadDeFilas; fila++)
            {
                // Por cada fila, me fijo todas sus columnas.
                for (int columna = 0; columna < cantidadDeColumnas; columna++)
                {
                    // Si encuentro una posición con un 0, retorno esa posición.
                    if (tablero[fila, columna] == 0)
                    {
                        return new Posicion() { Fila = fila, Columna = columna };
                    }
                }
            }

            // Si no encontré nada, retorno null.
            return null;
        }


        /// <summary>
        /// Chequea si el número que se quiere ingresar en la posición no interfiere
        /// con otras filas, columnas o cuadrados. 
        /// </summary>
        /// <param name="numero">El número a ingresar en la celda.</param>
        /// <param name="posicion">La posición de la celda donde se ingresará el número.</param>
        /// <param name="tablero">El tablero a resolver.</param>
        private static bool InsercionValida(int[,] tablero, int numero, Posicion posicion)
        {
            bool filasOK = ChequearFilas(tablero, numero, posicion);
            bool columnasOK = ChequearColumnas(tablero, numero, posicion);
            bool cuadradosOK = ChequearCuadrados(tablero, numero, posicion);

            return filasOK && columnasOK && cuadradosOK;
        }


        /// <summary>
        /// Determina si el número que se quiere ingresar no se repite en la columna. 
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="numero"></param>
        /// <param name="posicion"></param>
        /// <returns><c>true</c> si se pudo resolver el tablero; <c>false</c> en caso contrario.</returns>
        private static bool ChequearFilas(int[,] tablero, int numero, Posicion posicion)
        {
            // Obtengo la cantidad de filas del tablero. 
            int cantidadDeFilas = tablero.GetLength(0);

            // Me paro en una columna y recorro todas sus filas (de arriba hacia abajo). 
            for (int fila = 0; fila < cantidadDeFilas; fila++)
            {
                // Si el número que quiero ingresar ya se encuentra en esa columna, no puedo
                // ingresarlo. 
                if (tablero[fila, posicion.Columna] == numero && posicion.Fila != fila)
                {
                    return false;
                }
            }

            // Si no está en esa columna, si puedo ingresarlo.
            return true;
        }


        /// <summary>
        /// Determina si el número que se quiere ingresar no se repite en la fila. 
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="numero"></param>
        /// <param name="posicion"></param>
        /// <returns><c>true</c> si se pudo resolver el tablero; <c>false</c> en caso contrario.</returns>
        private static bool ChequearColumnas(int[,] tablero, int numero, Posicion posicion)
        {
            // Obtengo la cantidad de filas del tablero. 
            int cantidadDeColumnas = tablero.GetLength(1);

            // Me paro en una fila y recorro todas sus columnas (de izquierda a derecha). 
            for (int columna = 0; columna < cantidadDeColumnas; columna++)
            {
                // Si el número que quiero ingresar ya se encuentra en esa fila, no puedo
                // ingresarlo. 
                if (tablero[posicion.Fila, columna] == numero && posicion.Columna != columna)
                {
                    return false;
                }
            }

            // Si no está en esa fila, si puedo ingresarlo.
            return true;
        }


        /// <summary>
        /// Determina si el número que se quiere ingresar no se repite en un cuadrado interno.
        /// </summary>
        /// <param name="tablero"></param>
        /// <param name="numero"></param>
        /// <param name="posicion"></param>
        /// <returns><c>true</c> si se puede ingresar el número; <c>false</c> en caso contrario.</returns>
        private static bool ChequearCuadrados(int[,] tablero, int numero, Posicion posicion)
        {
            // Me fijo dónde comienza y termina el cuadrado. 
            int filaInicioCuadrado = (posicion.Fila / 3) * 3, filaFinCuadrado = filaInicioCuadrado + 3;
            int columnaInicioCuadrado = (posicion.Columna / 3) * 3, columnaFinCuadrado = columnaInicioCuadrado + 3;

            // Recorro sus tres filas.
            for (int fila = filaInicioCuadrado; fila < filaFinCuadrado; fila++)
            {
                // Recorro sus tres columnas.
                for (int columna = columnaInicioCuadrado; columna < columnaFinCuadrado; columna++)
                {
                    // Si el número que quiero insertar ya se encuentra en el cuadrado, no puedo insertarlo.
                    if (tablero[fila, columna] == numero && posicion.Fila != fila && posicion.Columna != columna)
                    {
                        return false;
                    }
                }
            }

            // Si no se encuentra en el cuadrado, si lo puedo insertar.
            return true;
        }


    }
}
