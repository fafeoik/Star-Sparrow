﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDescructor : MonoBehaviour
{ 
    void Start()
    {
        Destroy(gameObject, 3f); 
    }

    
    void Update()
    {
        
    }
}
