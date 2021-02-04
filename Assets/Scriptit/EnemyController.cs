using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Statsit
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float attackSpeed;
    public float startAttackSpeed;

    //Komponentit
    public GameObject projectile;
    public Transform player;
    private AudioSource Boom;

    void Start()
    {
        //Alustetaan vastustajalle löydettävä pelaaja, ammusääni ja statsit
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackSpeed = startAttackSpeed;
        Boom = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Liikkumis, ja löytämis scripti
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, player.position) < retreatDistance){
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        //Ammuntascripti
        if(attackSpeed <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Boom.Play();
            attackSpeed = startAttackSpeed;

        }else
        {
            attackSpeed -= Time.deltaTime;
        }

    }
}
