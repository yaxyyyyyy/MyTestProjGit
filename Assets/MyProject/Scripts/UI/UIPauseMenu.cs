using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    [SerializeField] protected HealthPlayer _healthPlayer;
    [SerializeField] protected GameObject Menu;
    [SerializeField] protected GameObject ButtonContinue;
    [SerializeField] protected bool _isContinue;

    [SerializeField] protected InvokeAttakByInput _player;
    private void Start()
    {
        //Time.timeScale = 1;
        Menu.SetActive(false);
        if(_healthPlayer != null)
        _healthPlayer.Ev_changeHP.AddListener(SetCanContinueButtonPress);
        _isContinue = true;
        if(_player != null)
        _player.SetSleep(false);
    }


    private void SetCanContinueButtonPress(int currentPlayerHP)
    {
        if(currentPlayerHP <= 0)
        {
            //Menu.SetActive(true);
            _isContinue = false;
            ButtonContinue.SetActive(_isContinue);
            OpenPauseMenu();
        }
        else
        {
            _isContinue = true;
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { if (Menu.activeSelf) { ClosePauseMenu(); } else { OpenPauseMenu(); } }
    }
    public void OpenPauseMenu()
    {
        Time.timeScale = 0;
        Menu.SetActive(true);
        ButtonContinue.SetActive(_isContinue);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        if (_player != null)
            _player.SetSleep(true);
    }
    public void ClosePauseMenu()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (_player != null)
            _player.SetSleep(false);
    }

    public void ExitScene()
    {
        Time.timeScale = 1;
        Menu.SetActive(false);
        SceneManager.LoadScene(0);
        //TODO при клике по кнопке игрок бьёт роужием(после выхода из паузы)
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
