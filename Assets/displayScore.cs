using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displayScore : MonoBehaviour
{
    private int scoreDice1;
    private int scoreDice2;

    public Text txt;
    public GameObject dice1;
    public GameObject dice2;

    public int score;
 
    // Start is called before the first frame update
    void Start()
    {
        txt.text = "Somme des dès = 0";
    }

    // Update is called once per frame
    void Update()
    {
        diceRoller diceRollerScript1 = dice1.GetComponent<diceRoller>();
        diceRoller diceRollerScript2 = dice2.GetComponent<diceRoller>();
        scoreDice1 = diceRollerScript1.getScore();
        scoreDice2 = diceRollerScript2.getScore();
        if(scoreDice1!=0 || scoreDice2!=0){
            updateScore();
            scoreDice1 = 0;
            scoreDice2 = 0;
        }
    }

    void updateScore(){
        score = scoreDice1 + scoreDice2;
        txt.text = "Sommes des dès = "+score.ToString();
    }
}
