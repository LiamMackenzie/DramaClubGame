using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public GameObject NowLoading;
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
        if (collision.gameObject.tag == "Loader")
        {
            NowLoading.SetActive(true);
            SceneManager.LoadScene("NewStageDesignLevelJason");
        }
        
    }

    public void Restart()
    {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
