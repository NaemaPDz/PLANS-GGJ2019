﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Video : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ((MovieTexture)GetComponent<Renderer>().material.mainTexture).Play();

    }
    // Update is called once per frame
    void Update()
    {

    }
}