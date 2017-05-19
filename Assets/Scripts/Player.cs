using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Assertions;
[CreateAssetMenu(fileName = "Player Saver", menuName = "Player Saver")]
public class Player : ScriptableObject
{
    public int Health, Mana;

    public void SavePlayer(string filename, Player dude)
    {
        Assert.IsNotNull(dude, "You need a player to save");
        Assert.IsNotNull(filename, "Please enter a file name");
        var json = JsonUtility.ToJson(dude);
        var path = Application.persistentDataPath + string.Format("/{0}.json", filename);
        File.WriteAllText(path, json);
    }

    public Player LoadPlayer(string filename)
    {
        var player = new Player();
        
        var path = Application.persistentDataPath + string.Format("/{0}.json", filename);
        var json = File.ReadAllText(path);
#if UNITY_EDITOR
        var playerAsset = AssetDatabase.FindAssets("t:Player")
            .Select(AssetDatabase.AssetPathToGUID)
            .Select(AssetDatabase.LoadAssetAtPath<Player>)
            .Where(b => b)
            .ToArray();

        player = playerAsset.FirstOrDefault();
#endif
        if (player == null)
            player = Resources.Load("Player") as Player;
        Assert.IsNotNull(player, "Player Should not be null");
        JsonUtility.FromJsonOverwrite(json, player);
        return player;
    }
}
