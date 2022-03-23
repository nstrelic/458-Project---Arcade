using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public float maxHealth = 1f;
    private float currentHealth;
    public AudioClip explosionSound;
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        // init current health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReactToHit(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            // play destroy sound
            AudioSource.PlayClipAtPoint(explosionSound, GameObject.Find("OVRPlayerController").transform.position);

            // destroy explosion/animation
            var expl = Instantiate(explosion, transform.position, transform.rotation);
            expl.gameObject.GetComponent<ParticleSystem>().Play();

            // destroy object when no health remains
            Destroy(gameObject);
        }
    }
}
