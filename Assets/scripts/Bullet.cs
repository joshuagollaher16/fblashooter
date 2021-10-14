using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float velocity;
    public WeaponType weaponType;
    public float damage = 0;
    
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, velocity);
        Destroy(gameObject, 15f);
    }

    public void die()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().score += 10;
        Destroy(gameObject);
    }
    
}
