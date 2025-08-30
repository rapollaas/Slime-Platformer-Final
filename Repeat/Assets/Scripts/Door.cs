using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string targetTag = "Player";

    public LevelManager levelManager;

    public GameObject door;
    public AudioSource audio;

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //on collision with door
    private void OnTriggerEnter(Collider other)
    {
        //if the colliding object is a player and we have all the keys
        if (other.tag == targetTag && levelManager.keys == levelManager.totalKeys) 
        {
            audio.Play();
            //get current level num and add 1 to move to next level
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }



}