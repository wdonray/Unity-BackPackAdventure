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
public class LootTable : ScriptableObject
{
    [Serializable]
    public class ItemDrop
    {
        public Item Item;
        [Range(0, 1)] public float Chance;
    }

    [SerializeField] private float RandomRoll;

    public List<ItemDrop> Items;

    public List<Item> GetDrops()
    {
        var drops = new List<Item>();
        RandomRoll = Random.Range(0.0f, 1.0f);
        foreach (var itemdrop in Items)
        {
            if (RandomRoll < itemdrop.Chance)
                drops.Add(itemdrop.Item);
        }
        return drops;
    }

    [CustomEditor(typeof(LootTable))]
    public class InspectorLootTable : Editor
    {
        public int Count = 0;
        public int TestRandom = 0;

        private string _result = "      ^ Press ^";
        private Color testColor;

        public override void OnInspectorGUI()
        {
            TestRandom = Random.Range(1, 4);
            if (GUILayout.Button("Roll That SHIT"))
            {
                Count++;
                _result = "";
                var myTarget = target as LootTable;
                if (myTarget != null)
                {
                    var randDrops = myTarget.GetDrops();
                    if (randDrops == null)
                    {
                        _result = "random drop is null";
                    }
                    else
                    {
                        if (TestRandom == 1)
                            testColor = Color.red;
                        else if (TestRandom == 2)
                            testColor = Color.blue;
                        else
                            testColor = Color.green;
                        _result = "";
                        foreach (var drop in randDrops)
                        {
                            _result += drop.name + ", ";
                        }
                    }
                }
            }
            EditorGUILayout.LabelField("Results->", _result);
            EditorGUILayout.IntField("Count-> ", Count);
            EditorGUILayout.ColorField("Useless Color Test->", testColor,
                GUILayout.ExpandWidth(false));
            base.OnInspectorGUI();
        }
    }
}