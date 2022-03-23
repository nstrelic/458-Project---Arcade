using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingGameController : MonoBehaviour
{
    private ArcadeController arcadeController;

    // users current score
    private int _currentScore;
    // users current ball (2 balls per frame)
    private int _currentBall;
    // users current frame (10 frames per game)
    private int _currentFrame;

    private const int _MAXSCORE = 300;
    private const int _MAXFRAMES = 10;

    public void StartBowlingGame()
    {
        arcadeController = GameObject.Find("Arcade").GetComponent<ArcadeController>();
        if (!arcadeController.IsGameActive())
        {
            arcadeController.ActivateGame();
            _currentScore = 0;
            _currentBall = 0;
            _currentFrame = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
