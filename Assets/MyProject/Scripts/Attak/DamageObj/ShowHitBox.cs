using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHitBox : MonoBehaviour, IShowHitBox
{
    [SerializeField] private DamageHitBox _hitBox;
    [SerializeField] private float _currentTime;
    [SerializeField] private float _cdBeforeShow;
    [SerializeField] private float _cdShow;
    [SerializeField] private float _cdAfterShow;
    private Vector3 _localPositionBoxDefault;
    private bool _isShow = false;
    private void Start()
    {
        _localPositionBoxDefault = _hitBox.transform.localPosition;
        HideBox();
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && !_isShow)                                 { _isShow = true; Debug.Log(_currentTime + " GetMouseButtonDown"); }
        if (_isShow)                                                                { _currentTime += Time.deltaTime; Debug.Log(_currentTime + " _isShow == true"); }
        if (!_hitBox.gameObject.activeSelf && _currentTime > _cdBeforeShow)         { ShowBox(); Debug.Log(_currentTime); Debug.Log(_currentTime + " ShowBox"); }
        if (_currentTime > _cdShow && _hitBox.gameObject.activeSelf)                { HideBox(); Debug.Log(_currentTime); Debug.Log(_currentTime + " HideBox"); }
        if (_currentTime > _cdAfterShow && _isShow)                                 { _isShow = false; _currentTime = 0; Debug.Log(_currentTime + " _isShow = false"); }

    }

    public virtual void ShowBox()
    {
        _hitBox.gameObject.SetActive(true);
    }
    public virtual void HideBox()
    {
        _hitBox.gameObject.SetActive(false);
    }

}

public interface IShowHitBox
{
    public void ShowBox();
    public void HideBox();
}

