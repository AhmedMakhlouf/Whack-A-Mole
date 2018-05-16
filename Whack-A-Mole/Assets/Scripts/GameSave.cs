using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]
class GameData
{
    public int[] scores;
}

public class GameSave
{
    public void Save(int[] scores)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerScore.dat");

        GameData playerScore = new GameData();
        playerScore.scores = scores;

        bf.Serialize(file, playerScore);
        file.Close();
    }

    public int[] Load()
    {
        if(File.Exists(Application.persistentDataPath + "/playerScore.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerScore.dat", FileMode.Open);
            GameData playerScore = (GameData)bf.Deserialize(file);
            file.Close();

            return playerScore.scores;
        }

        return new int[5];
    }
}

