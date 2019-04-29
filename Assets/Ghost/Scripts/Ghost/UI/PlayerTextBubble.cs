using Ghost.GameLogic.Player;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class PlayerTextBubble : MonoBehaviour
    {
        public Text text;
        
        Animator animator;

        PlayerActions playerActions;
        PlayerStats playerStats;

        void Start()
        {
            animator = GetComponent<Animator>();

            playerActions = FindObjectOfType<PlayerActions>();
            playerStats = FindObjectOfType<PlayerStats>();
        }

        void Show()
        {
            animator.SetBool("Show", true);
        }

        void Hide()
        {
            animator.SetBool("Show", false);
        }
    }
}