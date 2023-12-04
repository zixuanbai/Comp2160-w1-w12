using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Singleton
    static private GameManager instance;
    static public GameManager Instance 
    {
        get 
        {
            if (instance == null)
            {
                Debug.LogError("There is no GameManager instance in the scene.");
            }
            return instance;
        }
    }
    private int score = 0;
    public int Score 
    {
        get
        {
            return score;
        }
    }
    [SerializeField] private int scorePerMissile = 10;
    [SerializeField] private int scorePerRadar = 50;
    [SerializeField] private int scorePerPower = 500;

    [SerializeField] private int numLives = 3;
    [SerializeField] private float delayAfterDeath = 2; 
    
    private int livesRemaining;
    public int LivesRemaining
    {
        get
        {
            return livesRemaining;
        }
    }

    [SerializeField] private Transform startingPosition;
    private Transform lastCheckpoint;

    private LogFile log;

    private PlayerMove player;
    private Backdrop backdrop;


    void Awake()
    {
        if (instance != null) 
        {
            // destroy duplicates
            Destroy(gameObject);            
        }
        else 
        {
            instance = this;
        }        
    }

    void Start()
    {
        score = 0;
        livesRemaining = numLives;
        lastCheckpoint = startingPosition;

        // find the player and backdrop
        player = FindObjectOfType<PlayerMove>();
        backdrop = FindObjectOfType<Backdrop>();

        // find the logfile script
        log = gameObject.GetComponent<LogFile>();
    }

    void Update()
    {
        if (log != null) 
        {
			// write the time and the players x and y positions to the file
			log.WriteLine(Time.time,
                 player.transform.position.x,
                 player.transform.position.y);
		}
    }

    public void ScoreMissile()
    {
        score += scorePerMissile;
    }

    public void ScoreRadar()
    {
        score += scorePerRadar;
    }

    public void ScorePower()
    {
        score += scorePerPower;
        GameOver(true); // WIN
    }

    public void Die()
    {
        StartCoroutine(DieTimer());
    }

    private IEnumerator DieTimer()
    {
        livesRemaining--;
        yield return new WaitForSeconds(delayAfterDeath);

        if (livesRemaining == 0)
        {
            GameOver(false);    // LOSE
        }
        else 
        {
            backdrop.RewindTo(lastCheckpoint.position.x);
            player.transform.position = lastCheckpoint.position;
            player.Revive();
        }

    }

    public void Checkpoint(Transform checkpoint)
    {
        lastCheckpoint = checkpoint;
    }

    public void GameOver(bool win)
    {
        backdrop.Speed = 0;
        UIManager.Instance.ShowGameOver(win);
    }

}
