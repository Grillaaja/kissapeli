using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionController : MonoBehaviour
{

    //Alustetaan tavaran id
    public int id;
    public GameObject indicator;
    private Transform player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        
    }

    //Pelaajan osuessa tavaraan, tiettyjä muutoksia tapahtuu pelaajan statseihin
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Item 1
        if (collision.tag == "Player" && id == 0)
        {
            Instantiate(indicator, player.position, player.rotation);
            PlayerController.collectedAmount++;
            PlayerController.hpUpdate++;
            Destroy(gameObject);
        }
        //Item 2
        if (collision.tag == "Player" && id == 1)
        {
            Instantiate(indicator, player.position, player.rotation);
            PlayerController.collectedAmount++;
            if((PlayerController.dmgUpdate / 5) < 1)
            {
                PlayerController.dmgUpdate++;
            }
            else
            {
                PlayerController.dmgUpdate = PlayerController.dmgUpdate + (PlayerController.dmgUpdate / 5);
            }
            Destroy(gameObject);
        }
        //Item 3
        if (collision.tag == "Player" && id == 2)
        {
            Instantiate(indicator, player.position, player.rotation);
            PlayerController.collectedAmount++;
            PlayerController.speedUpdate = PlayerController.speedUpdate + (PlayerController.speedUpdate / 5);
            Destroy(gameObject);
        }
        //Item 4
        if (collision.tag == "Player" && id == 3)
        {
            Instantiate(indicator, player.position, player.rotation);
            PlayerController.collectedAmount++;
            PlayerController.attSpeedUpdate = PlayerController.attSpeedUpdate - (PlayerController.attSpeedUpdate / 7);
            Destroy(gameObject);
        }
    }
}
