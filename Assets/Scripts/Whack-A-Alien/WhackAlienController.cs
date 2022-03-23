using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhackAlienController : MonoBehaviour
{
    [SerializeField] private float spawnBuffer = 3;
    public GameObject[] alienSpawners;
    private float _timeout;
    private bool _isGameStarted;
    private int _currentScore;
    private float _timeLeft;
    private ArcadeController arcadeController;

    public void StartWhackAlienGame()
    {
        arcadeController = GameObject.Find("Arcade").GetComponent<ArcadeController>();
        if (!arcadeController.IsGameActive())
        {
            arcadeController.ActivateGame();
            spawnBuffer = 2;
            Debug.Log("Whack A Alien activated");
            _isGameStarted = true;
            _currentScore = 0;
            _timeLeft = 60.0f;
            _timeout = spawnBuffer;
            GameObject.Find("AlienScore").GetComponent<TextMeshPro>().text = _currentScore.ToString();
            //GetComponent<AudioSource>().Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _isGameStarted = false;
        GameObject.Find("AlienScore").GetComponent<TextMeshPro>().text += " " + PlayerPrefs.GetInt("WhackAlienGame_Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if(_isGameStarted)
        {
            // count down before game ends
            _timeLeft -= Time.deltaTime;
            GameObject.Find("AlienTimer").GetComponent<TextMeshPro>().text = ((int)_timeLeft).ToString();
            if (_timeLeft <= 0)
                GameOver();

            //wait for the timeout before popping another alien out
            if (_timeout > 0)
            {
                _timeout -= Time.deltaTime;
            }
            else
            {
                alienSpawners[Random.Range(0, alienSpawners.Length)].GetComponent<AlienSpawner>().SpawnAlien();
                spawnBuffer = Random.Range(1, 3);
                _timeout = spawnBuffer;
            }

        }
    }

    public void UpdateScore()
    {
        _currentScore += 10;
        // update score
        GameObject.Find("AlienScore").GetComponent<TextMeshPro>().text = _currentScore.ToString();
    }

    private void GameOver()
    {
        _isGameStarted = false;
        arcadeController.DeactivateGame();

        // update highscore
        if (_currentScore > PlayerPrefs.GetInt("WhackAlienGame_Highscore"))
        {
            PlayerPrefs.SetInt("WhackAlienGame_Highscore", _currentScore);
        }
    }

    //private void PopUpAndDown(int index)
    //{
    //    currentAlien = alienList[index];
    //    currentAlien.transform.Translate(0, 20.0f * Time.deltaTime, 0);

    //    StartCoroutine(Wait1());

    //    currentAlien.transform.Translate(0, -25.0f * Time.deltaTime, 0);

    //    StartCoroutine(Wait1());
    //}

    //IEnumerator Wait1()
    //{
    //    yield return new WaitForSeconds(1);
    //}
}
