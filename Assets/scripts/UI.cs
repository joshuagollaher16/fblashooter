using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private PlayerController player;

    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;
    
    [SerializeField] private Text scoreText;

    [SerializeField] private Image weapon;
    
    [SerializeField] private Sprite yellowSprite;
    [SerializeField] private Sprite greenSprite;
    [SerializeField] private Sprite missileSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        int health = player.health;
        int score = player.score;
        
        heart1.SetActive(health >= 1);
        heart2.SetActive(health >= 2);
        heart3.SetActive(health >= 3);

        scoreText.text = score.ToString();

        Sprite currentWeaponImage = null;
        
        switch (player.currentWeapon)
        {
            case WeaponType.Green:
                currentWeaponImage = greenSprite;
                break;
            case WeaponType.Missile:
                currentWeaponImage = missileSprite;
                break;
            case WeaponType.Yellow:
                currentWeaponImage = yellowSprite;
                break;
            default:
                Debug.LogError("Unknown weapon");
                break;
        }

        weapon.sprite = currentWeaponImage;

    }
}
