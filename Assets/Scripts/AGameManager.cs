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
        [HideInInspector]
        public GameObject Parent =new GameObject();

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
                        
                        GoItem.transform.SetParent(Parent.transform);
                    }
                }
                if (GUILayout.Button("Remove Item", GUILayout.ExpandWidth(false)))
                {
                    if (scene != null)
                    {
                        DestroyImmediate(GoItem);
                    }
                }
            }
        }
    }
#endif
}