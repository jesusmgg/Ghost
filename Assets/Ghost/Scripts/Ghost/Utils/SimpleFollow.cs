using UnityEngine;

namespace Ghost.Utils
{
    public class SimpleFollow : MonoBehaviour
    {
        public Transform target;

        void Update()
        {
            transform.position = target.position;
        }
    }
}