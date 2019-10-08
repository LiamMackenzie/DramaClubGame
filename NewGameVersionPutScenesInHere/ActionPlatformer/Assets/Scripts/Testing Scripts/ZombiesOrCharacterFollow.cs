using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiesOrCharacterFollow : MonoBehaviour
{
    private GameObject wP;
    private Vector3 wayPointPos;

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        wP = GameObject.Find("AmandaJasonVer");
    }

    // Update is called once per frame
    void Update()
    {
        wayPointPos = new Vector3(wP.transform.position.x,
         transform.position.y, wP.transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, 
        wayPointPos, speed * Time.deltaTime);
    }
}
