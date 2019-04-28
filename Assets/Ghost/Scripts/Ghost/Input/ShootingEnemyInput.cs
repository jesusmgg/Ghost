using Ghost.AI;
using UnityEngine;

namespace Ghost.Input
{
    public class ShootingEnemyInput : BaseInput
    {
        DetectAndAttackPlayer detectAi;

        void Start()
        {
            detectAi = GetComponent<DetectAndAttackPlayer>();
        }

        void Update()
        {
            if (!useInput)
            {
                Direction = Vector2.zero;
            }
            else
            {
                Direction = detectAi.direction;
            }
        }

        public override bool GetButton(string button)
        {
            if (string.Equals(button, "Fire1"))
            {
                return useInput && detectAi.isAttacking;
            }
            return false;
        }
        
        public override bool GetButtonDown(string button)
        {
            return false;
        }
        
        public override bool GetButtonUp(string button)
        {
            return false;
        }
    }
}
