using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeController : MonoBehaviour
{
    private bool _isGameActive;

    // Start is called before the first frame update
    void Start()
    {
        _isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsGameActive()
    {
        return _isGameActive;
    }

    public void ActivateGame()
    {
        _isGameActive = true;
    }

    public void DeactivateGame()
    {
        _isGameActive = false;
    }
}
