using Ghost.Animation;
using Ghost.Weapons.Projectiles;
using UnityEngine;

namespace Ghost.Weapons
{
    public class BaseProjectileWeapon : BaseWeapon
    {
        public BaseProjectile projectilePrefab;

        protected override void Shoot()
        {
            base.Shoot();
            InstantiateProjectile();
        }

        protected virtual void InstantiateProjectile()
        {
            BaseProjectile projectile = Instantiate(projectilePrefab, shootPoint.position, transform.rotation);
            projectile.initialVelocity *= Mathf.Sign(GetComponentInParent<BaseAnimationController>().transform.localScale.x);
        }
    }
}