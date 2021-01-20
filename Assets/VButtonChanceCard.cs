using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VButtonChanceCard : MonoBehaviour
{
    public GameObject vbBtnObj;
    public GameObject cubeObj;

    // Start is called before the first frame update
    void Start()
    {
        vbBtnObj = GameObject.Find("VButtonChanceCard");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        cubeObj.SetActive(false);
    }

    public void OnButtonPressed(VirtualButtonBehaviour vb) 
    {
        cubeObj.SetActive(true);
        Debug.Log("Button pressed");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) 
    {
        cubeObj.SetActive(false);
        Debug.Log("Button released");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
