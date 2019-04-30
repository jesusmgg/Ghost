using Ghost.Props.Interactable;
using UnityEngine;

namespace Ghost.Props.Message
{
    public class CheckpointMessage : Message
    {
        public Checkpoint checkpoint;

        Collider2D collider2D;

        void Start()
        {
            collider2D = GetComponent<Collider2D>();
        }

        void Update()
        {
            collider2D.enabled = !checkpoint.isActive;
            message = $"(Z) to save checkpoint.";
        }
    }
}