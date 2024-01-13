using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class initialCost
{
    public float cost;
    public PlantType plantType;
    public bool isPlant;
}

[System.Serializable]
public class WorldEvent
{
    [Header("Event")]
    public string title;
    public string description;
    [Tooltip("Keep as a value under 1. Percentage declared as a decimal (0.96 for 96%)")]
    public float probability;

    [Header("Option 1")]
    [Tooltip("If you do not want a cost or reward, enter value as 0.")]
    public initialCost cost1;
    public initialCost reward1;

    [Header("Option 2")]
    [Tooltip("If you do not want a cost or reward, enter value as 0.")]
    public initialCost cost2;
    public initialCost reward2;
}
public class EventsManager : MonoBehaviour
{
    [Header("Events")]
    [Tooltip("Press the plus button to add an event and type in fields")]
    public List<WorldEvent> worldEvents = new List<WorldEvent>();
    private int chosenEvent;

    [Header("Event Display")]
    public GameObject eventDisplay;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI cost1;
    public TextMeshProUGUI cost2;
    public TextMeshProUGUI reward1;
    public TextMeshProUGUI reward2;
    public Button button1;
    public Button button2;

    public void chooseEvent()
    {
        int randomNum = Random.Range(0, 101);
        int randomEvent = Random.Range(0, worldEvents.Count);

        if (randomNum <= worldEvents[randomEvent].probability)
        {
            chosenEvent = randomEvent;
            displayEvent();
        }
        else
        {
            chooseEvent();
        }
       
    }

    private void displayEvent()
    {
        title.text = worldEvents[chosenEvent].title;
        description.text = worldEvents[chosenEvent].description;
        cost1.text = worldEvents[chosenEvent].cost1.ToString();
        cost2.text = worldEvents[chosenEvent].cost2.ToString();
        reward1.text = worldEvents[chosenEvent].reward1.ToString();
        reward2.text = worldEvents[chosenEvent].reward2.ToString();
    }

    public void pressButtonOne()
    {
        
    }

    public void pressButtonTwo()
    {

    }
}
