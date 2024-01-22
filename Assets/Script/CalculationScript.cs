using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculationScript : MonoBehaviour
{
    private float rate_USD = 0.74f;
    private float rate_YEN = 82.78f;
    private float rate_RM = 3.08f;
    private float rate_EUR = 0.63f;
    private float rate_KRW = 881.54f;
    private float rate_TWD = 20.73f;
    private float tempAmount;

    [SerializeField] private Toggle USToggle;
    [SerializeField] private Toggle YenToggle;
    [SerializeField] private Toggle Ringgit;
    [SerializeField] private Toggle KoreanWon;
    [SerializeField] private Toggle Euro;
    [SerializeField] private Toggle Taiwan;

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
                if (!USToggle.isOn && !YenToggle.isOn && !Ringgit.isOn && !Euro.isOn && !KoreanWon.isOn && !Taiwan.isOn)
                {
                    ErrorMessage("Please select one of its option");
                }
                if (USToggle.isOn && YenToggle.isOn && Ringgit.isOn && Euro.isOn && KoreanWon.isOn && Taiwan.isOn)
                {
                    ErrorMessage("Please select ONLY ONE of its option");
                }

                if (USToggle.isOn && !YenToggle.isOn && !Ringgit.isOn && !Euro.isOn && !KoreanWon.isOn && !Taiwan.isOn) 
                {
                    print("USD Converted");
                    Convertion(tempAmount, rate_USD, "USD");
                }
                else if (YenToggle.isOn && !USToggle.isOn && !Ringgit.isOn && !Euro.isOn && !KoreanWon.isOn && !Taiwan.isOn)
                {
                    print("Yen Converted");
                    Convertion(tempAmount, rate_YEN, "YEN");
                }
                else if(Ringgit.isOn && !YenToggle.isOn && !USToggle.isOn && !Euro.isOn && !KoreanWon.isOn && !Taiwan.isOn)
                {
                    print("Ringgit Converted");
                    Convertion(tempAmount, rate_RM, "MYR");
                }
                else if(Euro.isOn && !YenToggle.isOn && !USToggle.isOn && !Ringgit.isOn && !KoreanWon.isOn && !Taiwan.isOn)
                {
                    print("Euro Converted");
                    Convertion(tempAmount, rate_EUR, "EUR");
                }
                
                else if (KoreanWon.isOn&&!USToggle.isOn&& !Ringgit.isOn && !YenToggle.isOn && !Taiwan.isOn && !Euro.isOn)
                {
                    print("Euro Converted");
                    Convertion(tempAmount, rate_KRW, "KRW");
                }
                else if (Taiwan.isOn && !KoreanWon.isOn && !USToggle.isOn && !Ringgit.isOn && !YenToggle.isOn && !Euro.isOn)
                {
                    print("Taiwan Converted");
                    Convertion(tempAmount, rate_TWD, "TWD");
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
