using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    private static float firstNumber;
    private static float secondNumber;
    private static float result;
    string action;
    string currentResult;
    public Text resultText;

    public void One()
    {
        currentResult += "1";
        resultText.text = currentResult.ToString();
    }

    public void Two()
    {
        currentResult += "2";
        resultText.text = currentResult.ToString();
    }

    public void Tree()
    {
        currentResult += "3";
        resultText.text = currentResult.ToString();
    }

    public void Four()
    {
        currentResult += "4";
        resultText.text = currentResult.ToString();
    }

    public void Five()
    {
        currentResult += "5";
        resultText.text = currentResult.ToString();
    }

    public void Six()
    {
        currentResult += "6";
        resultText.text = currentResult.ToString();
    }

    public void Seven()
    {
        currentResult += "7";
        resultText.text = currentResult.ToString();
    }

    public void Eight()
    {
        currentResult += "8";
        resultText.text = currentResult.ToString();
    }

    public void Nine()
    {
        currentResult += "9";
        resultText.text = currentResult.ToString();
    }

    public void Zero()
    {
        currentResult += "0";
        resultText.text = currentResult.ToString();
    }
    public void ButtonAdd()
    {
        currentResult += " + ";
        resultText.text = currentResult.ToString();
    }

    public void ButtonSubtract()
    {
        currentResult += " - ";
        resultText.text = currentResult.ToString();
    }

    public void ButtonMultiply()
    {
        currentResult += " * ";
        resultText.text = currentResult.ToString();
    }

    public void ButtonDevide()
    {
        currentResult += " / ";
        resultText.text = currentResult.ToString();
    }

    public void Clear()
    {
        currentResult = " ";
        resultText.text = currentResult.ToString();
    }
    public void Equals()
    {
        string[] words = currentResult.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);    

        firstNumber = float.Parse(words[0]);
        secondNumber = float.Parse(words[2]);
        action = words[1];

        switch(action)
            {
            case "+":
                result = firstNumber + secondNumber;
                resultText.text = result.ToString();
                currentResult = result.ToString();
                break;

            case "-":
                result = firstNumber - secondNumber;
                resultText.text = result.ToString();
                currentResult = result.ToString();
                break;

            case "*":
                result = firstNumber * secondNumber;
                resultText.text = result.ToString();
                currentResult = result.ToString();
                break;

            case "/":
                result = firstNumber / secondNumber;
                resultText.text = result.ToString();
                currentResult = result.ToString();
                break;

            default:
                resultText.text = currentResult.ToString();
                break;

        }

    }
}
