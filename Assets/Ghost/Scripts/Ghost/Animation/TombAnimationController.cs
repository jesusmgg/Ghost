using Ghost.Props.Interactable;

namespace Ghost.Animation
{
    public class TombAnimationController : BaseAnimationController
    {
        Tomb tomb;
        
        protected override void Awake()
        {
            base.Awake();

            tomb = GetComponent<Tomb>();
        }

        void Update()
        {
            animator.SetBool("Using", tomb.isBeingInteracted);
            if (tomb.isDead) {animator.SetTrigger("Die");}
        }
    }
}