using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData
{
    public int totalGold;
    public int totalDiamond;
}
public static class SaveManger
{
    private static string path = Application.persistentDataPath + "/save.json";

    public static void SaveDataGame(int gold,int diamond)
    {
        GameData data = new GameData { totalGold = gold,
            totalDiamond = diamond
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
    }

    public static GameData LoadGold()
    {
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            GameData data = JsonUtility.FromJson<GameData>(json);
            return data;
        }
        return new GameData();
    }
}



