using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyLogistics : MonoBehaviour
{



    float DifficultySlider = 1f; //0.5 = easy, 1 = normal, 2 = Hard | Or have slider float value

    float SunJarWorth = 10f; //worth 10 points

    int AmountOfCrops; //Amount of crops selling to the company
    public int[] crops; //change to tags later.

    public void Start()
    {
        AmountOfCrops = 5;
        crops = new int[AmountOfCrops];

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TradingForSun();
        }
    }

    private void TradingForSun()
    {

        float TotalAmount = 0f;
        int SunJarGiven = 0;

        foreach (int CropType in crops)
        {
            Debug.Log(TotalAmount);
            switch (CropType)
            {
                case (1):
                    TotalAmount = TotalAmount + MushroomPrice();
                    break;
                case (2):
                    TotalAmount = TotalAmount + KalePrice();
                    break;
                case (3):
                    TotalAmount = TotalAmount + FruitPrice();
                    break;
            }
        }

        while (TotalAmount >= SunJarWorth)
        {
            TotalAmount = TotalAmount - SunJarWorth;
            SunJarGiven++;
        }
        if (TotalAmount >= SunJarWorth / 2)
        {
            int x = Random.Range(0, 1);
            if (x == 0)
            {
                SunJarGiven++;
            }
        }

        Debug.Log("Amount of sun Jars: " + SunJarGiven);

    }



    public float MushroomPrice()
    {
        return Random.Range(10f, 15f);
    }
    public float KalePrice()
    {
        return Random.Range(15f, 20f);
    }
    public float FruitPrice()
    {
        return Random.Range(20f, 25f);
    }


}

