using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    Scene scene;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }
    
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    void Update()
    {
        Progress();
    }

    void ManageSingleton()
    {
        if(instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void Progress()
    {
        if(score == 1000)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            ResetScore();
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
}
