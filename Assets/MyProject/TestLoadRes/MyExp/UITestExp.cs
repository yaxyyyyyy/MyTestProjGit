using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System;

public class UITestExp : MonoBehaviour
{
    public TMP_Text MyPrintText;
    public int value;
    public TestExp MyExp;
    public string MyPath;
    public string MyPathFile;
    // Start is called before the first frame update
    void Start()
    {
        MyPath = Application.dataPath + $"/../MySaves/";
        MyPathFile = MyPath + "item.save";

        Directory.CreateDirectory(MyPath);


        MyExp = TestExp.CheckJSON(MyPathFile);
    }

    public void AddValue(int i)
    {
        value += i;
        MyPrintText.text = value.ToString();
    }
    public void SaveToJSON()
    {
        MyExp.strValue = "mySave_" + value.ToString();
        MyExp.SaveValueToJSON(MyPathFile);
    }
    public void LoadFromJSON()
    {
        MyExp.ReadValueFromJSON(MyPathFile);
        value = Convert.ToInt32(MyExp.strValue.Split("_")[1]);
    }
}
