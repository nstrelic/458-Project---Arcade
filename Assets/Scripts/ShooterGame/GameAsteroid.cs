using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAsteroid : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private int points;
    public float maxHealth = 1f;
    private float currentHealth;
    public AudioClip[] explosionSounds;
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
        transform.Translate(-speed * Time.deltaTime, 0, 0);
    }

    public void ReactToHit(float damage)
    {
        Debug.Log("HIT");
        currentHealth -= damage;

        if (currentHealth <= 0f)
        {
            Explode();

            // destroy object when no health remains
            Die();
        }
    }

    public void Explode()
    {
        // play destroy sound
        AudioSource.PlayClipAtPoint(explosionSounds[0], GameObject.Find("OVRPlayerController").transform.position);

        // destroy explosion/animation
        var expl = Instantiate(explosion, transform.position, transform.rotation);
        expl.gameObject.GetComponent<ParticleSystem>().Play();
    }

    public void ExplodeOnShield()
    {
        // play destroy sound
        AudioSource.PlayClipAtPoint(explosionSounds[1], GameObject.Find("OVRPlayerController").transform.position);

        // destroy explosion/animation
        var expl = Instantiate(explosion, transform.position, transform.rotation);
        expl.gameObject.GetComponent<ParticleSystem>().Play();
    }

    public void Die()
    {
        GameObject.Find("ShooterGame").GetComponent<ShooterGameController>().updateScore(points);
        Destroy(gameObject);
    }

    public int GetPoints()
    {
        return points;
    }
}
