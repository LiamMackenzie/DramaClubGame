using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrbsNew : MonoBehaviour
{
    public Text text;
    public float scoreNum;
    public float scoreAdd;
    public float timer;
    public float scoreAddTime;
    public float resetTimer;

    public AudioSource[] sounds;
    public AudioSource noise1;
    public AudioSource noise2;

    // Start is called before the first frame update
    void Start()
    {
        sounds = GetComponents<AudioSource>();
        noise1 = sounds[0];
        noise2 = sounds[1];
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
         if(timer >= 1)
         {
           scoreNum += scoreAddTime;
        text.text = "Score:" + scoreNum;
        timer = resetTimer;
         }
    }

   void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Collectable")
      {
        scoreNum += scoreAdd;
        text.text = "Score:" + scoreNum;
       Destroy(other.gameObject);
       noise2.Play();
      }
      
    }
}
