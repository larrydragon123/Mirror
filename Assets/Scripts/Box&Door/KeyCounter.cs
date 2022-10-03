using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCounter : MonoBehaviour
{
    public static int keyNum = 0;

    // add key
    public static void addKey()
    {
        keyNum++;
    }

    public static int getKeyNum()
    {
        return keyNum;
    }
}
