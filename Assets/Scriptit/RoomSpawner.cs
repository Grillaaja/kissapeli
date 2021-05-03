using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour {
    
    public int openingDirection ;
    
    private RoomTemplates templates;
    private int rand;
    private bool spawned = false;
    private static bool bossRoomSpawned = false;
    public float waitTime = 4f;
    void Start(){
        Destroy(gameObject, waitTime) ;
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);

        foreach(var room in templates.bottomRooms)
        {
            var bossroom = room.GetComponent<Testi>();
        }

    }
    
    void Spawn(){
        if(spawned == false){

            if(openingDirection == 1){
                rand = Random.Range(0, templates.bottomRooms.Length);
                if ((templates.bottomRooms[rand].GetComponent<Testi>() != null) && bossRoomSpawned)
                {
                    Instantiate(templates.bottomRooms[rand -1], transform.position, templates.bottomRooms[rand].transform.rotation);
                }
                else if (templates.bottomRooms[rand].GetComponent<Testi>() != null)
                {
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                    bossRoomSpawned = true;
                }
                else
                {
                    Instantiate(templates.bottomRooms[rand], transform.position, templates.bottomRooms[rand].transform.rotation);
                }
            } else if(openingDirection == 2){
                rand = Random.Range(0, templates.topRooms.Length);
                if ((templates.topRooms[rand].GetComponent<Testi>() != null) && bossRoomSpawned)
                {
                    Instantiate(templates.topRooms[rand - 1], transform.position, templates.topRooms[rand].transform.rotation);
                }
                else if (templates.topRooms[rand].GetComponent<Testi>() != null)
                {
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                    bossRoomSpawned = true;
                }
                else
                {
                    Instantiate(templates.topRooms[rand], transform.position, templates.topRooms[rand].transform.rotation);
                }
            } else if(openingDirection == 3){
                rand = Random.Range(0, templates.leftRooms.Length);
                if ((templates.leftRooms[rand].GetComponent<Testi>() != null) && bossRoomSpawned)
                {
                    Instantiate(templates.leftRooms[rand - 1], transform.position, templates.leftRooms[rand].transform.rotation);
                }
                else if (templates.leftRooms[rand].GetComponent<Testi>() != null)
                {
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                    bossRoomSpawned = true;
                }
                else
                {
                    Instantiate(templates.leftRooms[rand], transform.position, templates.leftRooms[rand].transform.rotation);
                }
            } else if(openingDirection == 4){
                rand = Random.Range(0, templates.rightRooms.Length);
                if ((templates.rightRooms[rand].GetComponent<Testi>() != null) && bossRoomSpawned)
                {
                    Instantiate(templates.rightRooms[rand - 1], transform.position, templates.rightRooms[rand].transform.rotation);
                }
                else if (templates.rightRooms[rand].GetComponent<Testi>() != null)
                {
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                    bossRoomSpawned = true;
                }
                else
                {
                    Instantiate(templates.rightRooms[rand], transform.position, templates.rightRooms[rand].transform.rotation);
                }

            }
        spawned = true;
        }
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")){
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false ) {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity) ;
                Destroy(gameObject) ;
            }
            spawned = true ;
        }

            
        }
    
}
