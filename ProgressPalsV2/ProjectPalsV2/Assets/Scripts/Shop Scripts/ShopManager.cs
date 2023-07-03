using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public int coins;
    public TMP_Text coinUI;
    public ShopItemSO[] shopItemsSO;
    public GameObject[] shopPanelsGO;
    public ShopTemplate[] shopPanels;
    public Button[] myPurchaseBtns;
    public DragDrop[] dragDropItems;
    public Image[] items;

    // Start is called before the first frame update
    
    void Start()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        shopPanelsGO[i].SetActive(true);
        coinUI.text = "Coins: " + coins.ToString();
        LoadPanels();
        CheckPurchaseable();
    }
    

    public void AddCoins() //simple script to add coins
    {
        coins++;
        coinUI.text = "Coins: " + coins.ToString();
        CheckPurchaseable();
    }
    
    public void CheckPurchaseable()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (coins >= shopItemsSO[i].baseCost) //if  i have enough money
            {
                myPurchaseBtns[i].interactable = true;
            }
            else
            {
                myPurchaseBtns[i].interactable = false;            
            }
        }
    }

    
    public void PurchaseItem(int btnNo) 
    {
        if( coins >= shopItemsSO[btnNo].baseCost)
        {
            coins = coins - shopItemsSO[btnNo].baseCost;
            dragDropItems[btnNo].unlocked = true;
            coinUI.text = "Coins: " + coins.ToString();
            CheckPurchaseable();
            //Unlock Item.
        }
    }
    

    public void LoadPanels()
    {
        for(int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].descriptionTxt.text = shopItemsSO[i].descrption;
            shopPanels[i].costTxt.text = "Coins: " + shopItemsSO[i].baseCost.ToString();
            
        }



    }
}
