using System.Linq;
using Ghost.Input;
using Ghost.Props;
using Ghost.Props.Interactable;
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
        
        PlayerInput input;

        void Start()
        {
            input = GetComponent<PlayerInput>();
            
            SceneManager.sceneLoaded += OnSceneLoaded;

            canDoActions = true;
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            PlayerSpawn playerSpawn = FindObjectsOfType<PlayerSpawn>().FirstOrDefault(x => x.gameObject.scene == scene);
            if (playerSpawn != null)
            {
                transform.position = playerSpawn.transform.position;
            }
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