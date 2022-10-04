using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{
    
    [SerializeField] private int doorNum;
    private GameManager GameManagerScript;
    
    void Start()
    {
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The key amount = " + KeyCounter.getKeyNum());
            if (KeyCounter.getKeyNum() >= 1)
            {
                GameManagerScript.playopenKeyDoorSound();
                KeyCounter.removeKey();
                Destroy(this.gameObject);
            }
        }
    }
}
