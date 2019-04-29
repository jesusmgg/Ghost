using Ghost.Stats;
using UnityEngine;

namespace Ghost.Props.Interactable
{
    public class Tomb : BaseInteractableObject
    {
        [Header("Tomb")]
        public float requiredTime = 3.0f;
        public bool isDead;
        public int value = 5;

        PlayerStats playerStats;

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();

            isDead = false;
        }

        public override void Interact()
        {
            if (!isDead && currentInteractionTime >= requiredTime)
            {
                isDead = true;
                playerStats.money += value;
            }
        }
    }
}