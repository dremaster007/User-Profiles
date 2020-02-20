using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuplicateCheck : MonoBehaviour
{
    public int[] array;
    public int duplicate_amt = 0;

    public void Start()
    {
        array = new int[] { 1,0,1,4,1};
        Debug.Log(CheckInput());
    }

    public bool CheckInput()
    {
        //We loop through the 
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i+1; j < array.Length; j++)
            {
                if (array[i] == array[j] && i != j)
                {
                    duplicate_amt += 1;
                }
            }
        }

        Debug.Log("There were " + duplicate_amt + " duplicating numbers in the array");
        if (duplicate_amt > 0)
        {
            return true;
        }
        return false;
    }
}
