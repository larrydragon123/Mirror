using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyUI : MonoBehaviour
{
    public GameObject keyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the key text in tmp

        
        keyText.GetComponent<TextMeshProUGUI>().text = "X " + KeyCounter.getKeyNum().ToString();
    }
}
