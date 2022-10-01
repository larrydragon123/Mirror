using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public bool isReal = false;

    public CloneManager CloneManagerScript;
    public Clone CloneScript;
    void Start()
    {
        CloneManagerScript =
            GameObject.Find("CloneController").GetComponent<CloneManager>();
    }

    public void Die()
    {
        if (CloneManagerScript.CloneScript.clones.Count > 0)
        {
            CloneManagerScript.passController();
            
            Destroy(this.gameObject);
            CloneManagerScript.CloneScript.clones.Remove(this.gameObject);
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
