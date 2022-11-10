using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeKillCountResetter : MonoBehaviour
{
    [SerializeField] private IntVariable[] _spikeKillCountsToReset;

    private void Start()
    {
        foreach (IntVariable killCount in _spikeKillCountsToReset)
        {
            killCount.Value = 0;
        }
    }
}
