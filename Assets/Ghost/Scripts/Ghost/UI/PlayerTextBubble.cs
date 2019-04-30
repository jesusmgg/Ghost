using Ghost.GameLogic.Player;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class PlayerTextBubble : MonoBehaviour
    {
        public Text text;
        
        bool isVisible;
        
        Animator animator;

        PlayerActions playerActions;
        PlayerStats playerStats;

        void Start()
        {
            animator = GetComponent<Animator>();

            playerActions = FindObjectOfType<PlayerActions>();
            playerStats = FindObjectOfType<PlayerStats>();

            isVisible = false;
        }

        void Update()
        {
            if (playerActions.currentMessage != null)
            {
                if (!isVisible)
                {
                    text.text = playerActions.currentMessage.message;
                    Show();
                }
            }
            else
            {
                if (isVisible)
                {
                    text.text = "";
                    Hide();
                }
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