using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    //Statseja ja hpbar
    public int hp;
    public int maxhp;
    public EnemyHealthbar healthbar;
    private float attackSpeed;
    public float startAttackSpeed;

    //timereita yms
    public bool isPoisoned = false;
    public int ticks = 0;
    float elapsed = 0f;

    //Komponentteja
    public GameObject projectile1;
    public GameObject projectile2;
    PlayerController playerscript;
    GameObject playerref;
    public Transform player;

    void Start()
    {
        //Alustetaan pelaaja,sekä omat hp:t
        maxhp = hp;
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        attackSpeed = startAttackSpeed;
    }
    void Update()
    {
        //Ammuntascripti
        if (attackSpeed <= 0 && PlayerController.visitedboss && true)
        {
            Instantiate(projectile1, transform.position, Quaternion.identity);
            attackSpeed = startAttackSpeed;

        }
        else
        {
            attackSpeed -= Time.deltaTime;
        }
        //Tuhoutuminen
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
        //Myrkytysvahingon otto
        if (ticks > 4)
        {
            isPoisoned = false;
        }
        if (isPoisoned)
        {
            elapsed += Time.deltaTime;
            if (elapsed >= 1f)
            {
                elapsed = elapsed % 1f;
                TakeHit(8);
                ticks++;
            }
        }

        //hpbar update
        healthbar.SetHealth(hp, maxhp);
    }

    public void TakeHit(int dmg)
    {
        hp = hp - dmg;
        healthbar.SetHealth(hp, maxhp);
    }
}
