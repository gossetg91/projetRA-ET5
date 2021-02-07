using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomMoneyScript : MonoBehaviour
{
    public InputField inputMoney;
    public Button addButton;
    public Button removeButton;
    public GameObject UICanvas;

    // Start is called before the first frame update
    void Start()
    {
        addButton.onClick.AddListener(() => {
            int n;
            if (int.TryParse(inputMoney.text, out n)) UICanvas.GetComponent<UIScript>().AddMoney(n); 
        } );
        removeButton.onClick.AddListener(() => {
            int n;
            if (int.TryParse(inputMoney.text, out n)) UICanvas.GetComponent<UIScript>().RemoveMoney(n); 
        } );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
