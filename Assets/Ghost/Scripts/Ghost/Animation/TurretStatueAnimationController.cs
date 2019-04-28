using Ghost.AI;

namespace Ghost.Animation
{
    public class TurretStatueAnimationController : BaseAnimationController
    {
        
        DetectAndAttackPlayer playerDetector;
        
        protected override void Awake()
        {
            base.Awake();

            playerDetector = GetComponent<DetectAndAttackPlayer>();
        }

        void Update()
        {
            animator.SetBool("Using", playerDetector.isAttacking);
        }
    }
}