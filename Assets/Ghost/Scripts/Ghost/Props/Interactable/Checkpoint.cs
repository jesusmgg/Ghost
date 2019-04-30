using System.Collections.Generic;
using Ghost.Audio;
using UnityEngine;

namespace Ghost.Props.Interactable
{
    public class Checkpoint : BaseInteractableObject
    {
        [Header("Checkpoint")]
        public bool isActive;
        public ParticleSystem sparksParticles;

        static List<Checkpoint> checkpoints;

        AudioPlayer audioPlayer;

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

            audioPlayer = FindObjectOfType<AudioPlayer>();

            isActive = false;
        }

        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);
            
            if (other.CompareTag("Player"))
            {
                Interact();
            }
        }

        public override void Interact()
        {
            if (!isActive)
            {
                DisableAllCheckpoints();
                isActive = true;
                sparksParticles.Play();
                
                audioPlayer.PlaySound(audioPlayer.save);
            }
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