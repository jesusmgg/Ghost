using System.Linq;
using Ghost.Input;
using Ghost.Props;
using Ghost.Props.Interactable;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.GameLogic.Player
{
    /// <summary>
    /// Player logic for the Action button (Fire2, Z).
    /// </summary>
    [RequireComponent(typeof(PlayerInput))]
    public class PlayerActions : MonoBehaviour
    {
        public bool canDoActions;
        
        [Header("Object detection")]
        public BaseInteractableObject currentInteractableObject;

        [Header("Checkpoints")]
        public Checkpoint currentCheckpoint;
        
        PlayerInput input;
        PlayerStats stats;

        void Start()
        {
            input = GetComponent<PlayerInput>();
            stats = GetComponent<PlayerStats>();
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            currentCheckpoint = null;
            canDoActions = true;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            currentCheckpoint = null;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                BaseInteractableObject otherObject = other.GetComponent<BaseInteractableObject>();

                if (otherObject != null)
                {
                    currentInteractableObject = otherObject;    
                }
            }
        }

        void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                Checkpoint checkpoint = other.GetComponent<Checkpoint>();
                LevelPortal levelPortal = other.GetComponent<LevelPortal>();

                if (checkpoint != null)
                {
                    if (checkpoint.isActive)
                    {
                        currentCheckpoint = checkpoint;
                    }
                }
                
                else if (levelPortal != null)
                {
                    if (levelPortal.isChangingLevel)
                    {
                        stats.lastPortalDirection = levelPortal.portalDirection;
                    }
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Interactable"))
            {
                BaseInteractableObject otherObject = other.GetComponent<BaseInteractableObject>();

                if (otherObject != null)
                {
                    currentInteractableObject = null;    
                }
            }
        }
    }
}