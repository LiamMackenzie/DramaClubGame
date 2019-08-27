using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Orbs : MonoBehaviour
{
    public Text text;
    public float scoreNum;
    public float scoreAdd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

      void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Collectable")
        {
        scoreNum += scoreAdd;
        text.text = "Score:" + scoreNum;
       Destroy(other.gameObject);
        }
    }
}
