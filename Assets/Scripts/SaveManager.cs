using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    private DataManager dataManager;


    private void Awake()
    {
        instance = this;
        dataManager = FindObjectOfType<DataManager>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        { DeleteData(); }

        if (Input.GetKeyDown(KeyCode.S))
        { SaveData(); }
    }


    public void SaveData()
    {
        FileStream file = new FileStream(Application.persistentDataPath + "/randomizerData.dat", FileMode.OpenOrCreate);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(file, dataManager.songData);
        }
        catch (SerializationException error)
        {
            Debug.LogError("Unable to serialize data: " + error.Message);
        }
        finally { file.Close(); }
    }


    public void LoadData()
    {
        if (!File.Exists(Application.persistentDataPath + "/randomizerData.dat")) return;

        FileStream file = new FileStream(Application.persistentDataPath + "/randomizerData.dat", FileMode.Open);

        try
        {
            BinaryFormatter formatter = new BinaryFormatter();
            dataManager.songData = formatter.Deserialize(file) as List<Song>;
        }
        catch (SerializationException error)
        {
            Debug.LogError("Unable to deserialize data: " + error.Message);
        }
        finally { file.Close(); }
    }



    public void DeleteData()
    {
        if (File.Exists(Application.persistentDataPath + "/randomizerData.dat"))
        { File.Delete(Application.persistentDataPath + "/randomizerData.dat"); }
    }
}
