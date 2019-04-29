using Ghost.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class MoneyCounter : MonoBehaviour
    {
        public Text text;
        
        PlayerStats playerStats;

        void Start()
        {
            playerStats = FindObjectOfType<PlayerStats>();
        }

        void Update()
        {
            text.text = $"{playerStats.money}";
        }
    }
}