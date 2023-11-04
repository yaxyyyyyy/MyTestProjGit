using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UINavigator : MonoBehaviour
{
    public void GetLoadScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
