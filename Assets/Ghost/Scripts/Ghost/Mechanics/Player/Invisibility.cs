using System.Collections;
using Ghost.Input;
using UnityEngine;

namespace Ghost.Mechanics.Player
{
    public class Invisibility : MonoBehaviour
    {
        public float duration = 3.0f;
        public float reloadTime = 10.0f;
        public ParticleSystem particles;
        
        public bool isInvisible;

        bool isReady;
        
        PlayerInput playerInput;
        
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();

            isInvisible = false;
            isReady = true;
        }

        void Update()
        {
            if (isReady && playerInput.GetButtonDown("Fire1") && playerInput.Direction.y < 0)
            {
                StartCoroutine(TurnInvisible());
            }
        }

        IEnumerator TurnInvisible()
        {
            isInvisible = true;
            particles.Play();
            isReady = false;
            
            yield return new WaitForSeconds(duration);
            isInvisible = false;

            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadTime);
            isReady = true;
        }
    }
}