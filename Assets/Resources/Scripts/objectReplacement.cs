using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectReplacement : MonoBehaviour
{
    public GameObject boardTag;
    public GameObject referenceTag;
    public GameObject token;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        token.GetComponent<Transform>().position = referenceTag.GetComponent<Transform>().position;
        token.GetComponent<Transform>().position += new Vector3(0.0f,0.015f,0.0f);
        Vector3 xAxis = new Vector3(1.0f,0.0f,0.0f);
        Vector3 zAxis = new Vector3(0.0f,0.0f,1.0f);
        Vector3 differenceBoardTag = boardTag.GetComponent<Transform>().position-referenceTag.GetComponent<Transform>().position;
        differenceBoardTag.y = 0;
        float offsetFactor = 1-Mathf.Abs(((Mathf.Abs(Vector3.Dot(Vector3.Normalize(differenceBoardTag),xAxis))-Mathf.Abs(Vector3.Dot(Vector3.Normalize(differenceBoardTag),zAxis)))-0.1f));
        offsetFactor = differenceBoardTag.magnitude-(0.10f+0.05f*offsetFactor);
        differenceBoardTag= Vector3.Normalize(differenceBoardTag);
        differenceBoardTag *= offsetFactor;

        if(offsetFactor>0)
        {
            token.GetComponent<Transform>().position += differenceBoardTag;
        }
    }
}
