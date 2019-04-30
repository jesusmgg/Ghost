using System.Collections;
using Ghost.Audio;
using Ghost.Stats;
using Ghost.UI;
using Ghost.Utils.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.Props.Interactable
{
    public class ExitPortal : BaseInteractableObject
    {
        [Header("Exit portal")]
        public int cost = 100;

        PlayerStats playerStats;
        GameEnd gameEnd;
        AudioPlayer audioPlayer;

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();
            gameEnd = FindObjectOfType<GameEnd>();
            audioPlayer = FindObjectOfType<AudioPlayer>();
        }

        public override void Interact()
        {
            if (playerStats.money >= cost)
            {
                playerStats.money -= cost;
                gameEnd.Show();
                
                audioPlayer.PlaySound(audioPlayer.door);
                
                Debug.Log($"Game end reached!");
            }
        }
    }
}