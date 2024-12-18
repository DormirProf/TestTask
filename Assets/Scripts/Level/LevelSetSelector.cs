using ScriptableObjects.Scripts;
using UnityEngine;

namespace Scripts.Level
{
    public class LevelSetSelector : MonoBehaviour
    {
        public SetData GetRandomSet(SetData[] setsData)
        {
            var randomSet = setsData[Random.Range(0, setsData.Length)];
            return randomSet;
        }
    }
}