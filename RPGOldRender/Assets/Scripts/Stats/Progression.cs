using System;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Stats
{
    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]
    public class Progression : ScriptableObject 
    {
        [SerializeField] ProgressionCharacterClass[] characterClasses = null;

        Dictionary<characterClass, Dictionary<Stat, float[]>> lookupTable = null;

        public float GetStat(Stat stat, characterClass characterClass, int level)
        {
            BuildLookup();

            float[] levels = lookupTable[characterClass][stat];

            if(levels.Length < level)
            {
                return 0;
            }

            return levels[level - 1];
        }

        private void BuildLookup()
        {
            if(lookupTable != null) return;

            lookupTable = new Dictionary<characterClass, Dictionary<Stat, float[]>>();

            foreach (ProgressionCharacterClass progressionClass in characterClasses)
            {
                var statLookupTable = new Dictionary<Stat, float[]>();

                foreach (ProgressionStat progressionStat in progressionClass.stats)
                {
                    statLookupTable[progressionStat.stat] = progressionStat.levels;
                }

                lookupTable[progressionClass.characterClass] = statLookupTable;
            }
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
