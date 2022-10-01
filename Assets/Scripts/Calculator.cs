using UnityEngine;
using TMPro;


public class Calculator : MonoBehaviour
{
    
    private string collectNumbersInString;
    private int countPuttedNumbers;
    private float resultOfCalculation;
    private string resultAfterTappedEqual;

    private string firstStringOfNumbers;
    private string secStringOfNumbers;
    private string firstSelectMathOperation;
    private string secSelectMathOperation;    
    private TMP_InputField inputField;


    // Start is called before the first frame update
    void Start()
    {
        inputField = FindObjectOfType<TMP_InputField>();        
        FullReset();
    }

    public void ClickNumber (int val)
    {
        if (countPuttedNumbers < 10)
        {
            countPuttedNumbers++;           
            collectNumbersInString += val.ToString();
            ShowOnScreen(collectNumbersInString);
        }        
            
    }


    public void ClickOperation(string operation)
    {
        if (firstStringOfNumbers == "" && collectNumbersInString != "")
        {
            firstStringOfNumbers = collectNumbersInString;
            firstSelectMathOperation = operation;            
            Reset();
            ShowOnScreen(firstStringOfNumbers);
        }
        else if (collectNumbersInString != "")
        {
            secStringOfNumbers = collectNumbersInString;
            secSelectMathOperation = operation;



            resultOfCalculation = DoCalculation(firstStringOfNumbers, secStringOfNumbers, firstSelectMathOperation);
            resultAfterTappedEqual = resultOfCalculation.ToString();
            ShowOnScreen(resultAfterTappedEqual);
            Reset();

            secStringOfNumbers = "";
            operation = null;
            firstSelectMathOperation = secSelectMathOperation;

            resultOfCalculation = 0f;
        }
        else
        {           
            ShowOnScreen("Enter the number");
        }
            
    }

    public void ClickEqual()
    {        
        FullReset();
        ShowOnScreen(resultAfterTappedEqual);
        collectNumbersInString = resultAfterTappedEqual;
    }

    public void ClickPeriod(string val)
    {
        if(collectNumbersInString == "")
        {
            collectNumbersInString = "0";            
        }                    
        
        if(!collectNumbersInString.Contains(","))
        {
            collectNumbersInString += ",";
        }

        ShowOnScreen(collectNumbersInString);
    }        
    
    private void ShowOnScreen(string result)
    {
        inputField.text = "";
        inputField.text = result;
    }

    private void Reset()
    {
        inputField.text = "0";
        countPuttedNumbers = 0;
        collectNumbersInString = "";        
    }

    private void FullReset()
    {
        firstStringOfNumbers = "";
        secStringOfNumbers = "";        
        firstSelectMathOperation = "";
        secSelectMathOperation = "";
        inputField.text = "0";
        countPuttedNumbers = 0;
        collectNumbersInString = "";        
    }


    private float DoCalculation(string val1, string val2, string operation)
    {
        float number1 = float.Parse(val1);
        float number2 = float.Parse(val2);

        switch (operation)
        {
            case ("+"):
                resultOfCalculation = number1 + number2;
                break;

            case ("-"):
                resultOfCalculation = number1 - number2;
                break;

            case ("*"):
                resultOfCalculation = number1 * number2;
                break;

            case ("/"):
                resultOfCalculation = number1 / number2;
                break;
        }

        return resultOfCalculation;
    }


}
