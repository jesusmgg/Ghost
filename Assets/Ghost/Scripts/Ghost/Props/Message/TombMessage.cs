using Ghost.Props.Interactable;
using UnityEngine;

namespace Ghost.Props.Message
{
    public class TombMessage : Message
    {
        public Tomb tomb;
        
        Collider2D collider2D;

        void Start()
        {
            collider2D = GetComponent<Collider2D>();
        }
        
        void Update()
        {
            collider2D.enabled = !tomb.isDead;
            message = $"(Z) to steal (Life){tomb.value}.";
        }
    }
}