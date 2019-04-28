using System.Collections;
using UnityEngine;

namespace Ghost.Weapons.Projectiles
{
    public class BaseProjectile : BaseComponent
    {
        public string targetTag = "Enemy";
        
        [Header("Movement")]
        [Range(0.0f, 1.0f)] public float initialSpeedMultiplier;
        public Vector2 initialVelocity = Vector2.right;

        [Header("Stats")]
        public float lifeTime = 3.0f;
        public float damage = 1.0f;

        protected virtual void Start()
        {
            Destroy(gameObject, lifeTime);
        }

        protected virtual void Update()
        {
            transform.position += (Vector3) (initialVelocity * Time.deltaTime);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                StartCoroutine(WaitAndDestroy()); 
            }
        }

        IEnumerator WaitAndDestroy()
        {
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }
    }
}