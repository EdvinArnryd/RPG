using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject 
    {
        [SerializeField] ProgressionCharacterClass[] playerClasses = null;

        [System.Serializable]
        class ProgressionCharacterClass
        {
            [SerializeField] characterClass characterClass;
            [SerializeField] float[] health;
        }
    }
}
