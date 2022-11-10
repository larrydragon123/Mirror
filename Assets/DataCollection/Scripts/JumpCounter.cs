using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCounter : MonoBehaviour
{
    [SerializeField] private IntVariable _jumpCountVariable;

    private void Start()
    {
        _jumpCountVariable.Value = 0;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _jumpCountVariable.Value++;
        }
    }
}
