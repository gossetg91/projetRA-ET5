using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectReplacement : MonoBehaviour
{
    public GameObject boardTag;
    public GameObject referenceTag;
    public Text toModify;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        toModify.text = boardTag.GetComponent<Transform>().position.ToString();
    }
}
