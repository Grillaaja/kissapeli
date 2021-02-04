using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{

    public float speed = 10f;
    public Rigidbody2D rb;
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
            Destroy(gameObject);
        }else if (collision.tag == "Player")
        {
            //eimitää
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
