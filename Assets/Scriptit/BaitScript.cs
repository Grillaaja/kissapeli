using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaitScript : MonoBehaviour
{
    public static bool hasBait = false;
    public KeyCode interactKey;
    public Transform player;
    public GameObject meat;
    private float timer;
    private bool timeStarted = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasBait)
        {
            if (Input.GetKeyDown(interactKey) && !timeStarted)
            {
                hasBait = false;
                EnemyController.isThereAnyMeat = true;
                Instantiate(meat, player.position, player.rotation);
                timeStarted = true;
            }
        }
        if (timeStarted)
        {
            timer = timer + Time.deltaTime;
            Debug.Log("timer=" + timer + "timedeltatime=" + Time.deltaTime);
            if (timer > 5f)
            {
                EnemyController.isThereAnyMeat = false;
                timeStarted = false;
                timer = 0f;
                Destroy(GameObject.FindGameObjectWithTag("Dummy"));
            }
        }
    }
}