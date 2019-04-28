using Ghost.GameLogic.Player;
using Ghost.Input;
using UnityEngine;

namespace Ghost.Props.Interactable
{
    public abstract class BaseInteractableObject : BaseProp
    {
        [Header("Interactable")]
        [Tooltip("If true, this will be interacted with while the button is being held, if false, only on button down")]
        public bool isContinuous;
        public bool isBeingInteracted;

        void Start()
        {
            isBeingInteracted = false;
        }

        protected virtual void Update()
        {
            if (isBeingInteracted)
            {
                Interact();
            }
        }

        public virtual void Interact()
        {
            throw new System.NotImplementedException();   
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
            }
        }

        protected virtual void OnTriggerStay2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                PlayerInput input = other.GetComponent<PlayerInput>();
                PlayerActions playerActions = other.GetComponent<PlayerActions>();
                if (isContinuous)
                {
                    isBeingInteracted = input.GetButton("Fire2");
                }
                else
                {
                    if (input.GetButtonDown("Fire2"))
                    {
                        Interact();
                    } 
                }
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isBeingInteracted = false;
            }
        }
    }
}