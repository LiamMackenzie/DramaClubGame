using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomOutTest : MonoBehaviour
{
    public float timer;
    public float speed;
    public float timingNum;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.Translate(Vector3.forward*speed * Time.deltaTime);
        if(timer  >= timingNum)
        {
            speed = 0;
        }

    }
}
