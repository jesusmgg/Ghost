using Ghost.GameLogic.Player;
using Ghost.Mechanics.Player;
using Ghost.Props.Interactable;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class CooldownBar : MonoBehaviour
    {
        public Image lifeImage;
        public Image invisibilityImage;
        public Image fillImage;

        bool isVisible;

        Animator animator;

        PlayerStats playerStats;
        PlayerActions playerActions;
        Invisibility invisibility;

        void Start()
        {
            animator = GetComponent<Animator>();
            
            playerStats = FindObjectOfType<PlayerStats>();
            playerActions = FindObjectOfType<PlayerActions>();
            invisibility = FindObjectOfType<Invisibility>();

            isVisible = false;
            Hide();
        }

        void Update()
        {
            if (playerActions.currentInteractableObject != null)
            {
                Tomb tomb = playerActions.currentInteractableObject.GetComponent<Tomb>();
                if (tomb != null && !tomb.isDead)
                {
                    Show();
                    invisibilityImage.enabled = false;
                    lifeImage.enabled = true;
                    fillImage.fillAmount = Mathf.Clamp01(tomb.currentInteractionTime / tomb.requiredTime);
                }
                else
                {
                    Hide();
                }
            }

            else if (invisibility.isReloading)
            {
                Show();
                invisibilityImage.enabled = true;
                lifeImage.enabled = false;
                fillImage.fillAmount = Mathf.Clamp01(invisibility.reloadProgress);
            }

            else
            {
                Hide();
            }
        }
        
        void Show()
        {
            if (!isVisible)
            {
                animator.SetBool("Show", true);
                isVisible = true;
            }
        }
        
        void Hide()
        {
            if (isVisible)
            {
                animator.SetBool("Show", false);
                isVisible = false;
            }
        }
    }
}