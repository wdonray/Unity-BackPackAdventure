using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Item/Equipment/Weapon", order = 1)]
    public abstract class Weapon : Equipment
    {
        void DoDamage()
        {

        }
    }
}