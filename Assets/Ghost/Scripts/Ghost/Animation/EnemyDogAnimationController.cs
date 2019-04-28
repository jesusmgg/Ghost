using Ghost.AI;
using Ghost.Input;
using Ghost.Physics;
using UnityEngine;

namespace Ghost.Animation
{
    public class EnemyDogAnimationController : BaseAnimationController
    {
        BaseInput input;
        BipedPhysicsObject physicsObject;
        DetectAndAttackPlayer playerDetector;

        protected override void Awake()
        {
            base.Awake();

            input = GetComponent<BaseInput>();
            physicsObject = GetComponent<BipedPhysicsObject>();
            playerDetector = GetComponent<DetectAndAttackPlayer>();
        }

        void Update()
        {
            bool flipSprite = transform.localScale.x < 0 ? input.Direction.x > 0.01f : input.Direction.x < -0.01f;
            if (flipSprite)
            {
                var localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
            animator.SetBool("Grounded", physicsObject.Grounded);
            animator.SetFloat("VelocityX", Mathf.Abs(physicsObject.Velocity.x));
            animator.SetFloat("VelocityY", physicsObject.Velocity.y);
            animator.SetBool("Jump", input.GetButtonDown("Jump"));
            animator.SetBool("Running", playerDetector.hasDetectedPlayer);
        }
    }
}