using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreKeeper : MonoBehaviour
{
    int score;
// https://docs.unity3d.com/2021.1/Documentation/ScriptReference/SceneManagement.Scene-buildIndex.html
    Scene scene;

    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }
    
    void Start()
    {

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
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if(score == 1000)
        {
            ResetScore();
            SceneManager.LoadScene("Level_2"); // Change from level 2 to buildIndex + 1
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
