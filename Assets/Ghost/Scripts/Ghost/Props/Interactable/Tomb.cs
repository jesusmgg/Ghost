using UnityEngine;

namespace Ghost.Props.Interactable
{
    public class Tomb : BaseInteractableObject
    {
        [Header("Tomb")]
        public float requiredTime = 3.0f;
        public bool isDead;

        protected override void Start()
        {
            base.Start();

            isDead = false;
        }

        public override void Interact()
        {
            if (currentInteractionTime >= requiredTime)
            {
                isDead = true;
            }
        }
    }
}