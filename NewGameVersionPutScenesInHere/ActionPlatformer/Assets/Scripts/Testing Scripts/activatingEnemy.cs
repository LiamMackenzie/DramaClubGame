using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activatingEnemy : MonoBehaviour
{
    public int enemySelect = 0;
    public List<GameObject> EnemyList = new List<GameObject>();
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
        if(other.gameObject.tag == "Player")
        {
           EnemyList[enemySelect].SetActive(true);
           EnemyList[enemySelect +1].SetActive(true);
           EnemyList[enemySelect +2].SetActive(true);
           EnemyList[enemySelect +3].SetActive(true);
           EnemyList[enemySelect +4].SetActive(true);
           EnemyList[enemySelect +5].SetActive(true);
           EnemyList[enemySelect +6].SetActive(true);
           EnemyList[enemySelect +7].SetActive(true);
           EnemyList[enemySelect +8].SetActive(true);
           EnemyList[enemySelect +9].SetActive(true);
           EnemyList[enemySelect +10].SetActive(true);

        }
    }
}
