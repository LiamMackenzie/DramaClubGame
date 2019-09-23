using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public Rigidbody2D me;
    [HideInInspector]
    public Vector2 myPos;
    public int hp = 10;

    // Start is called before the first frame update
    void Start()
    {
        me = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    public void Update()
    {
        myPos = me.transform.position;
    }
}
