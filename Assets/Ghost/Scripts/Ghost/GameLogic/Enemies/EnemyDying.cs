using Ghost.Stats;
using UnityEngine;

namespace Ghost.GameLogic.Enemies
{
    public class EnemyDying : MonoBehaviour
    {
        EnemyStats enemyStats;

        void Start()
        {
            enemyStats = GetComponent<EnemyStats>();
        }

        void Update()
        {
            if (enemyStats.isDead)
            {
                Die();
            }
        }

        void Die()
        {
            gameObject.SetActive(false);
        }
    }
}