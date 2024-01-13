using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trader : MonoBehaviour
{
    Inventory inventory;
    public List<SeedItem> stock = new List<SeedItem>();
    public bool selling = false;
    public void sell(SeedItem item){
        if(stock.Contains(item) && inventory.getSunJars() >= item.getPrice()){
            // add item to player
            inventory.purchased(item.getPrice());
            // fix this
            inventory.addSeed(item, 1);
        }
    }


// change frequency?
    public void setUpShop(int round){
        if(round % 4 == 0){
            selling = true;
        }
    }

    public bool isSelling(){
        return selling;
    }
}
