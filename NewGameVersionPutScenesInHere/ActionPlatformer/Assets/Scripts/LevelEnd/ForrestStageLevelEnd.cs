using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ForrestStageLevelEnd : MonoBehaviour
{

    public GameObject Gift;
    public GameObject GiftText;
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
        //if (collision.gameObject.tag == "Loader")
        //{
            //SceneManager.LoadScene("BossGrrJasonTesting");
       // }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Gift")
        {

            Gift.SetActive(true);
            GiftText.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
