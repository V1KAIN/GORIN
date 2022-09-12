using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using Random = UnityEngine.Random;


public class StringBuilder : MonoBehaviour
{
    //Example of a string builder(more optimized than regular String MyStringOne = MyStringOne + MyString Two)

    private void Start()
    {
        //StringBuilderExemple();
    }
    
    void StringBuilderExemple()
    {
        string myStringOne = "I Am ";
        string myStringTwo = "a human ";
        string myStringThree = "coming from earth";

        System.Text.StringBuilder myBuilder = new System.Text.StringBuilder();
        myBuilder.Append(myStringOne);
        myBuilder.Append(myStringTwo);
        myBuilder.Append(myStringThree);
        
        Debug.Log(myBuilder.ToString());
    }
    
    //I can create an ID Creator with this:
    [ContextMenu("Create String")]
    void CreateRandomStringOfNumber()
    {
        List<string> stringList = new List<string>();
        int listSize = Random.Range(1, 10);

        for (int i = 0; i < listSize; i++)
        {
            int number = Random.Range(100, 999);
            string numberString = number.ToString();
            stringList.Insert(i, numberString);
        }
        
        BuildString(stringList);
    }
    
    void BuildString(List<string> strings)
    {
        System.Text.StringBuilder myBuilder = new System.Text.StringBuilder();
        
        foreach (string myString in strings)
        {
            myBuilder.Append(myString);
            myBuilder.Append(" ");
        }
        
        Debug.Log(myBuilder.ToString());
    }
}
