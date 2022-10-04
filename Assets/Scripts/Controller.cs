using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isReal = false;
    public GameObject cursor;

    public GameManager GameManagerScript;
    Animator playeranim;


    void Start()
    {
        //find GameManagerScript
        GameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
        playeranim = GetComponent<Animator>();
    }

    public void Die()
    {
        if (GameManagerScript.clones.Count > 0)
        {
            GameManagerScript.passController();
            GameManagerScript.playDeathSound();
            DieWait();
        }
    }

    public void DieWait()
    {
        StartCoroutine(DieAnim());
    }

    IEnumerator DieAnim()
    {
        playeranim.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
        GameManagerScript.clones.Remove(this.gameObject);
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
