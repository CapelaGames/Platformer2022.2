using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class BinarySave 
{
    public static void SaveData(SaveData data)
    {
        //formatter converts our data to a format we can save
        BinaryFormatter formatter = new BinaryFormatter();
        //Save file location
        string path = Application.dataPath + "platformerSave.SAV";
        //FileStream is the actual file we are saving to
        //creating the file we want to save to
        FileStream stream = new FileStream(path, FileMode.Create);
        
        //Doing the save
        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    public static SaveData LoadData()
    {
        string path = Application.dataPath + "platformerSave.SAV";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            SaveData data = (SaveData) formatter.Deserialize(stream);
            
            return data;
        }

        return null;
    }
}
