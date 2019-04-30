using System.Collections;
using Ghost.Audio;
using Ghost.Stats;
using Ghost.UI;
using Ghost.Utils.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.Props.Interactable
{
    public class LevelPortal : BaseInteractableObject
    {
        [Header("Level portal")]
        public string targetLevel;
        public PortalDirection portalDirection = PortalDirection.Right;
        public int cost = 10;

        public bool isChangingLevel;

        PlayerStats playerStats;
        LevelTransitionFader fader;
        AudioPlayer audioPlayer;

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();
            fader = FindObjectOfType<LevelTransitionFader>();
            audioPlayer = FindObjectOfType<AudioPlayer>();

            isChangingLevel = false;
        }

        public override void Interact()
        {
            if (!isChangingLevel && playerStats.money >= cost)
            {
                playerStats.money -= cost;
                
                audioPlayer.PlaySound(audioPlayer.door);
                
                Debug.Log($"Changing level: from {gameObject.scene.name} to {targetLevel}.");
                StartCoroutine(DoChangeLevel());    
            }
        }

        IEnumerator DoChangeLevel()
        {
            fader.Show();
            isChangingLevel = true;
            yield return new WaitForEndOfFrame();
            yield return SceneManager.LoadSceneAsync(targetLevel, LoadSceneMode.Additive);
            yield return new WaitForSeconds(0.2f);
            fader.Hide();
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}