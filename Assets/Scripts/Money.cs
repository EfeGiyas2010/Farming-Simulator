using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    //MONEY
    public Text moneyText;
    public float currentMoney;
    public float moneyIncreasedPerSecond;
    public float x;

    //SHOPBUY
    public float buyChainsawPrize;
    public Text buyChainsawText;
    public Button buyButton;
    public Text buyText;

    //SHOPSELL
    public float sellChainsawPrize;
    public Text sellChainsawText;
    public Button sellButton;
    public Text sellText;

    //GAMEOBJECTS
    public GameObject chainsaw;
    public GameObject sellUI;

    //TRANSFORMS
    public Transform itemSpawn;

    //BOOLS
    private bool isChainsawActivated;

    void Start()
    {
        //MONEY
        currentMoney = 50000f;
        moneyIncreasedPerSecond = 1;
        x = 0f;

        //GAMEOBJECTS
        chainsaw.SetActive(false);
        sellUI.SetActive(false);

    }

    void Update()
    {
        //MONEY
        moneyText.text = (int)currentMoney + " ₺";
        moneyIncreasedPerSecond = x * Time.deltaTime;
        currentMoney = currentMoney + moneyIncreasedPerSecond;

        //SHOPBUY
        buyChainsawText.text = buyChainsawPrize + " TL / Türk Lirası";

        //SHOPSELL
        sellChainsawText.text = sellChainsawPrize + " TL / Türk Lirası";

        PrivateSellChainsaw();

    }

    public void BuyChainsaw()
    {
        if (currentMoney >= buyChainsawPrize && isChainsawActivated == false)
        {
            currentMoney -= buyChainsawPrize;
            chainsaw.SetActive(true);
            chainsaw.transform.position = itemSpawn.position;
            isChainsawActivated = true;
            buyText.text = "Alındı";
            buyButton.GetComponent<Image>().color = Color.grey;
            sellUI.SetActive(true);

        }

        else if (currentMoney <= buyChainsawPrize || isChainsawActivated == true)
        {


        }

    }

    private void PrivateSellChainsaw()
    {
        if (chainsaw == true && isChainsawActivated == true)
        {
            chainsaw.transform.position = itemSpawn.position;
            chainsaw.SetActive(true);
            isChainsawActivated = true;

        }

    }

    public void PublicSellChainsaw()
    {
        if (chainsaw == true && isChainsawActivated == true)
        {
            currentMoney += 2000f;
            isChainsawActivated = false;
            chainsaw.SetActive(false);
            chainsaw.transform.position = itemSpawn.position;

        }

        else if (chainsaw == false && isChainsawActivated == false)
        {


        }

    }

}
