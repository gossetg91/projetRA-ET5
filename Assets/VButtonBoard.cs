using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Vuforia;

public class VButtonBoard : MonoBehaviour
{
    public string boards_path = @"Textures/Board/";

    public GameObject vbBtnObj;
    public GameObject boardObj;

    public List<Object> textures = new List<Object>();

    private int cpt = 0;

    void Start()
    {
        // Prepare material
        Material mat = new Material(Shader.Find("Unlit/Texture"));
        boardObj.GetComponent<Renderer>().material = mat;

        // Load board's textures
        Object [] texturesTMP = Resources.LoadAll(boards_path);

        // Shuffle cards
        textures = texturesTMP.OrderBy(x => Random.value).ToList();


        // Init button
        vbBtnObj = GameObject.Find("VButtonBoard");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);

        changeBoardTexture();
    }

    void Update()
    {
        
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) 
    {
        Debug.Log("Button released");
        changeBoardTexture();
    }

    private void changeBoardTexture() {
        Texture texture = textures[cpt % textures.Count] as Texture;
            
        if(texture) boardObj.GetComponent<Renderer>().material.mainTexture = texture;
        else Debug.LogError("Unable to load board texture");

        cpt++;
    }
}
