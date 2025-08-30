using UnityEngine;

public class Hazard : MonoBehaviour
{
    public string targetTag = "Player";

    public AudioSource audio;
    public GameObject model;
    public Collider collide;

    public LevelManager levelManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == targetTag)
        {
            //calls loselife in LevelManager and will end game if out of lives
            levelManager.LoseLife();

            audio.Play();
            model.SetActive(false);
            GetComponent<Collider>().enabled = false;
        }
    }
}
