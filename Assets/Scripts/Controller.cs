using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isReal = false;
    public GameObject cursor;

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
            GameManagerScript.playDeathSound();
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
        if (isReal)
        {   
            cursor.SetActive(true);
            
        }
        else
        {
            
            cursor.SetActive(false);
            
        }
    }
}
