using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public List<SeedItem> stock = new List<SeedItem>();
    public List<CropItem> allCrops = new List<CropItem>();
    public bool selling = false;

    public GameObject windowAccess;
    public GameObject tradeDisplay;
    public Animator windowAnim;
    public static Trader instance;
    public TraderButton currentButton;

    public bool CameraToWindow = false;

    public Material[] materials;
    public MeshRenderer activeLight;
    public GameObject redLight;
    public GameObject greenLight;

    private void Start()
    {
        instance = this;
        stock = GameManager.instance.getWorldSeeds();
        allCrops = GameManager.instance.getWorldCrops();
        CameraToWindow = false;
        setUpShop(0);

    }

    private void Update()
    {
        if (selling)
        {
            windowAccess.SetActive(true);
            activeLight.material = materials[1];
            redLight.SetActive(false);
            greenLight.SetActive(true);
        }
        else
        {
            windowAccess.SetActive(false);
            activeLight.material = materials[0];
            redLight.SetActive(true);
            greenLight.SetActive(false);
        }
    }

    public void clickWindow()
    {
        CameraToWindow = true;
        StartCoroutine("CameraWait");
        windowAnim.SetBool("Open Window", true);
        GameManager.instance.nextRoundButton.interactable = false;
    }

    public void closeWindow()
    {
        CameraToWindow = false;
        windowAnim.SetBool("Open Window", false);
        tradeDisplay.SetActive(false);
        GameManager.instance.nextRoundButton.interactable = true;
    }

    IEnumerator CameraWait()
    {
        yield return new WaitForSeconds(2);
        tradeDisplay.SetActive(true);

    }

    public void sellCrop(CropItem crop, int num)
    {
        if (Inventory.instance.getCropInventory().ContainsKey(crop) && Inventory.instance.getCropInventory()[crop] >= 1)
        {
            Inventory.instance.getCropInventory()[crop] -= num;
            Inventory.instance.sold(crop.getPrice() * num);
        }
    }


    public void buySeed(SeedItem seed, int num)
    {
        if (stock.Contains(seed) && Inventory.instance.getSunJars() >= seed.getPrice())
        {
            Inventory.instance.purchased(seed.getPrice() * num);
            Inventory.instance.addSeed(seed, num);
        }
    }

    // change frequency?
    public void setUpShop(int round)
    {
        if (round % 4 == 0)
        {
            selling = true;
        }
    }

    public bool isSelling()
    {
        return selling;
    }
}

//public void sell(SeedItem item){
//    if(stock.Contains(item) && inventory.getSunJars() >= item.getPrice()){
//        // add item to player
//        inventory.purchased(item.getPrice());
//        // fix this
//        inventory.addSeed(item, 1);
//    }
//}

//public void buy(CropItem crop){
//    if(Inventory.instance.getCropInventory().ContainsKey(crop) && Inventory.instance.getCropInventory()[crop] >= 1){
//        Inventory.instance.getCropInventory()[crop] -= 1;
//        Inventory.instance.sold(crop.getPrice());
//    }
//}
