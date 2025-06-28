using UnityEngine;

namespace RPG.Core
{
    public class FollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;

        // Update is called once per frame
        void LateUpdate()
        {
            // Camera.main.transform.position += target.position;

            transform.position = target.position;
        }
    }
}
