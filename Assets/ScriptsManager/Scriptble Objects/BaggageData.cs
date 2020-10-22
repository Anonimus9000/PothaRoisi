using UnityEngine;

[CreateAssetMenu(fileName = "New BaggageData", menuName = "Baggage Data", order = 51)]
public class BaggageData : ScriptableObject
{
    [SerializeField] private float _weight;
    [SerializeField] private float _point;

    private void OnValidate()
    {
        if (_weight < 0)
            _weight = 0;
        if (_point < 0)
            _point = 0;
    }

    public float GetPoint()
    {
        if (_point > 0)
            return _point;
        else
            return 0;
    }
    
    public float GetWeight()
    {
        if (_weight > 0)
            return _weight;
        else
            return 0;
    }
}
