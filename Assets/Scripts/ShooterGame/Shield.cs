using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<GameAsteroid>() != null)
        {
            other.gameObject.GetComponent<GameAsteroid>().ExplodeOnShield();
            GameObject.Find("ShooterGame").GetComponent<ShooterGameController>().updateScore(-other.gameObject.GetComponent<GameAsteroid>().GetPoints());
            Destroy(other.gameObject);
            this.GetComponent<AudioSource>().Play();
        }
    }
}
