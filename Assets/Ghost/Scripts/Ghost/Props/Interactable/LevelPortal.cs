using System.Collections;
using Ghost.Stats;
using Ghost.Utils.Enums;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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

        protected override void Start()
        {
            base.Start();

            playerStats = FindObjectOfType<PlayerStats>();

            isChangingLevel = false;
        }

        public override void Interact()
        {
            if (!isChangingLevel && playerStats.money >= cost)
            {
                playerStats.money -= cost;
                
                Debug.Log($"Changing level: from {gameObject.scene.name} to {targetLevel}.");
                StartCoroutine(DoChangeLevel());    
            }
        }

        IEnumerator DoChangeLevel()
        {
            isChangingLevel = true;
            yield return new WaitForEndOfFrame();
            yield return SceneManager.LoadSceneAsync(targetLevel, LoadSceneMode.Additive);
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}