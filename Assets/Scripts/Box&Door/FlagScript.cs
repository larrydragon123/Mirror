using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagScript : MonoBehaviour
{
    //if player reach the flag, move to next scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //move to next scene
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
