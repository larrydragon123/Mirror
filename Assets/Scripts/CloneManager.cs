using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour
{
    //find clones
    public Clone CloneScript;
    
    
    public void passController(){
        // for each clone isreal true
        foreach (GameObject clone in CloneScript.clones)
        {
            clone.GetComponent<Controller>().isReal = true;
        }
        // CloneScript.clones[0].GetComponent<Controller>().isReal = true;
    }
    void Start()
    {
    //    passController();
    }

    // Update is called once per frame
    void Update()
    {
        // passController();
    }
}
