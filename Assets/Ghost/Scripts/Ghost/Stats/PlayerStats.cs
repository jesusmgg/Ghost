using Ghost.GameLogic.Player;
using Ghost.Mechanics;
using Ghost.Utils.Enums;
using Ghost.Weapons.Projectiles;
using UnityEngine;

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

        PlayerRespawning respawning;

        void Awake()
        {
            respawning = GetComponent<PlayerRespawning>();
        }

        void Start()
        {
            if (health > 0)
            {
                isDead = false;
            }
        }

        void OnEnable()
        {
            respawning.onRespawn.AddListener(Revive);
        }
        
        void OnDisable()
        {
            respawning.onRespawn.RemoveListener(Revive);
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
    }
}