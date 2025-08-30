using UnityEngine;
using UnityEngine.SceneManagement;

public class KillVolume : MonoBehaviour
{
    public string targetTag = "Player";

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
        //if the tag of the object we collide with matches the tag we set to collide with then call the pick up method
        if (other.tag == targetTag)
        {
            //if player lands in water, take to end game
            SceneManager.LoadScene(4);
        }
    }
}
