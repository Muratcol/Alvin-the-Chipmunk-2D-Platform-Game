﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    [SerializeField] private float enemyMoveSpeed = 5f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }


    void movement()
    {
        float hDirection = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(0, 1f, 0f);
        transform.position += movement * Time.deltaTime * enemyMoveSpeed;
    }
}