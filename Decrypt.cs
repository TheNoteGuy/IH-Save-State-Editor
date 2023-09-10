// See https://aka.ms/new-console-template for more information

// v6-DC1FCEE-ktqLFGiXQicXA0LXZiQqkMLnJXLZgGOlLkacXQarvXQBMzXQqlXQBxtRqW1qlQOzjMlEAaRrLcO0xik0xkulxiM0xuOlrRalxHulmLGaxqQqxiQbOMlLkGJxqx10LqAqLag0QXgaQXWSWvaEgLzaOXLziFXFilFt0QvEXLquMSaqulLlXHXQqvaQcO0ZrlQzMGq-SETTINGS000----IdleHome

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using UnityEngine;
using UnityEditor;
public class Decrypt : MonoBehaviour
{
    
    
    [MenuItem("IHateThis/Decode")]
    public static (int[], int[], string) Decode(string SaveFile)
    {
        
        string EncodedTime = "DC21A6A";
        //string SaveFile = "NVsWkERWXn0InOgTfEWouIsvxQsWODEVvAjDcVvaDEvRZVWxDxakjOaVvgJzavkoRWzXoEJVv0szvATVERJCZNuVZ0TCEfuVZHuVZfDCEcoCrWQosWHaysWaAaW0KnQgReCvouxsveDJaWeDXsvCBbcDZsEvyfUkaW0cxkZCWzuZsWIfoXIEeEjCvyOsvaHs";
        object[] GetShuffledEncodingString;
        string test;
        char[] ZeroToFArray = "0123456789ABCDEF;".ToCharArray();
         char[] AtoZArray = "ABCDEFGHIJKLMNOPZ".ToCharArray();
         int valueTest;
         int idTest;
         string[] Test2;
        
        Test2 = SaveFile.Split('-');
        
        var charArr = Test2[2].ToCharArray();
        var reverse = "";
        for (var i = (charArr.Length - 1); (i >= 0); i = (i - 1))
        {
            reverse = string.Concat(reverse, charArr[i]);
        }

        //Debug.Log(reverse);
        
        GetShuffledEncodingString = GetShuffledEncoding(Test2[1]);
        
        //Debug.Log(ReverseReplacement(reverse, GetShuffledEncodingString));

        var Stop1 = ReverseReplacement(reverse, GetShuffledEncodingString);
        
        //Debug.Log(DecompressString(Stop1));

        var Stop2 = DecompressString(Stop1);
        
        //Debug.Log(ReverseReplacementSmth(Stop2,ZeroToFArray ,AtoZArray));

        var Stop3 = ReverseReplacementSmth(Stop2, ZeroToFArray, AtoZArray);

        var Stop4 = string.Concat(";" + Stop3);
        
        //Debug.Log(Stop4);

        var Stop5 = ReverseConcatenationLoop(Stop4);
        
        //Debug.Log("ReverseConcatenation String: " + string.Join(" ", Stop5));

        string[] placeholder = new string[Stop5.Length];
        
        for (int i = 0; i < Stop5.Length; i++)
        {
            placeholder[i] = string.Concat(";" + Stop5[i]);
        }

        //Debug.Log("Placeholder aka re-add semicolon : " + string.Join("", placeholder));



        int[] sortedIDs = new int[Stop5.Length];
        int[] sortedValues = new int[Stop5.Length];
        string name = "";
        
        for (int i = 0; i < Stop5.Length; i++)
        {
            var Test = Stop5[i];
            var idHex = Test.Substring(0, 2);
            var valueHex = Test.Substring(2);
            
            idTest = int.Parse(idHex, System.Globalization.NumberStyles.HexNumber);
            if (idTest != 0)
            {
                valueTest = int.Parse(valueHex, System.Globalization.NumberStyles.HexNumber);
                sortedIDs[i] = idTest;
                sortedValues[i] = valueTest;
            }
            else
            {
                name = valueHex;
            }
            
        
        }
        
        Array.Sort(sortedIDs, sortedValues);
        
        //Debug.Log("Sorted ID-Value Pairs:");
        // for (int i = 0; i < sortedIDs.Length; i++)
        // {
        //     Debug.Log("ID: " + sortedIDs[i] + " VALUE: " + sortedValues[i]);
        // }
        
        return (sortedIDs, sortedValues, name);

    }
    
    
    private static string[] ReverseConcatenationLoop(string input)
    {
      
        string[] inputStrings = input.Split(';');
        List<string> restoredStringsList = new List<string>();
        
        for (int i = 0; i < inputStrings.Length; i++)
        {
            if (!string.IsNullOrEmpty(inputStrings[i]))
            {
                restoredStringsList.Add(inputStrings[i]);
            }
        }

        
        string[] restoredStrings = restoredStringsList.ToArray();

        return restoredStrings;
    }

    static string ReverseReplacementSmth(string replacedText, char[] ZeroToFArray, char[] AtoZArray)
    {
        string originalText = "";
    
        for (int i = 0; i < replacedText.Length; i++)
        {
            char currentChar = replacedText[i];
        
            for (int j = 0; j < AtoZArray.Length; j++)
            {
                if (currentChar == AtoZArray[j])
                {
                    originalText += ZeroToFArray[j];
                    break;
                }
            }
        }
    
        return originalText;
    }

    static private string DecompressString(string compressedText)
    {
        string decodedText = "";
    
        for (int i = 0; i < compressedText.Length; i++)
        {
            char currentChar = compressedText[i];
        
            if (char.IsDigit(currentChar))
            {
                int count = int.Parse(currentChar.ToString());
            
                if (i + 1 < compressedText.Length) 
                {
                    char nextChar = compressedText[i + 1];
                    decodedText += new string(nextChar, count);
                    i++; 
                }
            }
            else
            {
                decodedText += currentChar;
            }
        }
    
        return decodedText;
    }

    static private string ReverseReplacement(string replacedText, object[] shuffledEncoding)
    {
        var ZeroToZArray = "0123456789ABCDEFGHIJKLMNOPZ".ToCharArray();
        string originalText = "";
    
        for (int i = 0; i < replacedText.Length; i++)
        {
            char currentChar = replacedText[i];
        
            char[] shuffledChars1 = (char[])shuffledEncoding[0];
            char[] shuffledChars2 = (char[])shuffledEncoding[1]; 
        
            for (int j = 0; j < shuffledChars1.Length; j++)
            {
                if (currentChar == shuffledChars1[j] || currentChar == shuffledChars2[j])
                {
                    originalText += ZeroToZArray[j];
                    break;
                }
            }
        }
    
        return originalText;
    }
    
    static private object[] GetShuffledEncoding(string Test2)
    {
        int DateSeed = int.Parse(Test2, System.Globalization.NumberStyles.HexNumber);
        UnityEngine.Random.InitState(DateSeed);
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz01".ToCharArray();
        var n = chars.Length;
        for (int i2 = 0; (i2 < (n - 1)); i2 = (i2 + 1))
        {
            var r = (i2 + UnityEngine.Random.Range(0, (n - i2)));
            var t = chars[r];
            chars[r] = chars[i2];
            chars[i2] = t;
        }
        var setSize = 27;
        var charSets = new object[2];
        charSets[0] = new char[setSize];
        charSets[1] = new char[setSize];
        for (int i2 = 0; (i2 < setSize); i2 = (i2 + 1))
        {
            ((char[])charSets[0])[i2] = chars[i2]; 
        }
        for (int i2 = 0; (i2 < setSize); i2 = (i2 + 1))
        {
            ((char[])charSets[1])[i2] = chars[(setSize + i2)]; 
        }
        
        return charSets;

    }

}
