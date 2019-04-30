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

        public bool isReady;
        public float reloadProgress;
        public bool isReloading;
        
        PlayerInput playerInput;
        
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();

            isInvisible = false;
            isReady = true;
            reloadProgress = 0;
            isReloading = false;
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
            reloadProgress = 0;
            isReloading = true;

            while (reloadProgress < 1.0f)
            {
                reloadProgress += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            isReloading = false;
            isReady = true;
        }
    }
}