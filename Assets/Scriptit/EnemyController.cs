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
    public float attackRange;

    //Komponentit
    public GameObject projectile;
    public Transform player;
    private AudioSource Boom;
    PlayerController playerscript;
    GameObject playerref;
    public Animator animator;

    //UI
    public EnemyHealthbar healthbar;

    //ID(melee = 1 vai range = 0)
    public int id;

    //Timerit yms.
    private float lastAttackTime;
    public bool isPoisoned = false;
    float elapsed = 0f;
    public int ticks = 0;

    void Start()
    {
        //Alustetaan vastustajalle löydettävä pelaaja, ammusääni ja statsit
        playerref = GameObject.FindGameObjectWithTag("Player");
        playerscript = playerref.GetComponent<PlayerController>();
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

        //Ammuntascripti
        if(attackSpeed <= 0 && id == 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Boom.Play();
            attackSpeed = startAttackSpeed;

        }else
        {
            attackSpeed -= Time.deltaTime;
        }

        animator.SetFloat("Horizontal", transform.position.x);
        animator.SetFloat("Vertical", transform.position.y);
        animator.SetFloat("Speed", transform.position.magnitude);

        //Melee iskuscripti
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < attackRange && id == 1)
        {
            if (attackSpeed <= 0)
            {
                playerscript.LoseHealth(5);
                Boom.Play();
                attackSpeed = startAttackSpeed;
            }
            else
            {
                attackSpeed -= Time.deltaTime;
            }
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

    private void FixedUpdate()
    {
        
    }

    //Healthbarin toiminta
    public void TakeHit(int dmg)
    {
        hpupdate = hpupdate - dmg;
        healthbar.SetHealth(hpupdate, maxhp);
    }



}
