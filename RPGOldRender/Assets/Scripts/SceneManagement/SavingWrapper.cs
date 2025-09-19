using System;
using RPG.Saving;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class SavingWrapper : MonoBehaviour
    {
        const string defaultSavFile = "save";

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                Load();
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                Save();
            }
        }

        private void Save()
        {
            GetComponent<SavingSystem>().Save(defaultSavFile);
        }

        private void Load()
        {
            //call to saving system load
            GetComponent<SavingSystem>().Load(defaultSavFile);
        }
    }
}
