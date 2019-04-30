using Ghost.Audio;
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
        public ParticleSystem particles;

        PlayerStats playerStats;
        AudioPlayer audioPlayer;

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();
            audioPlayer = FindObjectOfType<AudioPlayer>();

            isDead = false;
        }

        public override void Interact()
        {
            if (!isDead && currentInteractionTime >= requiredTime)
            {
                isDead = true;
                playerStats.money += value;
                particles.Play();
                
                audioPlayer.PlaySound(audioPlayer.tomb);
            }
        }
    }
}