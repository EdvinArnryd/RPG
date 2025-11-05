using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject 
    {
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        public float GetHealth(characterClass characterClass, int level)
        {
            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                if (progressionClass.characterClass == characterClass)
                {
                    // return progressionClass.health[level - 1];
                }
            }
            return 0;
        }

        [System.Serializable]
        class ProgressionCharacterClass
        {
            [SerializeField] public characterClass characterClass;
            [SerializeField] public ProgressionStat[] stats;
            // [SerializeField]public float[] health;
        }

        [System.Serializable]
        class ProgressionStat
        {
            public Stat stat;
            [SerializeField] public float[] levels;
        }
    }
}
