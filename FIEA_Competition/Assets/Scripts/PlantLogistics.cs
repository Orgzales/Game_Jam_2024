using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum PlantType
{
    mushroom, kale, fruit, potato
}

public class PlantLogistics : MonoBehaviour
{
    public PlantType plantType;
    //Garden Stats
    public bool GotSun = false;
    public bool IsDead = false;
    public float PlantHP;
    public float GrowthSP = 0; //amount of growth accumulated
    public int SunCP = 0; //amount of sunjars given
    public float HPlostPerRound;
    public float GrowthPerRound;
    public float FoodQuality;
    public float SunGrowthBoost; //Adds both HP and Growth

    //Currecny Stats
    public float SunJarWorth;
    public int BarterPlus; //For helping with bartering. 


    //Needed to Finish Growing
    public int SunJarNeeded;
    public float MaxGrowthNeeded;
    public bool IsGrown = false;

    public string PlantDescription;

    //public PlantLogistics(float PlantHPpra, float HPlostPerRoundpra, float GrowthPerRoundpra,
    //float FoodQualitypra, float SunGrowthBoostpra, float SunJarWorthpra, int BarterPluspra,
    //int SunJarNeededpra, float MaxGrowthNeededpra, string Description)
    //{
    //    PlantHP = PlantHPpra;
    //    HPlostPerRound = HPlostPerRoundpra;
    //    GrowthPerRound = GrowthPerRoundpra;
    //    FoodQuality = FoodQualitypra;
    //    SunGrowthBoost = SunGrowthBoostpra;
    //    SunJarWorth = SunJarWorthpra;
    //    BarterPlus = BarterPluspra;
    //    SunJarNeeded = SunJarNeededpra;
    //    MaxGrowthNeeded = MaxGrowthNeededpra;
    //    PlantDescription = Description;
    //}

    public void NextRound()  //what happens each round
    {
        if (!IsDead) //if the plant is not dead
        {
            if (GotSun) //Was sun given last round?
            {
                PlantHP = PlantHP + SunGrowthBoost;
                GrowthSP = GrowthSP + SunGrowthBoost;
            }
            else    //No sun was given
            {
                PlantHP = PlantHP - HPlostPerRound;
                if (PlantHP <= 0)
                {
                    IsDead = true;
                }
            }
            GrowthSP = GrowthSP + GrowthPerRound; //Plant growth amount each round without sun
            CheckGrowth();
        }

    }

    public void CheckGrowth()
    {
        if (IsDead)
        {
            SunJarWorth = 0; //no sun worth but could be traded for something later
        }
        else if (SunCP >= SunJarNeeded && GrowthSP >= MaxGrowthNeeded)
        {
            IsGrown = true;
        }
    }

    public bool FarmCrop() //Call back to when player takes it to sell
    {
        if (IsGrown)
        {
            return true;
        }
        else if (IsDead) //can farm dead plants 
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public string Description()
    {
        return PlantDescription;
    }

    public float GetEaten() //call back to when player eaten 
    {
        if (IsGrown)
        {
            //have player hunger go up from this
        }
        return FoodQuality;
    }


}

public class Item
{
    Inventory inventory;

    public string name;
    public string getName(){
        return name;
    }
    public void setName(string _name){
        name = _name;
    }

}

public class SeedItem : Item {
    
    public int price;
    public SeedItem(PlantType type, int _price){
       name = type.ToString();
        price = _price;
    }
    public int getPrice(){
        return price;
    }
}

public class PlantItem : Item 
{

}

public class CropItem : Item
{
    int price;
    int saturation;
    public int getSaturation(){
        return saturation;
    }
    public int getPrice(){
        return price;
    }
}


