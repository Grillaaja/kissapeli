﻿using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{   
    //Komponentit
    public Rigidbody2D rgbody;
    public GameObject projectile;
    private Camera cam;

    //UI tekstit
    public Text collectedText;
    public Text healtit;
    public Text damaget;
    public Text speedit;
    public Text aspeedit;

    //Statsit
    public static int collectedAmount = 0;
    public float speed;
    public static float speedUpdate = 0;
    public int hp;
    public static int hpUpdate = 0;
    public float attSpeed;
    public static float attSpeedUpdate = 0;
    public int dmg;
    public static int dmgUpdate = 0;
    



    
    void Start()
    {
        // Alustetaan pelaajan attribuutit
        hpUpdate = hp;
        attSpeedUpdate = attSpeed;
        speedUpdate = speed;
        dmgUpdate = dmg;
        cam = Camera.main;
    }

    void Update()
    {
        //Alustetaan X ja Y akseleiden liikkumispainikkeet
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        //Alustetaan pelaajan nopeus "Speed" statsista ja näkyvät UI tekstit
        rgbody.velocity = new Vector3(hor * speedUpdate, ver * speedUpdate, 0);
        collectedText.text = "Items collected: " + collectedAmount;
        healtit.text = "HP = " + hpUpdate;
        damaget.text = "DMG = " + dmgUpdate;
        speedit.text = "MS = " + speedUpdate;
        aspeedit.text = "AS = " + attSpeedUpdate;

        //Jos kerättyjä esineitä on tarpeeksi, teksti muuttuu
        if(collectedAmount >= 5)
        {
            collectedText.text = "VOITIT PELIN";
        }

    }


}
