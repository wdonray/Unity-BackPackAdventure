using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Item", menuName = "Item",order =3)]
    public class Item : ScriptableObject
    {
        public string Name;
        public int Identification;
    }
}