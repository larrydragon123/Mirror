using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public GameManager GameManagerScript;

    public GameObject clone;

    public GameObject interactText;

    public Vector3 newPos;

    public GameObject Player;

    private bool inside = false;

    //When player enter, throw a text
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player = other.gameObject;
            inside = true;
            interactText.SetActive(true);
        }
    }

    //when player leave, remove the text
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            inside = false;
            interactText.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //press F to clone the player
        if (Input.GetKeyDown(KeyCode.F) && inside == true)
        {            
            GameManagerScript.ClonePlayer(this.transform.position);
            
        }
    }
}
