﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    public float lifetime = 2.0f;
    public float speed = 5.0f;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
