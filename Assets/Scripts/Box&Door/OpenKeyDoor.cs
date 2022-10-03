using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKeyDoor : MonoBehaviour
{
    [SerializeField] private int doorNum;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The key amount = " + KeyCounter.getKeyNum());
            if (KeyCounter.getKeyNum() >= doorNum)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
