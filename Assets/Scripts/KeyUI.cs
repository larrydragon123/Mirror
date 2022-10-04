using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyUI : MonoBehaviour
{
    public GameObject keyText;
    Animator keyAnim;

    // Start is called before the first frame update
    void Start()
    {
        keyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //update the key text in tmp
        keyText.GetComponent<TextMeshProUGUI>().text = "X " + KeyCounter.getKeyNum().ToString();
    }

    public void playKeyAnim()
    {
        Wait();
    }

    private void Wait()
    {
        StartCoroutine(keyUIAnim());
    }
    
    IEnumerator keyUIAnim()
    {
        keyAnim.SetBool("getKey",true);
        yield return new WaitForSeconds(1f);
        keyAnim.SetBool("getKey",false);
    }
}
