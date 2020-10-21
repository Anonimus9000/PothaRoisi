using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    [SerializeField] private Transform _objectForTrecking;

    private Transform _transformGO;

    private void Start()
    {
        _transformGO = gameObject.transform;
    }

    private void Update()
    {
        Track();
    }

    private void Track()
    {
        _transformGO.position = _objectForTrecking.position;
    }
}
