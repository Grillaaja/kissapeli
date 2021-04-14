﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionScript : MonoBehaviour
{
    public static bool hasPotion = false;
    public KeyCode interactKey;
    private float timer;
    private bool timeStarted = false;
    private Image potionImg;
    private Text potionTxt;

    void Start()
    {
        potionImg = GameObject.FindGameObjectWithTag("PotionInventory").GetComponent<Image>();
        potionTxt = GameObject.FindGameObjectWithTag("PotionText").GetComponent<Text>();
    }

    void Update()
    {
        if (hasPotion)
        {
            if (Input.GetKeyDown(interactKey))
            {
                timeStarted = true;
            }
        }
        if (timeStarted)
        {
            timer = timer + Time.deltaTime;
            Debug.Log("timer=" + timer + "timedeltatime=" + Time.deltaTime);
            if (timer > 2f)
            {
                timeStarted = false;
                timer = 0f;
                PlayerController.hpUpdate = 20;
                hasPotion = false;
                potionImg.enabled = false;
                potionTxt.enabled = false;
            }
        }
    }
}
