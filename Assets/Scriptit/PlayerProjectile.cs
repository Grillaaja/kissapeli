using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    GameObject enemy;
    EnemyController script;
    void Start()
    {
        
    }

    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            //vihun hp pois
            enemy = collision.gameObject;
            script = enemy.GetComponent<EnemyController>();
            script.TakeHit(PlayerController.dmgUpdate);
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
