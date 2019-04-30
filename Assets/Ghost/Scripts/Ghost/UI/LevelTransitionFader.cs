using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ghost.UI
{
    public class LevelTransitionFader : MonoBehaviour
    {
        Image image;
        Animator animator;

        void Start()
        {
            image = GetComponent<Image>();
            animator = GetComponent<Animator>();
        }

        public void Show()
        {
            animator.SetBool("Show", true);
        }
        
        public void Hide()
        {
            animator.SetBool("Show", false);
        }
    }
}