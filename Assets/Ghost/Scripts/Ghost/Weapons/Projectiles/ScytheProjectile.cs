using UnityEngine;

namespace Ghost.Weapons.Projectiles
{
    public class ScytheProjectile : BaseProjectile
    {
        [Header("Scythe")]
        public float rotationSpeed;
        
        protected override void Update()
        {
            base.Update();
            
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
    }
}