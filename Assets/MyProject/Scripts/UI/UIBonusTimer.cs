using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBonusTimer : MonoBehaviour
{
    [SerializeField] private BonusSpeedOnPlayer _bonusOnPlayer;
    [SerializeField] private UIBonusSliderTimer _sliderBonusUI;
    void Start()
    {
        if (!_bonusOnPlayer.isActiveAndEnabled) { _sliderBonusUI.SleepBonusTime(); }
        _bonusOnPlayer.Ev_AddBonusTime.AddListener(AddBonusTime);
    }

    public void AddBonusTime(float timeBonus)
    {
        if(timeBonus > 0)
        {
            _sliderBonusUI.PrintBonusTime(timeBonus);
        }
        else
        {
            _sliderBonusUI.SleepBonusTime();
        }
    }
}
