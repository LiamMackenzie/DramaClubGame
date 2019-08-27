using UnityEngine;

public class GameHandler : MonoBehaviour{

    public Transform pfHealthBar; //pf = prefab

    private void Start () {

        HealthSystem healthSystem = new HealthSystem(100);


        Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, 10), Quaternion.identity);
        HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
        healthBar.Setup(healthSystem);
    }



}