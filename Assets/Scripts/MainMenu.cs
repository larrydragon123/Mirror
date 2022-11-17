using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int nextLevelIndex;
    public IntVariable treatmentIndex;

    private void Start()
    {
        if (nextLevelIndex == 1)
        {
            treatmentIndex.Value = 0;
        }
        else
        {
            treatmentIndex.Value = 1;
        }
    }
    public void PlayGame()
    {
        //load the next scene
        SceneManager.LoadScene(nextLevelIndex);
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
