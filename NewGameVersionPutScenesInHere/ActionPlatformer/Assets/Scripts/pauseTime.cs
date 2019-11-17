using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseTime : MonoBehaviour
{

    public GameObject Dialogue;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
      if(Input.GetKeyUp(KeyCode.Space))
      {
          Time.timeScale = 1f;
    
          Dialogue.SetActive(false);
      }
    }
}
