using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] 
public class Propeller : MonoBehaviour
{
    [SerializeField] private float force;
    
    private Rigidbody _rigidbody;
    private bool _start;

    #region MonoBehaviour
    private void OnValidate()
    {
        if (force < 0)
            force = 0;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if(_start)
            _rigidbody.AddRelativeForce(Vector3.up * force, ForceMode.Force);
    }

    #endregion

    public bool IsStart()
    {
        return _start;
    }
    
    public void Start()
    {
        _start = true;
        Debug.Log(gameObject.name + "is start fly");
    }

    public void Stop()
    {
        _start = false;
        Debug.Log(gameObject.name + "is stop fly");
    }
}
