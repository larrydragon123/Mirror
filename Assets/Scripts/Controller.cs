using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isReal = false;

    public GameManager GameManagerScript;
    
    void Start()
    {
        //find GameManagerScript
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    public void Die()
    {
        if (GameManagerScript.clones.Count > 0)
        {
            GameManagerScript.passController();
            
            Destroy(this.gameObject);
            GameManagerScript.clones.Remove(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Die();
        }
    }

    void Update()
    {

    }
}
