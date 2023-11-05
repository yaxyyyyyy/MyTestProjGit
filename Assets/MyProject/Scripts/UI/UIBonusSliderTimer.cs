using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBonusSliderTimer : MonoBehaviour
{

    [SerializeField] private Slider _slider;
    public void PrintBonusTime(float time)
    {
        _slider.maxValue = time;
        _slider.value = time;
        _slider.gameObject.SetActive(true);
    }
    private void Update()
    {
        _slider.value -= Time.deltaTime;
    }
    public void SleepBonusTime()
    {
        _slider.gameObject.SetActive(false);
    }
}
