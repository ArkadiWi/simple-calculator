using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager.Requests;
using UnityEditorInternal;

public class Calculator : MonoBehaviour
{
    
    private string _tempNumbers;
    private int _counter;

    public float result;
    public string finalResult;
    public string tempResult1;
    public string tempResult2;
    public string operation1;
    public string operation2;
    public float number1;
    public float number2;

    public TMP_InputField InputField;

   

    // Start is called before the first frame update
    void Start()
    {
        FullReset();        
    }

    public void ClickNumber (int val)
    {
        if (_counter < 10)
        {
            _counter++;           
            _tempNumbers += val.ToString();
            ShowOnScreen(_tempNumbers);
        }        
            
    }


    public void ClickOperation(string operation)
    {
        if (tempResult1 == null && _tempNumbers != null)
        {
            Debug.Log("Jestem w 1szym warunku");
            tempResult1 = _tempNumbers;
            operation1 = operation;
            Debug.Log(tempResult1);
            Reset();
            ShowOnScreen(tempResult1);
        }
        else if (_tempNumbers != null)
        {
            Debug.Log("Jestem w 2gim warunku");
            tempResult2 = _tempNumbers;
            operation2 = operation;

            result = DoCalculation(tempResult1, tempResult2, operation1);
            Reset();
            tempResult1 = result.ToString();
            finalResult = tempResult1;
            ShowOnScreen(tempResult1);

            tempResult2 = null;
            operation = null;
            operation1 = operation2;

            result = 0f;
        }
        else
        {           
            ShowOnScreen("Enter the number");
        }
            
    }

    public void ClickEqual()
    {        
        FullReset();
        ShowOnScreen(finalResult);
        //finalResult = null;
    }

    public void ClickPeriod(string val)
    {
        if(_tempNumbers == null)
        {
            _tempNumbers = "0";            
        }                    
        
        if(!_tempNumbers.Contains(","))
        {
            _tempNumbers += ",";
        }

        ShowOnScreen(_tempNumbers);
    }        
    
    private void ShowOnScreen(string result)
    {
        InputField.text = null;
        InputField.text = result;
    }

    private void Reset()
    {
        InputField.text = "0";
        _counter = 0;
        _tempNumbers = null;        
    }

    public void FullReset()
    {
        tempResult1 = null;
        tempResult2 = null;        
        operation1 = null;
        operation2 = null;
        InputField.text = "0";
        _counter = 0;
        _tempNumbers = null;        
    }


    private float DoCalculation(string val1, string val2, string operation1)
    {
        number1 = float.Parse(val1);
        number2 = float.Parse(val2);

        switch (operation1)
        {
            case ("+"):
                result = number1 + number2;
                break;

            case ("-"):
                result = number1 - number2;
                break;

            case ("*"):
                result = number1 * number2;
                break;

            case ("/"):
                result = number1 / number2;
                break;
        }

        return result;
    }


}
