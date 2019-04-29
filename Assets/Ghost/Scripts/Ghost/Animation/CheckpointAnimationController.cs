using Ghost.Props.Interactable;

namespace Ghost.Animation
{
    public class CheckpointAnimationController : BaseAnimationController
    {
        Checkpoint checkpoint;
        
        protected override void Awake()
        {
            base.Awake();

            checkpoint = GetComponent<Checkpoint>();
        }

        void Update()
        {
            animator.SetBool("Using", checkpoint.isActive);
        }
    }
}