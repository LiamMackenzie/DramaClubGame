using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    
    public GameObject text1;
    public GameObject text2;
    public GameObject Deactivate;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            text1.SetActive(false);
            text2.SetActive(true);
            Deactivate.SetActive(false);
        }

         if(Input.GetKeyDown(KeyCode.Space))
        {
            text1.SetActive(false);
            text2.SetActive(true);
            Deactivate.SetActive(false);
        }
    }
}
