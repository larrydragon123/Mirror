using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlagScript : MonoBehaviour
{
    [SerializeField] private AudioSource flagSoundEffect;
    [SerializeField] private AudioSource victorySoundEffect;

    //if player reach the flag, move to next scene
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //move to next scene
            flagSoundEffect.Play();
            VictoryWait();
        }
    }

    public void VictoryWait()
    {
        StartCoroutine(VictorySound());
    }
    
    IEnumerator VictorySound()
    {
        victorySoundEffect.Play();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
