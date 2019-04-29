using System.Collections.Generic;
using UnityEngine;

namespace Ghost.Props.Interactable
{
    public class Checkpoint : BaseInteractableObject
    {
        [Header("Checkpoint")]
        public bool isActive;
        public ParticleSystem sparksParticles;

        static List<Checkpoint> checkpoints;

        void OnEnable()
        {
            if (checkpoints == null)
            {
                checkpoints = new List<Checkpoint>();
            }
            
            checkpoints.Add(this);
        }

        void OnDisable()
        {
            checkpoints.Remove(this);
        }

        protected override void Start()
        {
            base.Start();

            isActive = false;
        }

        public override void Interact()
        {
            DisableAllCheckpoints();
            isActive = true;
            sparksParticles.Play();
        }

        static void DisableAllCheckpoints()
        {
            foreach (Checkpoint checkpoint in checkpoints)
            {
                checkpoint.isActive = false;
            }
        }
    }
}