using Ghost.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class GameEnd : MonoBehaviour
    {
        public Button continueButton;

        Animator animator;
        
        PlayerStats playerStats;
        MainMenu mainMenu;

        void Start()
        {
            animator = GetComponent<Animator>();
            playerStats = FindObjectOfType<PlayerStats>();
            mainMenu = FindObjectOfType<MainMenu>();
        }

        public void Continue()
        {
            mainMenu.Show();
            playerStats.gameStarted = false;
            Hide();
        }
        
        public void Show()
        {
            animator.SetBool("Show", true);
        }

        void Hide()
        {
            animator.SetBool("Show", false);
        }
    }
}