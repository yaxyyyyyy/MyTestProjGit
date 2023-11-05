using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponPlayer : MonoBehaviour
{
    [SerializeField] Sprite[] _weaponSprite;
    [SerializeField] Image _weaponImage;
    public void SetImage(int numberSprite)
    {
        _weaponImage.sprite = _weaponSprite[numberSprite];
    }
}
