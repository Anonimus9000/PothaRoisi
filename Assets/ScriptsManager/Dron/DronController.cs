using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DronController : MonoBehaviour
{
    [SerializeField] private List<Propeller> _propellers;
    [SerializeField] private float _maxAngleTurn = 45f;
    [SerializeField] private float _speedTurn = 10f;

    private Rigidbody _rigidbody;

    private Transform _transformPlayer;

    #region MonoBehaviour

    private void OnValidate()
    {
        if (_maxAngleTurn < 0)
            _maxAngleTurn = 0;
        if (_speedTurn < 0)
            _speedTurn = 0;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _transformPlayer = gameObject.transform;
    }

    private void FixedUpdate()
    {
        Movement();
    }
    
    #endregion

    private void Movement()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");
        
        if (Input.GetButton("Jump"))
        {
            foreach (var now in _propellers)
            {
                now.Start();
            }
        }
        else
        {
            foreach (var now in _propellers)
            {
                now.Stop();
            }
        }
        
        Debug.Log("HorizontalAxis = " + horizontalAxis);
        Debug.Log("VerticalAxis = " + verticalAxis);

        var from = Quaternion.Euler(0, 0, 0);
        var to = Quaternion.Euler(_maxAngleTurn * verticalAxis, 0f, _maxAngleTurn * -horizontalAxis);
        
        var turnTime = _speedTurn;
        
        _rigidbody.MoveRotation(Quaternion.Lerp(from, to, turnTime));
        
        // var dir = new Vector3(horizontalAxis, 0, verticalAxis);
        // dir = dir * _speedTurn;
        //
        // _rigidbody.AddRelativeTorque(dir);
    }
}
