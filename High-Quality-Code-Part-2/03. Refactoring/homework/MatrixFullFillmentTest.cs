﻿namespace FillMatrixTest
{
    using System;
    using FillTheMatrix;

    public class MatrixFullfillmentTest
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine( "Enter a positive number " );
            // string input = Console.ReadLine(  );
            // int n = 0;
            // while ( !int.TryParse( input, out n ) || n < 0 || n > 100 )
            // {
            //    Console.WriteLine( "You haven't entered a correct positive number" );
            //    input = Console.ReadLine(  );
            // }
            int dimensions = 3;
            int[,] matrix = new int[dimensions, dimensions];
            int matrixLength = dimensions,
                   initialValue = 1,
                   currentRow = 0,
                   currentCol = 0,
                   directionPositionX = 1,
                   directionPositionY = 1;

            while (true)
            { // malko e kofti tova uslovie, no break-a raboti 100% : )
                matrix[currentRow, currentCol] = initialValue;

                if (MatrixFullFillment.CheckIfMatrixIsFull(matrix, currentRow, currentCol))
                {
                    break;
                } // prekusvame ako sme se zadunili

                if (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 || currentCol + directionPositionY >= matrixLength ||
                    currentCol + directionPositionY < 0 || matrix[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                {
                    while (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 || currentCol + directionPositionY >= matrixLength ||
                        currentCol + directionPositionY < 0 || matrix[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                    {
                        MatrixFullFillment.ChangeDirection(ref directionPositionX, ref directionPositionY);
                    }
                }

                currentRow += directionPositionX;
                currentCol += directionPositionY;
                initialValue++;
            }

            // Print matrix
            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixLength; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }

            MatrixFullFillment.FindZeroCell(matrix, out currentRow, out currentCol);

            if (currentRow != 0 && currentCol != 0)
            { // taka go napravih, zashtoto funkciqta ne mi davashe da ne si definiram out parametrite
                directionPositionX = 1;
                directionPositionY = 1;

                while (true)
                {
                    // malko e kofti tova uslovie, no break-a raboti 100% : )
                    matrix[currentRow, currentCol] = initialValue;

                    if (MatrixFullFillment.CheckIfMatrixIsFull(matrix, currentRow, currentCol))
                    {
                        break;
                    }

                    // prekusvame ako sme se zadunili
                    if (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 || currentCol + directionPositionY >= matrixLength ||
                        currentCol + directionPositionY < 0 || matrix[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                    {
                        while (currentRow + directionPositionX >= matrixLength || currentRow + directionPositionX < 0 || currentCol + directionPositionY >= matrixLength ||
                            currentCol + directionPositionY < 0 || matrix[currentRow + directionPositionX, currentCol + directionPositionY] != 0)
                        {
                            MatrixFullFillment.ChangeDirection(ref directionPositionX, ref directionPositionY);
                        }
                    }

                    currentRow += directionPositionX;
                    currentCol += directionPositionY;
                    initialValue++;
                }
            }

            // Print matrix
            for (int row = 0; row < matrixLength; row++)
            {
                for (int col = 0; col < matrixLength; col++)
                {
                    Console.Write("{0,3}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }
    }
}
