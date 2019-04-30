using System.Collections;
using Ghost.Audio;
using Ghost.GameLogic.Player;
using Ghost.Mechanics;
using Ghost.Utils.Enums;
using Ghost.Weapons.Projectiles;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ghost.Stats
{
    public class PlayerStats : BaseStats
    {
        public int money;
        public float health;
        public bool isDead;
        public bool canTakeDamage = true;
        public string currentLevel = "Level00";
        public PortalDirection lastPortalDirection = PortalDirection.Right;

        public bool gameStarted;

        PlayerRespawning respawning;

        AudioPlayer audioPlayer;

        void Awake()
        {
            respawning = GetComponent<PlayerRespawning>();
            
            gameStarted = false;
        }

        void Start()
        {
            audioPlayer = FindObjectOfType<AudioPlayer>();
            
            if (health > 0)
            {
                isDead = false;
            }
        }

        void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {
            currentLevel = scene.name;
            if (gameStarted)
            {
                SaveStats();
            }
        }

        void OnEnable()
        {
            respawning.onRespawn.AddListener(Revive);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        void OnDisable()
        {
            respawning.onRespawn.RemoveListener(Revive);
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }

        void Update()
        {
            if (health <= 0 && !isDead)
            {
                Debug.Log("Player has died");
                isDead = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            HealthModifier hm = other.gameObject.GetComponent<HealthModifier>();
            BaseProjectile projectile = other.gameObject.GetComponent<BaseProjectile>();
            
            if (hm != null)
            {
                if (CompareTag(hm.targetTag))
                {
                    if (!isDead)
                    {
                        health += hm.healthDelta;    
                    }
                }
            }

            else if (projectile != null)
            {
                if (canTakeDamage && CompareTag(projectile.targetTag))
                {
                    health -= projectile.damage;
                }
            }

            else if (canTakeDamage && other.CompareTag("Enemy"))
            {
                health -= 1;
            }
        }

        void Revive()
        {
            audioPlayer.PlaySound(audioPlayer.dying);
            
            health = 1;
            isDead = false;
        }

        public PortalDirection GetOppositeDirection()
        {
            if (lastPortalDirection == PortalDirection.Up) {return PortalDirection.Down;}
            if (lastPortalDirection == PortalDirection.Down) {return PortalDirection.Up;}
            if (lastPortalDirection == PortalDirection.Left) {return PortalDirection.Right;}
            if (lastPortalDirection == PortalDirection.Right) {return PortalDirection.Left;}

            return PortalDirection.Right;
        }

        void SaveStats()
        {
            StartCoroutine(DoSaveStats());
        }

        IEnumerator DoSaveStats()
        {
            yield return new WaitForEndOfFrame();
            
            PlayerPrefs.SetInt("HasSave", 1);
            
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetFloat("Health", health);
            PlayerPrefs.SetString("CurrentLevel", currentLevel);
            PlayerPrefs.SetInt("LastPortalDirection", (int) lastPortalDirection);
            
            PlayerPrefs.Save();
            
            Debug.Log("Game Saved");
        }

        public void LoadStats()
        {
            if (HasSave())
            {
                Debug.Log("Loading game");
                money = PlayerPrefs.GetInt("Money");
                health = PlayerPrefs.GetFloat("Health");
                currentLevel = PlayerPrefs.GetString("CurrentLevel");
                lastPortalDirection = (PortalDirection) PlayerPrefs.GetInt("LastPortalDirection");
            }
        }

        public bool HasSave()
        {
            return PlayerPrefs.HasKey("HasSave");
        }
    }
}