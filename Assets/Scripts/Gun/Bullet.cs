using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // how long the bullet will remain in the scene before being destroy
    public float lifespan = 5f;
    public float damage = 1f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifespan);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // inflict damage on object
        if (collision.gameObject.GetComponent<GameAsteroid>() != null)
        {
            collision.gameObject.GetComponent<GameAsteroid>().ReactToHit(damage);
        }
        else if (collision.gameObject.GetComponent<Destroyable>() != null)
        {
            collision.gameObject.GetComponent<Destroyable>().ReactToHit(damage);
        }
        
        
        // destroy bullet if it hits an object that is not the gun
        if (collision.gameObject.GetComponent<Gun>() == null)
        {
            Destroy(gameObject);
        }
    }
}
