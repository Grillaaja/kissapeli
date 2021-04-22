using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Sprite chestOpen;
    public GameObject[] treasures;
    public int chestId;
    public GameObject[] lotteryTreasures;
    public int price;

    public SpriteRenderer sp;

    public bool isOpened = false;
    public void OpenChest()
    {
        //Tavallinen arkku
        if (!isOpened && chestId == 1)
        {
            isOpened = true;
            int rand = Random.Range(0, treasures.Length);
            sp.sprite = chestOpen;
            Instantiate(treasures[rand], transform.position + new Vector3(0, -1.3f, 0), Quaternion.identity);
        }
        else
        {
        }
        //Lottoarkku
        if (!isOpened && chestId == 2 && PlayerController.raha >= price)
        {
            isOpened = true;
            PlayerController.raha -= price;
            int rand = Random.Range(0, lotteryTreasures.Length);
            sp.sprite = chestOpen;
            Instantiate(lotteryTreasures[rand], transform.position + new Vector3(0, -1.3f, 0), Quaternion.identity);
        }
    }
    
}
