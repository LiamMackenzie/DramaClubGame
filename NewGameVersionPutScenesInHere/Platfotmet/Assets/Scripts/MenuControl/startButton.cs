﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startButton : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PressStart;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
             PressStart.SetActive(false);
             MainMenu.SetActive(true);

        }
    }
}
