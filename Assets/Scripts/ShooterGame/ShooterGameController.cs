using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShooterGameController : MonoBehaviour
{
    public GameObject[] asteroidSpawners;
    [SerializeField] private float spawnBuffer = 3;
    private float _timeout;
    private bool _isGameStarted;
    private int _currentScore;
    private float _timeLeft;
    private ArcadeController arcadeController;

    public void StartShooterGame()
    {
        arcadeController = GameObject.Find("Arcade").GetComponent<ArcadeController>();
        if (!arcadeController.IsGameActive())
        {
            arcadeController.ActivateGame();
            spawnBuffer = 3;
            Debug.Log("Shooter game activated");
            _isGameStarted = true;
            _currentScore = 0;
            _timeLeft = 60.0f;
            _timeout = spawnBuffer;
            GameObject.Find("Gun").GetComponent<Gun>().upgradeGun(0);
            GetComponent<AudioSource>().Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _isGameStarted = false;
        GameObject.Find("ShooterScore").GetComponent<TextMeshPro>().text = "Highscore: " + PlayerPrefs.GetInt("ShooterGame_Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        // if mini game is in progress
        if (_isGameStarted)
        {
            // count down before game ends
            _timeLeft -= Time.deltaTime;
            GameObject.Find("ShooterTimer").GetComponent<TextMeshPro>().text = ((int)_timeLeft).ToString();
            if (_timeLeft <= 0)
                GameOver();

            // spawn asteroid
            if (_timeout > 0)
            {
                _timeout -= Time.deltaTime;
            }
            else
            {
                asteroidSpawners[Random.Range(0, asteroidSpawners.Length)].GetComponent<AsteroidSpawner>().SpawnAsteroid();
                _timeout = spawnBuffer;
            }

            // increase difficulty
            IncreaseDifficulty();
            // upgrade gun
            UpgradeGun();
        }
    }

    public void updateScore(int scoreChange)
    {
        _currentScore += scoreChange;
        Debug.Log("New score: " + _currentScore);
        // update score
        GameObject.Find("ShooterScore").GetComponent<TextMeshPro>().text = _currentScore.ToString();
    }

    private void GameOver()
    {
        // set game to not running
        _isGameStarted = false;
        arcadeController.DeactivateGame();

        // destroy spawned asteroids
        var gameAsteroids = GameObject.FindGameObjectsWithTag("GameAsteroid");
        foreach (var a in gameAsteroids)
        {
            Destroy(a);
        }

        // stop alarm
        GetComponent<AudioSource>().Stop();

        // update highscore
        if (_currentScore > PlayerPrefs.GetInt("ShooterGame_Highscore"))
        {
            PlayerPrefs.SetInt("ShooterGame_Highscore", _currentScore);
        }
    }

    private void IncreaseDifficulty()
    {
        // 3 difficulties based on score
        if (_currentScore >= 25)
        {
            spawnBuffer = 2f;
        }
        if (_currentScore >= 50)
        {
            spawnBuffer = 1f;
        }
        if (_currentScore >= 100)
        {
            spawnBuffer = 0.5f;
        }
    }

    private void UpgradeGun()
    {
        if (_currentScore >= 30)
        {
            GameObject.Find("Gun").GetComponent<Gun>().upgradeGun(1);
        }
        if (_currentScore >= 70)
        {
            GameObject.Find("Gun").GetComponent<Gun>().upgradeGun(2);
        }
    }
}
