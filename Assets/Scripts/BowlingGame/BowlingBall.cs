using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.maxAngularVelocity = Mathf.Infinity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
