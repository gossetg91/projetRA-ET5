using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtualButtonEvent : MonoBehaviour
{
    public GameObject vbBtnObj;
    public GameObject dice1;
    public GameObject dice2;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("diceButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed");
        diceRoller diceRollerScript1 = dice1.GetComponent<diceRoller>();
        diceRoller diceRollerScript2 = dice2.GetComponent<diceRoller>();
        diceRollerScript1.startAnimation();
        diceRollerScript2.startAnimation();
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Released");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
