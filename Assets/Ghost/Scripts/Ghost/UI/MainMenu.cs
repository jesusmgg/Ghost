using System.Collections;
using Ghost.Audio;
using Ghost.Stats;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class MainMenu : MonoBehaviour
    {
        public Button newGameButton;
        public Button continueButton;

        Animator animator;
        
        PlayerStats playerStats;
        AudioPlayer audioPlayer;

        void Start()
        {
            animator = GetComponent<Animator>();
            playerStats = FindObjectOfType<PlayerStats>();
            audioPlayer = FindObjectOfType<AudioPlayer>();

            continueButton.gameObject.SetActive(playerStats.HasSave());
            
            SceneManager.LoadSceneAsync("Level00", LoadSceneMode.Additive);
            
            audioPlayer.StartMusic(audioPlayer.menuMusic);
            
            Show();
        }

        public void StartNewGame()
        {
            Hide();
            
            audioPlayer.StopMusic();
            audioPlayer.StartMusic(audioPlayer.levelMusic);
            
            playerStats.gameStarted = true;
        }

        public void ContinueGame()
        {
            audioPlayer.StopMusic();
            audioPlayer.StartMusic(audioPlayer.levelMusic);
            
            playerStats.LoadStats();
            StartCoroutine(DoContinueGame());    
        }

        IEnumerator DoContinueGame()
        {
            if (playerStats.currentLevel != "Level00")
            {
                yield return SceneManager.LoadSceneAsync(playerStats.currentLevel, LoadSceneMode.Additive);
                yield return SceneManager.UnloadSceneAsync("Level00");
            }

            Hide();
            playerStats.gameStarted = true;
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