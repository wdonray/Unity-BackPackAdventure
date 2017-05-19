using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;

#endif
[CreateAssetMenu(fileName = "AGameManager", menuName = "Game Manager")]
public class AGameManager : ScriptableObject
{
    [SerializeField]
    private string _thisSceneName;

    public GameObject ItemPrefab;
#if UNITY_EDITOR
    [CustomEditor(typeof(AGameManager))]
    public class InspectorGameManager : Editor
    {
        public GameObject GoItem;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            var scene = target as AGameManager;
            if (Application.isPlaying == true)
            {
                if (GUILayout.Button("Restart Game", GUILayout.ExpandWidth(false)))
                {
                    if (scene != null)
                        SceneManager.LoadScene(scene._thisSceneName);
                }
                EditorGUILayout.LabelField("^Restarts the scene");
            }
            else if (Application.isPlaying == false)
            {
                if (GUILayout.Button("Spawn Item", GUILayout.ExpandWidth(false)))
                {
                    if (scene != null)
                    {
                        GoItem = Instantiate(scene.ItemPrefab,
                            scene.ItemPrefab.transform.position,
                            Quaternion.identity);
                    }
                }
                EditorGUILayout.LabelField("^Spawns one item with a default Item Behavior");
                if (GUILayout.Button("Remove Item", GUILayout.ExpandWidth(false)))
                {
                    if (scene != null)
                    {
                        DestroyImmediate(GoItem);
                    }
                }
                EditorGUILayout.LabelField("^Only removes the last item you spawned");
            }
        }
    }
#endif
}