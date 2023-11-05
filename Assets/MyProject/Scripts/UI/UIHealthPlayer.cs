using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealthPlayer : MonoBehaviour
{
    [SerializeField] private HealthPlayer _healthPlayer;
    [SerializeField] private TMP_Text _textPrintCurrentHP;
    [SerializeField] private TMP_Text _textPrintMaxHP;
    [SerializeField] private Slider _sliderHP;

    private void Start()
    {
        _sliderHP.maxValue = _healthPlayer.MaxHealth;
        _textPrintMaxHP.text = "/  " + _healthPlayer.MaxHealth.ToString();
        _sliderHP.value = _healthPlayer.CurrentHealth;
        _textPrintCurrentHP.text = _healthPlayer.CurrentHealth.ToString();
        _healthPlayer.Ev_changeHP.AddListener(ChangeHP);
    }

    private void ChangeHP(int newCurrentHP)
    {

        _sliderHP.maxValue = _healthPlayer.MaxHealth;
        _sliderHP.value = newCurrentHP;
        _textPrintMaxHP.text = "/  " + _healthPlayer.MaxHealth.ToString();
        _textPrintCurrentHP.text = newCurrentHP.ToString();
    }
}
