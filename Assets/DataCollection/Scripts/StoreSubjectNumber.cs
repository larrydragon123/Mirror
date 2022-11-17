using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoreSubjectNumber : MonoBehaviour
{
    public TMP_InputField inputField;
    public LogDataUpdater ldu;

    public void Store()
    {
        if (inputField.text != "")
        {
            ldu.SubjectNumber = int.Parse(inputField.text);
        }
    }
}
