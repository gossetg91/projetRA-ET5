using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using Vuforia;

public class VButtonChanceCard : MonoBehaviour
{
    public string cards_path = @"Textures/Cards/Front/Chance/";

    public GameObject vbBtnObj;
    public GameObject cardObj;

    public float rotationSpeed = 0.25f;

    public List<string> textures = new List<string>();

    private bool hasClicked = false;
    private bool isRotating = false;
    private GameObject cardFrontObj;
    private GameObject cardBackObj;

    private int nbCardsPicked = 0;

    private float x = 0;
    private float cpt = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Init card
        cardObj.SetActive(false);
        cardFrontObj = cardObj.transform.GetChild(0).gameObject;
        cardBackObj = cardObj.transform.GetChild(1).gameObject;

        cardFrontObj.SetActive(false);

        // Prepare material
        Material mat = new Material(Shader.Find("Unlit/Texture"));
        cardFrontObj.GetComponent<Renderer>().material = mat;

        // Load card's textures
        string[] files = Directory.GetFiles(Path.Combine(Application.dataPath + @"/Resources/", cards_path), "*.jpg");

        foreach (string file in files)
        {
            FileInfo info = new FileInfo(file);
            textures.Add(Path.GetFileNameWithoutExtension(info.Name));
        }

        // Shuffle cards
        textures = textures.OrderBy(x => Random.value).ToList();

        // Init button
        vbBtnObj = GameObject.Find("VButtonChanceCard");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
    }

    // Update is called once per frame
    void Update()
    {
        cpt += Time.deltaTime;

        if(hasClicked && isRotating) {
            x += Time.deltaTime * rotationSpeed;

            if(x < 180.0f) {
                cardBackObj.transform.Rotate(new Vector3(x, 0, 0));
            }else{
                x = 0.0f;
                isRotating = false;
                cardBackObj.SetActive(false);
                cardFrontObj.SetActive(true);
            }
        }

        if(hasClicked && !isRotating && cpt >= 5.0f) {
            cpt = 0;
            cardFrontObj.SetActive(false);
            hasClicked = false;
        }
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb) 
    {
        cardObj.SetActive(true);
        Debug.Log("Button released");

        if(!hasClicked) {
            hasClicked = true;
            isRotating = true;

            cardBackObj.SetActive(true);

            Texture texture = Resources.Load(cards_path + textures[nbCardsPicked % textures.Count]) as Texture;
            
            if(texture) cardFrontObj.GetComponent<Renderer>().material.mainTexture = texture;
            else Debug.LogError("Unable to load front card texture");

            nbCardsPicked++;
        }
    }
}
