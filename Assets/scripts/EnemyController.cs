using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    private float timeSinceSpawn = 0;
    private float stride = 4;
    private float velocity = -2;

    private float initialX;

    public float health = 100;

    public GameObject explosion;
    
    void Start()
    {
        initialX = transform.position.x;
        health = Random.Range(40, 100);
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        transform.position = new Vector2(initialX + (float)Math.Sin(timeSinceSpawn) * stride, transform.position.y);
        transform.Translate(new Vector2(0, velocity * Time.deltaTime));
    }

    void die()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().score += 100;

        Instantiate(explosion, transform.position, Quaternion.identity);
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            die();
            other.gameObject.GetComponent<PlayerController>().health -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Bullet b = other.gameObject.GetComponent<Bullet>();
            health -= b.damage;

            b.die();
            
            if (health <= 0)
            {
                die();
            }
        }
    }
}
