using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Canvas moneyMenu;
    public Text moneyText;
    public float fadeCounter = 0.2f;

    float money = 15.0f;
    CanvasGroup moneyMenuGroup;
    float alphaInit = 1.0f;
    bool inFading = true;

    // Start is called before the first frame update
    void Start()
    {
        InitMoneyMenu();
        UpdateMoney();
        moneyMenuGroup = moneyMenu.gameObject.GetComponent<CanvasGroup>();
    }


    public void AddMoney(float amount)
    {
        money += amount;
        UpdateMoney();
    }

    public void RemoveMoney(float amount)
    {
        money -= amount;
        UpdateMoney();
    }

    public void Add2()
    {
        AddMoney(2.0f);
    }



    public void UpdateMoney()
    {
        moneyText.text = money.ToString("F2") + "M $";
    }


    public void InitMoneyMenu() 
    {
        moneyMenu.gameObject.SetActive(false);
    }

    public void ToggleActiveMenu()
    {
        moneyMenu.gameObject.SetActive(!moneyMenu.gameObject.activeSelf);
    }

    public void ToggleMoneyMenu() 
    {
        if (moneyMenu.gameObject.activeSelf) {
            StartCoroutine(Fade());
            Invoke("ToggleActiveMenu", fadeCounter);
        }
        else {
            moneyMenu.gameObject.SetActive(!moneyMenu.gameObject.activeSelf);
            StartCoroutine(Fade());
        }
    }

    IEnumerator Fade()
    {
        for (float i=0.0f; i<=fadeCounter; i+= (float)Time.deltaTime)
        {   
            moneyMenuGroup.alpha = (float) (inFading?0.0f:1.0f) + (inFading?1f:-1f) * Mathf.Clamp01(i/fadeCounter * alphaInit);
            yield return null;
        }
        inFading = !inFading;
    }
    
}
