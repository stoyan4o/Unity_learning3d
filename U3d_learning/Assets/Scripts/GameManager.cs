using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject playerPrefab;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI ballsText;
    [SerializeField] TextMeshProUGUI levelText;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelGameOver;

    public GameObject _currentBall;
    public GameObject _currentLevel;

    // public List<Component> cachedBricks;

    public GameObject[] Levels; // Array of levels as prefabs

   /* internal void RemoveBrick(GameObject gameObject)
    {
        Component brickToRemove = null;
        
        IEnumerator en = cachedBricks.GetEnumerator();
        while (en.MoveNext())
        {
            if (((Component)en.Current).gameObject.name.Equals(gameObject.name))
            {
                brickToRemove = en.Current as Component;
                break;
            }
        }

        if (brickToRemove != null)
            cachedBricks.Remove(brickToRemove);
    }*/

    public static GameManager Instance { get; private set; }
    public enum State { INIT, 
        MENU,
        PLAY, 
        LEVELCOMPLETED, 
        LOADLEVEL, 
        GAMEOVER,
        PAUSE}
    State _state;

    private int _score = 0;
    public int Score
    {
        get { return _score; }
        set { _score = value;
            scoreText.text = "SCORE: " +_score;
        }
    }

    private int _level;
    public int Level
    {
        get { return _level; }
        set { _level = value;
            levelText.text = "LEVEL: " + _level;
        }
    }

    private int _balls;
    public int Balls
    {
        get { return _balls; }
        set { _balls = value;
            ballsText.text = "BALLS: " + _balls;
        }
    }

    /// <summary>
    /// This method is called when user clicks on Play button
    /// </summary>
    public void PlayClicked()
    {
        SwitchState(State.INIT);
    }

    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }

    public void SwitchState(State newState)
    {
        EndState();
        BeginState(newState);
        _state = newState;
    }

    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                panelMenu.SetActive(true); 
                break;
            case State.INIT:
                panelPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Balls = 3;
                Instantiate(playerPrefab);  // instantiating paddle, not ball yet. Ball will be summoned on Play state
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                if (_currentBall == null)
                {
                    if (_balls > 0)
                    {
                        _currentBall = Instantiate(ballPrefab);
                        
                    }
                    else
                    {
                        SwitchState(State.GAMEOVER);
                    }
                }
                
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(true);
                
                this.Level++;
                SwitchState(State.LOADLEVEL);

                break;
            case State.LOADLEVEL:
                if (_level >= Levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    _currentLevel = Instantiate(Levels[this.Level]);
                    PrecacheBricksInLevel();
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                panelGameOver.SetActive(true);
                break;

        }
    }

    void PrecacheBricksInLevel()
    {
       // cachedBricks = _currentLevel.GetComponentsInChildren(typeof(Component)).ToList();
    }

    void EndState()
    {
        switch (_state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                break;

        }
    }


    // Update is called once per frame
    void Update()
    {
        switch (_state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                break;

        }
    }
}
