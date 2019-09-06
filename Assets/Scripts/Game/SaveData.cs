using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveData {
    
    public static void Save(Score score)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/frogGame.frog";
        FileStream stream = new FileStream(path, FileMode.Create);
        stream.Position = 0;
        Data data = new Data(score);
        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static Data Load()
    {
        string path = Application.persistentDataPath + "/frogGame.frog";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            Data data = (Data)formatter.Deserialize(stream);
            stream.Position = 0;
            stream.Close();
            return data;
        } else
        {
            Debug.Log("Save file not found in " + path);
            return null;
        }
    }
}
