using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    //Statsit
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    private float attackSpeed;
    public float startAttackSpeed;
    public int hp;
    public int hpupdate = 0;
    public int maxhp;

    //Komponentit
    public GameObject projectile;
    public Transform player;
    private AudioSource Boom;

    //UI
    public EnemyHealthbar healthbar;

    void Start()
    {
        //Alustetaan vastustajalle löydettävä pelaaja, ammusääni ja statsit
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackSpeed = startAttackSpeed;
        Boom = GetComponent<AudioSource>();
        hpupdate = hp;
        maxhp = hp;
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

        //Tuhoutuminen
        if(hpupdate <= 0)
        {
            Destroy(gameObject);
            PlayerController.raha = PlayerController.raha + 10;
        }
        //hpbar update
        healthbar.SetHealth(hpupdate, maxhp);

    }

    //Healthbarin toiminta
    public void TakeHit(int dmg)
    {
        hpupdate = hpupdate - dmg;
        healthbar.SetHealth(hpupdate, maxhp);
    }

}
