using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class JsonHelper
{
    protected JsonHelper() { }


    public static T ReadData<T>(string filePath)
    {
        string jsonRead;
        try
        {
            jsonRead = System.IO.File.ReadAllText(filePath);

            return JsonUtility.FromJson<T>(jsonRead);
        }
        catch (FileNotFoundException)
        {
            return default;
        }
    }

    public static void SaveData(Object saveObject, string filePath)
    {
        string json = JsonUtility.ToJson(saveObject);
        System.IO.File.WriteAllText(filePath, json);
    }
}
