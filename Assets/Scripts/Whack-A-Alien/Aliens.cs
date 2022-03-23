using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliens : MonoBehaviour
{
    public AudioClip HitSound;
    public GameObject smoke;
    private bool _move;

    // Start is called before the first frame update
    void Start()
    {
        _move = true;
        StartCoroutine(WaitThenDestroy());
        StartCoroutine(WaitFor1());
    }

    // Update is called once per frame
    void Update()
    {
        if(_move)
         transform.Translate(0, 0.75f * Time.deltaTime, 0);
    }

    IEnumerator WaitFor1()
    {
        yield return new WaitForSeconds(0.5f);
        _move = false;
    }

    IEnumerator WaitThenDestroy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}
