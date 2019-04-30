using Ghost.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class Map : MonoBehaviour
    {
        public Image marker00;
        public Image marker01;
        public Image marker02;
        public Image marker10;
        public Image marker11;
        public Image marker12;
        public Image marker20;
        public Image marker21;
        public Image marker22;
        public Image marker30;
        public Image marker31;
        public Image marker32;
        
        PlayerStats playerStats;

        void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        void Update()
        {
            marker00.enabled = false;
            marker01.enabled = false;
            marker02.enabled = false;
            marker10.enabled = false;
            marker11.enabled = false;
            marker12.enabled = false;
            marker20.enabled = false;
            marker21.enabled = false;
            marker22.enabled = false;
            marker30.enabled = false;
            marker31.enabled = false;
            marker32.enabled = false;
            
            if (playerStats.currentLevel.Equals("Level00"))
            {
                marker00.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level01"))
            {
                marker01.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level02"))
            {
                marker02.enabled = true;
            }
            
            else if (playerStats.currentLevel.Equals("Level10"))
            {
                marker10.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level11"))
            {
                marker11.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level12"))
            {
                marker12.enabled = true;
            }
            
            else if (playerStats.currentLevel.Equals("Level20"))
            {
                marker20.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level21"))
            {
                marker21.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level22"))
            {
                marker22.enabled = true;
            }
            
            else if (playerStats.currentLevel.Equals("Level30"))
            {
                marker30.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level31"))
            {
                marker31.enabled = true;
            }
            else if (playerStats.currentLevel.Equals("Level32"))
            {
                marker32.enabled = true;
            }
        }
    }
}