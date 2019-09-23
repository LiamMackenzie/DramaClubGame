using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    public GameObject wP;
    // Start is called before the first frame update
    private float timer = 0.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            UpdatePos();
            timer = 0.0f;
        }
    }

    void UpdatePos()
    {
        wP.transform.position = transform.position;
    }
}
