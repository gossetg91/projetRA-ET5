using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class virtualButtonEvent : MonoBehaviour
{
    public GameObject vbBtnObj;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("diceButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        Debug.Log("heyyyyyyyyyyyyyyy");
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("Button Pressed");
        vbBtnObj.Get<>();
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
