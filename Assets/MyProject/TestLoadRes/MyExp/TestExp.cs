using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class TestExp
{
    public string strValue; 
    public static TestExp CheckJSON(string path)
    {
        Debug.Log("search " + path);
        TestExp item = new TestExp();
        if (File.Exists(path))
        {
            try
            {
                Debug.Log("JSON leave");
                item = JsonUtility.FromJson<TestExp>(File.ReadAllText(path));
            }
            catch (Exception e)
            {
                Debug.LogError("ModLoader: Chain error " + e.Message);
            }
        }
        Debug.Log("exit");
        return item;
    }
    public void SaveValueToJSON(string path)
    {
        File.WriteAllText(path, JsonUtility.ToJson(this));
    }
    public TestExp ReadValueFromJSON(string path)
    {

        return JsonUtility.FromJson<TestExp>(File.ReadAllText(path));
    }
}
