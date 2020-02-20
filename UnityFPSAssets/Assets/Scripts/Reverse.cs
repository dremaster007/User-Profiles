using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reverse : MonoBehaviour
{
    /*

        we loop through the array,
        Check each number,
        Add each number to a string,
        Is first char = last char
        Is second char = second to last char


    */


    int[] array = { 1, 3, 1 };

    private void Start()
    {
        Check();
    }

    private void Check()
    {
        for (int i = 0; i < array.Length; i++)
        {
            if(array[i] != array[array.Length - i - 1])
            {
                Debug.Log("This can't be reversed!");
                return;
            }
        }

        Debug.Log(array + " can be reversed!");
    }
}
