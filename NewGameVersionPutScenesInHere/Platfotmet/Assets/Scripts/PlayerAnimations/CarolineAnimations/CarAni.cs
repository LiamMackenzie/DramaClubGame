﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAni : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
          animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.J))
        {
            animator.Play ("Base Layer.CarolineAttack");
        }

        if (Input.GetKeyUp(KeyCode.J))
        {
            animator.Play("Base Layer.CarolIdle");
        }
    }
}
