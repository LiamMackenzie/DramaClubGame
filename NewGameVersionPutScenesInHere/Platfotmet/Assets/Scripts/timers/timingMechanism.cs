using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timingMechanism : MonoBehaviour
{

    public float timer;
    public GameObject gameEnd;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      timer += Time.deltaTime;
      text.text = "Time:" + Mathf.Round (timer);
     
    }

}
