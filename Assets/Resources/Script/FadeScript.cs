using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour
{
    public double timeCounter = 0.2;
    //double alphaInit = GetComponent<Image>().color.a;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fade()
    {
        for (double i=0.0; i<timeCounter; i+=Time.deltaTime)
        {   
            //GetComponent<Image>().color.a = i/timeCounter * alphaInit;
        }
    }
}
