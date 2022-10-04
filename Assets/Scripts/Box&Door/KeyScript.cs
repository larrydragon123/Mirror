using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{

    bool singleton_check = false;
    private GameManager GameManagerScript;

    void Start()
    {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !singleton_check)
        {
            GameManagerScript.playKeySound();
            KeyCounter.addKey();
            singleton_check = true;
            Destroy(this.gameObject);
        }
    }
}
