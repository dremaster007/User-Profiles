using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int[] myArray;

    private int[,] myMatrix1, myMatrix2;

    private string mySuny = "suny";

    // Start is called before the first frame update
    void Start()
    {
        myArray = new int[] { 1, 2, 3, 4, 5, 6 };
        myMatrix1 = new int[2, 3] { { 2, 1, 4 }, { 0, 1, 1} };
        myMatrix2 = new int[3, 4] { { 6, 3, -1, 0 }, { 1, 1, 0, 4 }, { -2, 5, 0, 2 } };

        CheckName(mySuny);

        //Debug.Log("Recursive sum is " + PerformRecursiveSum());

        //PerformMatricesMultiplication();
    }

    private int PerformRecursiveSum(int i = 0)
    {
        //breaking condition
        if(i >= myArray.Length)
        {
            return 0;
        }
        return myArray[i] + PerformRecursiveSum(i + 1);
    }

    private void PerformMatricesMultiplication()
    {
        // check matrices dimentions
        int mat1Rows = myMatrix1.GetLength(0); // rows
        int mat1Cols = myMatrix1.GetLength(1); // cols
        int mat2Rows = myMatrix2.GetLength(0);
        int mat2Cols = myMatrix2.GetLength(1);

        if (mat1Cols != mat2Rows)
        {
            Debug.Log("Matrices cannot be multiplied. Wrong dimensions!");
            return;
        }

        int[,] newMatrix = new int[mat1Rows, mat2Cols]; // 2 x 4

        for (int r = 0; r < mat1Rows; r++)
        {
            for(int c = 0; c < mat2Cols; c++)
            {
                int subSum = 0;
                for(int k = 0; k < mat1Cols; k++) //OR mat2R
                {
                    subSum += myMatrix1[r,k] * myMatrix2[k,c];
                }
                newMatrix[r, c] = subSum;
            }
        }

        Debug.Log("New matrix is \n");
        for (int r = 0; r < mat1Rows; r++)
        {
            string matrixRow = "";
            for (int c = 0; c < mat2Cols; c++)
            {
                matrixRow += newMatrix[r, c] + ", ";
            }
            Debug.Log(matrixRow);
        }
    }



    private void CheckName(string myName)
    {
        switch (myName)
        {
            case "suny":
                Debug.Log("The string is suny");
                break;
            case "hello":
                Debug.Log("The string is hello");
                break;
            default:
                Debug.Log("The string doesn't match any cases!");
                break;
        }
    }
}
