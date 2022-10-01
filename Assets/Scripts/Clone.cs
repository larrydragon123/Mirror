using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    public List<GameObject> clones = new List<GameObject>();
    public GameObject clone;
    public GameObject Player;
    public GameObject interactText;
    public Transform spawnPosition;
    
    public CloneManager CloneManagerScript;

    public GameObject newClone;

    public Vector3 newPos;
    private bool inside = false;
    private int numberOfClones = 0;

    //When player enter, throw a text
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
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

    public void ClonePlayer(){
        //get the distance between the player
        Player = clones[0];
        newPos = new Vector3(this.transform.position.x - Player.transform.position.x + this.transform.position.x, Player.transform.position.y, Player.transform.position.z);

        if(numberOfClones <1){
            if(inside){
                //clone the player
                Debug.Log("Cloning");
                newClone = Instantiate(clone, newPos, Player.transform.rotation);
                
                clones.Add(newClone);
                numberOfClones++;
            }
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
      Player = Instantiate(clone, spawnPosition.position, Quaternion.identity);
      clones.Add(Player);
      CloneManagerScript.passController();
      
    }

    // Update is called once per frame
    void Update()
    {
        //press F to clone the player
            if (Input.GetKeyDown(KeyCode.F)&&inside==true)
            {
                ClonePlayer();
            }
    }
}
