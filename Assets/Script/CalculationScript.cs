using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationScript : MonoBehaviour
{
    private float rate_USD = 0.74f;
    private float rate_YEN = 82.78f;
    private float tempAmount;

    [SerializeField] private Toggle USToggle;
    [SerializeField] private Toggle YenToggle;

    [SerializeField] private Text InputAmount;
    [SerializeField] private Text ConvertedAmount;

    // Start is called before the first frame update
    void Start()
    {
        USToggle.isOn = false;
        YenToggle.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Convert()
    {
        Debug.Log("Converting");



        if (InputAmount.text == "" || InputAmount.text == " ")
        {
            ErrorMessage("Please input text in the text box above");
        }
        else
        {
            try
            {
                tempAmount = float.Parse(InputAmount.text);
                if (!USToggle.isOn && !YenToggle.isOn)
                {
                    ErrorMessage("Please select one of its option");
                }
                if (USToggle.isOn && YenToggle.isOn)
                {
                    ErrorMessage("Please select ONLY ONE of its option");
                }

                if (USToggle.isOn && !YenToggle.isOn)
                {
                    print("USD Converted");
                    Convertion(tempAmount, rate_USD, "USD");
                }
                else if (!USToggle.isOn && YenToggle.isOn)
                {
                    print("Yen Converted");
                    Convertion(tempAmount, rate_YEN, "YEN");
                }
            }
            catch(System.FormatException)
            {
                ErrorMessage("Please enter only numbers");
            }
        }
    }

    private void Convertion(float amount, float chosenRate, string dollarSign)
    {
        Debug.Log("Convert Output");
        ConvertedAmount.text = (amount * chosenRate) + " " + dollarSign;
    }

    private void ErrorMessage(string Error)
    {
        ConvertedAmount.text = Error;
    }

    public void onClear()
    {

    }

}
