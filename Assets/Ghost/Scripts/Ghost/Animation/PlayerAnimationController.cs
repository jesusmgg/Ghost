using Ghost.GameLogic.Player;
using Ghost.Input;
using Ghost.Physics;
using SpriterDotNetUnity;
using UnityEngine;

namespace Ghost.Animation
{
    public class PlayerAnimationController : BaseAnimationController
    {
        BaseInput input;
        BipedPhysicsObject physicsObject;
        PlayerActions playerActions;

        protected override void Awake()
        {
            base.Awake();

            input = GetComponent<BaseInput>();
            physicsObject = GetComponent<BipedPhysicsObject>();
            playerActions = GetComponent<PlayerActions>();
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
            animator.SetBool("Using", input.GetButton("Fire2") && playerActions.currentInteractableObject != null);
        }
    }
}