using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public int score = 0;
    public int keys = 0;
    public int totalKeys = 3;
    public float time = 60f;
    public float timeRemaining;

    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text keysText;
    public TMP_Text livesText;
    public bool gameOver;

    public AudioSource music;
    public AudioClip dangerMusic;
    public bool dangerTime = false;

    public int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        
        timeRemaining = time;
        timerText.text = "" + (int)timeRemaining;
        keysText.text = keys + "/" + totalKeys;
    }

    // Update is called once per frame
    void Update()
    {
        //decrease amount of time based on time from last frame
        timeRemaining -= Time.deltaTime;
        timerText.text = "" + (int)timeRemaining;

        //if statement to play danger music
        if(timeRemaining <= 20f && timeRemaining > 0 && !dangerTime)
        {
            music.clip = dangerMusic;
            music.Play();
            dangerTime = true;
        }
        else if(timeRemaining <= 0f)
        {
            SceneManager.LoadScene(4);
        }
    }

    //method used to count coins collected
    public void AddScore(int s)
    {
        score += s;
        Debug.Log(score);
        scoreText.text = "" + score;
    }

    //counts keys up and updates on hud
    public void GetKey()
    {
            keys++;
            keysText.text = keys + "/" + totalKeys;
       
    }

    public void LoseLife()
    {
        lives--;
        //updates amount of lives on hud
        livesText.text = "" + lives;

        if(lives <= 0)
        {
            SceneManager.LoadScene(4);
        }
    }


}
