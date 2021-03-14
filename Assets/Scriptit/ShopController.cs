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
        if (PlayerController.visitedshop == false)
        {
            player.transform.Translate(0, 20, 0);
            PlayerController.visitedshop = true;
            //Debug.Log(PlayerController.visitedshop);
        }
        else if (PlayerController.visitedshop == true)
        {
            player.transform.Translate(0, -20, 0);
            PlayerController.visitedshop = false;
            //Debug.Log(PlayerController.visitedshop);
        }
    }
}
