using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{

    private float delay;
    private float counter;

    [SerializeField] private float minTime;
    [SerializeField] private float maxTime;

    [SerializeField] private GameObject enemy;
    
    private void Start()
    {
        refreshDelay();
    }

    void refreshDelay()
    {
        delay = Random.Range(minTime, maxTime);
    }

    void spawn()
    {
        var go = Instantiate(enemy, transform.position, Quaternion.identity);
    }
    
    void Update()
    {
        counter += Time.deltaTime;
        if (counter >= delay)
        {
            counter = 0;
            
            spawn();
            refreshDelay();
        }
    }
}
