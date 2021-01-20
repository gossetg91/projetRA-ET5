using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class diceRoller : MonoBehaviour
{
    private float x;
    private float y;
    private bool rotateX;
    private float rotationSpeed;
    public bool stop;

    private float waitTime;
    private float timer;
    private float visualTime;

    void Start()
    {
        x = 0.0f;
        y = 0.0f;
        stop = false;
        rotationSpeed = 700.0f;

        waitTime = 5.0f;
        timer = 0.0f;
        visualTime = 0.0f;
    }

    void Update()
    {
        if(!stop){
            timer += Time.deltaTime;
            slowMove();
        } 
        if (timer > waitTime)
        {
            visualTime = timer;

            timer = timer - waitTime;
            ChooseFace(Random.Range(1,7));
            stop = true;
        }
    }

    void ChooseFace(int face)
    {
        switch (face)
        {
            case 1 :
                transform.localRotation = Quaternion.Euler(0, 0, 270);
                break;
            case 2 :
                transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
            case 3 :
                transform.localRotation = Quaternion.Euler(270, 0, 0);
                break;
            case 4 :
                transform.localRotation = Quaternion.Euler(90, 0, 0);
                break;
            case 5 :
                transform.localRotation = Quaternion.Euler(180, 0, 0);
                break;
            case 6 :
                transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            default:
                print("face incorrect  : ");
                print(face);
                break;
        }
    }

    void slowMove()
    {
        x += Time.deltaTime * rotationSpeed;
        y -= Time.deltaTime * rotationSpeed;

        if (x > 360.0f){
            x = 0.0f;
        }
        if (y < 0.0f){
            y = 360.0f;
        }

        transform.localRotation = Quaternion.Euler(x, 0, y);
    }
}
