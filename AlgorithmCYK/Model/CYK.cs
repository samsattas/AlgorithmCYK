using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmCYK.model
{
    class CYK
    {
        private string input;
        private string[] grammar;

        public CYK(string inp, string[] inpG)
        {
            this.input = inp;
            this.grammar = inpG;
        }

        public string start()
        {
            //el tamaño de w para crear la matriz
            int size = input.Length;

            //se crea una matrix 2D del tamaño del numero de instrucciones por 2
            //grammarList sera la lista de instrucciones introducidas
            string[,] grammarlist = new String[grammar.Length, 2];
            Console.WriteLine(grammar.Length);
            Console.WriteLine(grammar.GetLength(0));

            /*creo la matriz 3D, 
            una dimension para las 'i' 
            otra para las 'j' 
            y otra para guardar las instrucciones (ej: X13 = A,C,E ; se guarda en i=1, j=3 los A,C,E)
            */
            string[,,] matrix = new String[size + 1, size, grammarlist.GetLength(0)];


            //recorre cada uno de los elementos de w
            for (int i = 0; i < input.Length; i++)
            {
                //se usa el substring para ir una por una en cada una de las letras de w
                matrix[size, i, 0] = input.Substring(i, 1);
            }
            for (int i = 0; i < grammar.Length; i++)
            {

                /*
                 * S->AB
                 */

                //obtiene el representante de la instruccion (ej: S)
                grammarlist[i, 0] = grammar[i].Substring(0, 1);// se obtiene la posicion 0 de la instruccion i de la lista de instrucciones

                //Obtiene el resultado de la instruccion (ej: AB)
                grammarlist[i, 1] = grammar[i].Substring(grammar[i].IndexOf("->") + 2); //el substring se mueve 2 para saltar el '->'
            }

            /* GetLength(n) en un array 3D:
             * dimension x -> n=0
             * dimension y -> n=1
             * dimension z -> n=3
             */

            //Pasa primero por cada una de las instrucciones de abajo hacia arriba (de Xn1 a X11)
            for (int j = matrix.GetLength(0) - 1; j > 0; j--)
            {
                if (j == size)
                {
                    //Pasa por los elementos de la cadena w
                    for (int i = 0; i < matrix.GetLength(1); i++)
                    {
                        int num = 0;

                        //recorre todas las instrucciones en busca de la letra minuscula
                        for (int k = 0; k < grammarlist.GetLength(0); k++)
                        {
                            string[] auxString = grammarlist[k, 1].Split('|');
                            for (int y = 0; y < auxString.Length; y++)
                            {
                                if (matrix[j, i, 0] == auxString[y])
                                {
                                    matrix[j - 1, i, num] = grammarlist[k, 0];
                                    num++;
                                }
                            }

                        }
                    }
                }
                else
                {
                    for (int i = 0; i < j; i++)
                    {    //Caducar celdas de una fila

                        //se mueve en la dimension 1, donde cambia es la i de Xij
                        for (int k = matrix.GetLength(0) - 2; k >= j; k--)
                        {    //Columna de búsqueda de abajo hacia arriba (vertical)

                            //se mueve por la diagonal de la matriz acendentemente
                            for (int m = 0; m <= matrix.GetLength(0) - j - 2; m++)
                            {    //Corre en diagonal de arriba a abajo (diagonal)

                                //se mueve por cada uno de los elementos del Xij 
                                for (int l = 0; l < matrix.GetLength(2); l++)
                                {  //ver todos los caracteres en la celda (vertical)

                                    //se verifica que no este vacio el Xij 
                                    if (matrix[k, i, l] != null)
                                    {

                                        //pasa por todos los elementos de Xij
                                        for (int n = 0; n < matrix.GetLength(2); n++)
                                        {  //ver todos los caracteres en la celda (diagonal)
                                            if (matrix[j + m, i + m + 1, n] != null)
                                            {

                                                //desde aqui se realiza la busqueda de las combinaciones
                                                //la 'g' recorre la lista de la gramatica para realizar las posibles combinaciones
                                                for (int g = 0; g < grammarlist.GetLength(0); g++)
                                                { //Busque la combinación en la lista gramatical e introdúzcala en el campo

                                                    string[] auxString = grammarlist[g, 1].Split('|');

                                                    for (int o = 0; o < auxString.Length; o++)
                                                    {
                                                        //se verifica si el objeto en la lista de la gramatica corresponde a la combinacion de dos Xij
                                                        if (auxString[o] == matrix[k, i, l] + matrix[j + m, i + m + 1, n])
                                                        {

                                                            //recorre los elementos del Xij
                                                            for (int h = 0; h < matrix.GetLength(2); h++)
                                                            {

                                                                //verifica que no este repetido en Xij para despues agregar
                                                                if (matrix[j - 1, i, h] != grammarlist[g, 0])
                                                                {   
                                                                    if (matrix[j - 1, i, h] == null)
                                                                    {
                                                                        matrix[j - 1, i, h] = grammarlist[g, 0];
                                                                        break;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                        }
                                                    }


                                                }
                                            }
                                            else
                                            {
                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            bool isIn = false;
            for (int i = 0; i < matrix.GetLength(2); i++)
            {
                if (matrix[0, 0, i] == "S") //cambiar por cualquier letra
                {
                    isIn = true;
                    break;
                }
            }

            string aux = "";

            if (!isIn)
            {
                aux = " no";
            }


            string finalOutput = "La palabra \"" + input + "\"" + aux + " pertenece a la gramatica dada";

            return finalOutput;
        }
    }
}
