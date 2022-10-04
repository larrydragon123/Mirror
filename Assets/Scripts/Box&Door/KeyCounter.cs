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

    // remove key
    public static void removeKey()
    {
        keyNum--;
    }
    //clear all keys
    public static void clearKeys()
    {
        keyNum = 0;
    }

    public static int getKeyNum()
    {
        
        return keyNum;
    }
}
