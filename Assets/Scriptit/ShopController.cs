using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public int hinta;
    public GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    public void PickGunpowder()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.explosiveshot = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }
    public void PickRatpoison()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.poisonammo = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }
    public void PickTripleShot()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            Destroy(gameObject);
            PlayerController.tripleshot = true;
        }
        else
        {
            Debug.Log("Not enough Fish!");
        }
    }

    public void PickBait()
    {
        if (PlayerController.raha > hinta)
        {
            PlayerController.raha = PlayerController.raha - hinta;
            BaitScript.hasBait = true;
            Destroy(gameObject);
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
