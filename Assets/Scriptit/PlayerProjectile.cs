using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject enemy;
    EnemyController script;
    public SpriteRenderer sp;
    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
        if (PlayerController.poisonammo)
        {
            sp.color = new Color(0,1,0,1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            //vihun hp pois
            enemy = collision.gameObject;
            script = enemy.GetComponent<EnemyController>();
            script.TakeHit(PlayerController.dmgUpdate);
            if (PlayerController.poisonammo)
            {
                script.ticks = 0;
                script.isPoisoned = true;
            }
            Destroy(gameObject);
        }else if (collision.tag == "Player" || collision.tag == "Item" || collision.tag == "Projectile")
        {
            //eimitää
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
