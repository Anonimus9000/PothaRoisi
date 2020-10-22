using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggegeController : MonoBehaviour
{
    [SerializeField] private DronController _dron;
    [SerializeField] private BaggageData _baggageData;
    private float _weight;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_dron == null)
            _dron = FindObjectOfType<DronController>();
    }

    void Start()
    {
        _weight = _baggageData.GetPoint();
    }

    void Update()
    {
        
    }

    #endregion
}
