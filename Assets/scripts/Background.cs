using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    [SerializeField] private float scrollSpeed;
    public bool isMaster = true;

    void Start()
    {
        if (isMaster)
        {
            for (int i = 0; i < 250; i++)
            {
                var go = Instantiate(this.gameObject, new Vector3(0, 5 * i, 1), Quaternion.identity);
                go.GetComponent<Background>().isMaster = false;
                go.GetComponent<Background>().scrollSpeed = scrollSpeed;
            }
        }
    }

    private void Update()
    {
        transform.Translate(new Vector2(0, -this.scrollSpeed * Time.deltaTime));
    }
}
