using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerEnergy : MonoBehaviour
{
    public TMP_Text _printText;
    public int _currentEnergy = 3;
    public int _maxEnergy = 5;
    public float _cdAddEnergy = 3f;
    public float _currentCdAddEnergy = 0f;

    private void Start()
    {
        PrintEnergy();
    }

    private void Update()
    {
        _currentCdAddEnergy += Time.deltaTime;
        if(_currentCdAddEnergy >= _cdAddEnergy)
        {
            _currentCdAddEnergy = 0;
            _currentEnergy = Mathf.Min(_maxEnergy, _currentEnergy + 1);
            PrintEnergy();
        }
    }
    public bool GetEnergy(int value)
    {
        if(_currentEnergy >= value) { _currentEnergy -= value; PrintEnergy();return true; }
        else { return false; }
    }
    private void PrintEnergy()
    {
        _printText.text = _currentEnergy.ToString() + "/" + _maxEnergy.ToString();
    }
}
