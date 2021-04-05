using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public int hinta;
    public GameObject player;
    private Image powderImg;
    private Image tripleImg;
    private Image baitImg;
    private Image poisonImg;
    private Image collarImg;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        powderImg = GameObject.FindGameObjectWithTag("PowderInventory").GetComponent<Image>(); ;
        tripleImg = GameObject.FindGameObjectWithTag("TripleInventory").GetComponent<Image>(); ;
        poisonImg = GameObject.FindGameObjectWithTag("PoisonInventory").GetComponent<Image>(); ;
        baitImg = GameObject.FindGameObjectWithTag("BaitInventory").GetComponent<Image>();
        collarImg = GameObject.FindGameObjectWithTag("CollarInventory").GetComponent<Image>();
    }
    public void PickGunpowder()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.explosiveshot = true;
            powderImg.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }
    public void PickRatpoison()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.poisonammo = true;
            poisonImg.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }
    public void PickTripleShot()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.tripleshot = true;
            tripleImg.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }

    public void PickBait()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            BaitScript.hasBait = true;
            Destroy(gameObject);
            baitImg.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }

    public void PickCollar()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.critical = true;
            collarImg.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }


    public void Teleport()
    {
        if (PlayerController.visitedshop == false && PlayerController.visitedboss == false)
        {
            player.transform.Translate(-10.23f, 15.94f, 0);
        }
        else if (PlayerController.visitedshop == true && PlayerController.visitedboss == false)
        {
            player.transform.Translate(33.51f, -73.75f, 0);
        }
        else if (PlayerController.visitedboss == true && PlayerController.visitedshop == false)
        {
            player.transform.Translate(-31.4f, 25.16f, 0);
            PlayerController.visitedboss = false;
        }
    }
}
