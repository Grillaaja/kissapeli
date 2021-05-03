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
    public float revealDistance;
    private float attackSpeed;
    public float startAttackSpeed;
    public float hp;
    public float hpupdate = 0;
    public float maxhp;
    public float attackRange;
    public float splashDistance = 4.0f;
    public int rahaPalkinto = 10;

    //Komponentit
    public GameObject projectile;
    public GameObject critUi;
    public Transform player;
    private AudioSource Boom;
    PlayerController playerscript;
    GameObject playerref;
    public Animator animator;
    public GameObject explosion;
    public GameObject meat;
    public GameObject uzi;
    public GameObject summonCircle;
    private GameObject[] spawnp;

    //UI
    public EnemyHealthbar healthbar;

    //ID(melee = 1 vai range = 0)
    public int id;

    //Timerit yms.
    private float lastAttackTime;
    public bool isPoisoned = false;
    float elapsed = 0f;
    public int ticks = 0;
    public static bool isThereAnyMeat = false;
    private int critical;

    int rand = 0;

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

        spawnp = GameObject.FindGameObjectsWithTag("Spawnpoint");
    }

    void Update()
    {
        critical = Random.Range(0, 10);
        //Liikkumis, ja löytämis scripti, sekä ansan priorisointi
        if (!isThereAnyMeat) 
        {
            meat = null;
            if (Vector2.Distance(transform.position, player.position) > stoppingDistance && Vector2.Distance(transform.position, player.position) < revealDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
            {
                transform.position = this.transform.position;
            } else if (Vector2.Distance(transform.position, player.position) < retreatDistance) {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
            }
        }
        else
        {
            meat = GameObject.FindGameObjectWithTag("Dummy");
            transform.position = Vector2.MoveTowards(transform.position, meat.transform.position, speed * Time.deltaTime);
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
                TakeHit(8 * PlayerController.ratPoisonKerroin);
                ticks++;
            }
        }

        //Ammuntascripti
        if(attackSpeed <= 0 && id == 0 && Vector2.Distance(transform.position, player.position) < revealDistance)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            Boom.Play();
            attackSpeed = startAttackSpeed;

        }else
        {
            attackSpeed -= Time.deltaTime;
        }
        //Mage-ammuntascripti
        if (attackSpeed <= 0 && id == 2 && Vector2.Distance(transform.position, player.position) < revealDistance)
        {
            Boom.Play();
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            Instantiate(projectile, transform.position, Quaternion.identity);
            attackSpeed = startAttackSpeed;

        }
        else
        {
            attackSpeed -= Time.deltaTime;
        }

        animator.SetFloat("Horizontal", player.position.x - transform.position.x);
        animator.SetFloat("Vertical", player.position.y - transform.position.y);
        animator.SetFloat("Speed", transform.position.magnitude);

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        //Pommirotan räjähdysmekaniikka

        if (distanceToPlayer < (splashDistance -1) && id == 3)
        {
            if (splashDistance > 0)
            {
                Instantiate(explosion, transform.position, transform.rotation);
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashDistance);

                foreach (var hitCollider in hitColliders)
                {
                    var vihu = hitCollider.GetComponent<EnemyController>();
                    var pelaaja = hitCollider.GetComponent<PlayerController>();
                    if (vihu)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        var dmgPercentage = Mathf.InverseLerp(splashDistance, 0, distance);
                        vihu.TakeHit(dmgPercentage * 50);
                    }
                    if (pelaaja)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        pelaaja.LoseHealth(7);
                    }
                }
                Destroy(gameObject);
            }
        }

        //Minibossi iskuscripti


        if (id == 4 && distanceToPlayer < revealDistance)
        {

            if(attackSpeed <= 0)
            {
                animator.SetTrigger("Summon");
                Instantiate(projectile, spawnp[rand].transform.position, spawnp[rand].transform.rotation);
                attackSpeed = startAttackSpeed;
                rand = Random.Range(0, 4);
                Instantiate(summonCircle, spawnp[rand].transform.position, spawnp[rand].transform.rotation);
            }
            else
            {
                attackSpeed -= Time.deltaTime;
            }
        }

        //Melee iskuscripti
        if (distanceToPlayer < attackRange && id == 1)
        {
            if (attackSpeed <= 0)
            {
                playerscript.LoseHealth(5);
                Boom.Play();
                animator.SetTrigger("Punch");
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
            if(id == 4)
            {
                Instantiate(uzi, transform.position, transform.rotation);
                PlayerController.raha = PlayerController.raha + 30;
            }

            Destroy(gameObject);
            PlayerController.raha = PlayerController.raha + rahaPalkinto;
        }
        //hpbar update
        healthbar.SetHealth(hpupdate, maxhp);

    }

    private void FixedUpdate()
    {
        
    }

    //Healthbarin toiminta
    public void TakeHit(float dmg)
    {
        if (PlayerController.critical && critical > 8)
        {
            hpupdate = hpupdate - (dmg * 4) * PlayerController.collarKerroin;
            healthbar.SetHealth(hpupdate, maxhp);
            Instantiate(critUi, transform.position, transform.rotation);
            Debug.Log("Crit!");
        }
        else
        {
            hpupdate = hpupdate - dmg;
            healthbar.SetHealth(hpupdate, maxhp);
        }
    }



}
