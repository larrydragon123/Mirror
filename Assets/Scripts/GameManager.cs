using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> clones = new List<GameObject>();

    public Transform spawnPosition;

    public GameObject realPlayer;

    public GameObject clonePrefab;

    public void ClonePlayer(Vector3 mirrorPos)
    {
        
        if (clones.Count < 2)
        {
            Vector3 newPos =
                new Vector3(mirrorPos.x -
                    clones[0].transform.position.x +
                    mirrorPos.x,
                    clones[0].transform.position.y,
                    clones[0].transform.position.z);
            //clone the player
            Debug.Log("Cloning");
            GameObject newClone =
                Instantiate(clonePrefab, newPos, Quaternion.identity);
            clones.Add (newClone);
        }
    }

    public void passController()
    {
        // for each clone isreal true
        foreach (GameObject clone in clones)
        {
            clone.GetComponent<Controller>().isReal = true;
            
        }
        // CloneScript.clones[0].GetComponent<Controller>().isReal = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        realPlayer =
            Instantiate(clonePrefab,
            spawnPosition.position,
            Quaternion.identity);
        clones.Add (realPlayer);
        passController();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
