using Ghost.Mechanics;
using Ghost.Mechanics.Enemies;
using Ghost.Weapons.Projectiles;
using UnityEngine;

namespace Ghost.Stats
{
    public class EnemyStats : BaseStats
    {
        public bool isDead;

        AttachToTombs attachToTombs;

        void Start()
        {
            attachToTombs = GetComponent<AttachToTombs>();
            
            isDead = false;
        }

        void Update()
        {
            if (!isDead)
            {
                if (attachToTombs.hasAllTombsDead)
                {
                    isDead = true;
                }    
            }
        }
    }
}