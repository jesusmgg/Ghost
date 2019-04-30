using Ghost.Audio;
using Ghost.Publishing.Kongregate;
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
        KongregateApiManager kongregateApiManager;

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();
            audioPlayer = FindObjectOfType<AudioPlayer>();
            kongregateApiManager = FindObjectOfType<KongregateApiManager>();

            isDead = false;
        }

        public override void Interact()
        {
            if (!isDead && currentInteractionTime >= requiredTime)
            {
                isDead = true;
                playerStats.money += value;
                particles.Play();
                
                kongregateApiManager.SubmitStats("LifeStolen", playerStats.money);
                
                audioPlayer.PlaySound(audioPlayer.tomb);
            }
        }
    }
}