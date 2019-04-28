using System.Collections;
using Ghost.Mechanics.Player;
using UnityEngine;

namespace Ghost.AI
{
    public class DetectAndAttackPlayer : MonoBehaviour
    {
        [Header("Player detection")]
        public float detectionRange;
        public Vector2 raycastOffset;
        public LayerMask layerMask;
        public bool hasDetectedPlayer;

        [Header("Movement")]
        public bool isStatic;
        public float wanderingTime = 4.0f;
        public float waitTime = 2.0f;
        public Vector2 direction;
        
        [Header("Attacking")]
        public float stopDistance;
        public bool hasRangedAttack;
        public bool isAttacking;

        Invisibility playerInvisibility;
        
        void Start()
        {
            playerInvisibility = FindObjectOfType<Invisibility>();
            
            direction = Vector2.zero;
            hasDetectedPlayer = false;

            StartCoroutine(Wander());
        }

        void Update()
        {
            Vector2 raycastOrigin = (Vector2) transform.position + raycastOffset;
            Vector2 rayDir = direction != Vector2.zero ? direction : Vector2.right * Mathf.Sign(transform.localScale.x); 
            
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, rayDir, detectionRange, layerMask);
            Debug.DrawRay(raycastOrigin, rayDir * detectionRange);

            if (!playerInvisibility.isInvisible && hit.collider != null)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    hasDetectedPlayer = true;
                    if (!isStatic && hit.distance > stopDistance)
                    {
                        direction = rayDir;
                        isAttacking = false;
                    }
                    else if (hasRangedAttack)
                    {
                        direction = rayDir * 0.1f;
                        isAttacking = true;
                    }
                }
                else
                {
                    hasDetectedPlayer = false;
                    isAttacking = false;
                    if (hit.distance < 2.0f)
                    {
                        direction = new Vector2(-Mathf.Sign(transform.localScale.x), 0);    
                    }
                }
            }
            else
            {
                hasDetectedPlayer = false;
                isAttacking = false;
            }

            if (isStatic)
            {
                direction = Vector2.zero;
            }
        }

        IEnumerator Wander()
        {
            while (true)
            {
                yield return new WaitForSeconds(waitTime);
                if (!hasDetectedPlayer && !isStatic)
                {
                    direction = new Vector2(-Mathf.Sign(transform.localScale.x), 0);
                    yield return new WaitForSeconds(wanderingTime);
                    direction = Vector2.zero;    
                }
            }
        }
    }
}