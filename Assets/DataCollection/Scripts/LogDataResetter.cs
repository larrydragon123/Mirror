using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogDataResetter : MonoBehaviour
{
    [SerializeField] private IntVariable[] _intVariablesToReset;
    [SerializeField] private FloatVariable[] _floatVariablesToReset;
    [SerializeField] private BoolVariable[] _boolVariablesToReset;

    private void Awake()
    {
        foreach (IntVariable intVariable in _intVariablesToReset)
        {
            intVariable.Value = 0;
        }
        foreach (FloatVariable floatVariable in _floatVariablesToReset)
        {
            floatVariable.Value = 0.0f;
        }
        foreach (BoolVariable boolVariable in _boolVariablesToReset)
        {
            boolVariable.Value = false;
        }
    }
}
