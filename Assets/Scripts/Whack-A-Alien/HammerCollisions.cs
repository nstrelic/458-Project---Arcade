using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerCollisions : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Alien")
        {
            Debug.Log("Collided");
            GameObject.Find("Whack-A-Alien Game").GetComponent<WhackAlienController>().UpdateScore();
            Destroy(collision.collider.gameObject);
        }
    }
}
