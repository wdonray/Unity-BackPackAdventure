using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "BackPackConfig", menuName = "Item/Equipment/BackPackConfig", order = 1)]
    public class BackPackConfig : ScriptableObject
    {
        public List<Item> InitInventory = new List<Item>();
        public int Capacity = 25;
        public List<Item> Items { get { return InitInventory; } }
    }
}
