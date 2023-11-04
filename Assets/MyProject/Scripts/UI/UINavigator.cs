using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINavigator : MonoBehaviour
{
    private void Start()
    {
        //Debug.Log("navigator Time.timeScale == 0?" + (Time.timeScale == 0).ToString());
    }
    public void GetLoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
