using System;
using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using UnityEngine;
using Random = UnityEngine.Random;
#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "LootTable", menuName = "LootTable")]
public class LootTable : ScriptableObject {
    [Serializable]
    public class ItemDrop
    {
        public Item Item;
        [Range(0, 1)] public float Chance;
    }

    [SerializeField] private float _randomroll;
    public List<ItemDrop> Items;
    public List<Item> GetDrops()
    {
        var drops = new List<Item>();
        _randomroll = Random.Range(0.0f, 1.0f);
        foreach (var itemdrop in Items)
        {
            if (_randomroll < itemdrop.Chance)
                drops.Add(itemdrop.Item);
        }
        return drops;
    }
    [CustomEditor(typeof(LootTable))]
    public class InspectorLootTable : Editor
    {
        string result = "";
        public override void OnInspectorGUI()
        {

            if (GUILayout.Button("Roll That SHIT"))
            {
                result = "";
                var myTarget = target as LootTable;
                if (myTarget != null)
                {
                    var randDrops = myTarget.GetDrops();
                    if (randDrops == null)
                    {
                        result = "random drop is null";
                    }
                    else
                    {
                        result = "";
                        foreach (var drop in randDrops)
                        {
                            result += drop.name + ", ";
                        }
                    }
                }

            }
            EditorGUILayout.TextField("Results", result);
            base.OnInspectorGUI();
        }
    }
}
