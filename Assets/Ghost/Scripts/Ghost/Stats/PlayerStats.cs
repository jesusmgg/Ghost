using Ghost.Mechanics;
using Ghost.Weapons.Projectiles;
using UnityEngine;

namespace Ghost.Stats
{
    public class PlayerStats : BaseStats
    {
        public float health;
        public bool dead;

        void Start()
        {
            if (health > 0)
            {
                dead = false;
            }
        }

        void Update()
        {
            if (health <= 0 && !dead)
            {
                Debug.Log("Player has died");
                dead = true;
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
                    if (!dead)
                    {
                        health += hm.healthDelta;    
                    }
                }
            }

            else if (projectile != null)
            {
                if (CompareTag(projectile.targetTag))
                {
                    health -= projectile.damage;
                }
            }

            else if (other.CompareTag("Enemy"))
            {
                health -= 1;
            }
        }
    }
}