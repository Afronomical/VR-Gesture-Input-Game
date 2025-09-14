using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{
    static string path = Application.persistentDataPath + "/settings.avtr";
    public static void SaveSettings (Settings settings)
    {
        BinaryFormatter formatter = new BinaryFormatter ();
       
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);

        SettingsData data = new SettingsData(settings); 

        

        formatter.Serialize(stream, data);

        stream.Close();

       
    }

    public static SettingsData LoadSettings()
    {
       if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SettingsData data = formatter.Deserialize(stream) as SettingsData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("SaveFile not found at " + path);
            return null;
        }
    }
}
