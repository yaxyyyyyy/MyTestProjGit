using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIEnemyHealth : MonoBehaviour
{
    [SerializeField] private TMP_Text _textPrintCurrentHP;
    [SerializeField] private Slider _helthSlider;
    [SerializeField] private HealthEnemy _healthEnemy;
    public Transform cam;
    void Start()
    {
        cam = Camera.main.transform;

        _helthSlider.maxValue = _healthEnemy.MaxHealth;
        _helthSlider.value = _healthEnemy.CurrentHealth;
        _textPrintCurrentHP.text = _healthEnemy.CurrentHealth.ToString();
        _healthEnemy.Ev_changeHP.AddListener(ChangeHP);
    }

    private void ChangeHP(int newCurrentHP)
    {

        _helthSlider.maxValue = _healthEnemy.MaxHealth;
        _helthSlider.value = newCurrentHP;
        _textPrintCurrentHP.text = newCurrentHP.ToString();
    }


    private void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
