using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitFallRespawn : MonoBehaviour
{

    public GameObject player;
    public GameObject spawnPoint;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "trap1")
        {
           player.transform.position = spawnPoint.transform.position;
        }
        
        else if (collision.gameObject.name == "trap2")
        {
            player.transform.position = spawnPoint2.transform.position;
        }
        else if (collision.gameObject.name == "trap3")
        {
            player.transform.position = spawnPoint3.transform.position;
        }
    }
    
}
