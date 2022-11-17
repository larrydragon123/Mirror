using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int nextLevelIndex;
    public IntVariable treatmentIndex;
    public void PlayGame()
    {
        //load the next scene
        SceneManager.LoadScene(nextLevelIndex);
        if (nextLevelIndex == 1)
        {
            treatmentIndex.Value = 0;
        }
        else
        {
            treatmentIndex.Value = 1;
        }
    }

    void Update() {
        // press ESC to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
