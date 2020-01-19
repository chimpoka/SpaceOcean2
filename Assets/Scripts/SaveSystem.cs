using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    static string SavePath = Application.persistentDataPath + "/State.bin";

    public static void SaveState(State state)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(SavePath, FileMode.Create);

        StateData data = new StateData(state);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static State LoadState()
    {
        if (File.Exists(SavePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(SavePath, FileMode.Open);

            StateData data = formatter.Deserialize(stream) as StateData;
            State state = new State(data);
            stream.Close();

            return state;
        }
        else
        {
            MonoBehaviour.print("Save file not found in " + SavePath);
            return new State();
        }
    }
}