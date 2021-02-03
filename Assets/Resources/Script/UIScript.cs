using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Canvas moneyMenu;

    public Text moneyText;
    int money = 2000;

    // Start is called before the first frame update
    void Start()
    {
        ToggleMoneyMenu();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }

    public void Add200()
    {
        AddMoney(200);
    }



    public void UpdateMoney()
    {
        moneyText.text = money.ToString() + " $";
    }

    public void ToggleMoneyMenu() 
    {
        moneyMenu.gameObject.SetActive(!moneyMenu.gameObject.activeSelf);
    }
    
}
