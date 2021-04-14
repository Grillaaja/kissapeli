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
    private Image potionImg;
    private Text baitText;
    private Text potionText;

    public GameObject teleportDestination;

    private void Start()
    {
        teleportDestination = GameObject.FindGameObjectWithTag("TPDestination") ;
        player = GameObject.FindGameObjectWithTag("Player");

        powderImg = GameObject.FindGameObjectWithTag("PowderInventory").GetComponent<Image>(); ;
        tripleImg = GameObject.FindGameObjectWithTag("TripleInventory").GetComponent<Image>(); ;
        poisonImg = GameObject.FindGameObjectWithTag("PoisonInventory").GetComponent<Image>(); ;
        baitImg = GameObject.FindGameObjectWithTag("BaitInventory").GetComponent<Image>();
        collarImg = GameObject.FindGameObjectWithTag("CollarInventory").GetComponent<Image>();
        potionImg = GameObject.FindGameObjectWithTag("PotionInventory").GetComponent<Image>();
        potionText = GameObject.FindGameObjectWithTag("PotionText").GetComponent<Text>();
        baitText = GameObject.FindGameObjectWithTag("BaitText").GetComponent<Text>();
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
            baitText.enabled = true;
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

    public void PickPotion()
    {
        if (PlayerController.raha >= hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            PotionScript.hasPotion = true;
            Destroy(gameObject);
            potionImg.enabled = true;
            potionText.enabled = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }

    public void Teleport()
    {
        player.transform.position = teleportDestination.transform.position;
    }
}
