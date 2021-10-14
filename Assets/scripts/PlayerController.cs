using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public enum WeaponType
{
    Yellow = 0,
    Green = 1,
    Missile = 2,
}

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;

    private Sprite forward;
    [SerializeField] private Sprite left;
    [SerializeField] private Sprite right;
    
    public int health = 3;
    public int score = 0;

    private bool isFiring = false;
    [SerializeField] private Dictionary<WeaponType, float> firingDelay;
    private float firingTime;

    [SerializeField] private Sprite yellow;
    [SerializeField] private Sprite green;
    [SerializeField] private Sprite missile;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawn;

    public WeaponType currentWeapon = WeaponType.Yellow;
    
    [SerializeField]
    
    
    void Start()
    {
        forward = GetComponent<SpriteRenderer>().sprite;
        firingDelay = new Dictionary<WeaponType, float>();
        
        firingDelay[WeaponType.Yellow] = 0.1f;
        firingDelay[WeaponType.Green] = 0.2f;
        firingDelay[WeaponType.Missile] = 0.5f;
    }

    void handleWASD()
    {
        Vector2 movement = Vector2.zero;
        
        if (Input.GetKey(KeyCode.W))
        {
            movement.y += 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<SpriteRenderer>().sprite = left;
            movement.x -= 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.y -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<SpriteRenderer>().sprite = right;
            movement.x += 1;
        }

        if (movement.x == 0)
        {
            GetComponent<SpriteRenderer>().sprite = forward;
        }
        
        transform.Translate(movement * moveSpeed * Time.deltaTime);
    }

    void handleFiring()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isFiring = true;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFiring = false;
        }

        if (isFiring)
        {
            firingTime += Time.deltaTime;
            if (firingTime > firingDelay[currentWeapon])
            {
                firingTime = 0;

                var go = Instantiate(bullet, bulletSpawn.transform.position, Quaternion.identity);
                Sprite bulletSprite = null;
                int bulletVelocity = 0;
                int bulletDamage = 0;
                
                switch (currentWeapon)
                {
                    case WeaponType.Yellow:
                        bulletSprite = yellow;
                        bulletVelocity = 10;
                        bulletDamage = 25;
                        break;
                    case WeaponType.Green:
                        bulletSprite = green;
                        bulletVelocity = 8;
                        bulletDamage = 40;
                        break;
                    case WeaponType.Missile:
                        bulletSprite = missile;
                        bulletVelocity = 5;
                        bulletDamage = 100;
                        break;
                    default:
                        break;
                }
                go.GetComponent<SpriteRenderer>().sprite = bulletSprite;
                go.GetComponent<Bullet>().velocity = bulletVelocity;
                go.GetComponent<Bullet>().weaponType = currentWeapon;
                go.GetComponent<Bullet>().damage = bulletDamage;
            }
        }
    }

    void handleWeaponSwitch()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentWeapon = currentWeapon.Next();
        }
    }
    
    void Update()
    {
        handleWASD();
        handleFiring();
        handleWeaponSwitch();
    }
}
