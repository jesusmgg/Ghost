using System.Collections;
using Ghost.Input;
using Ghost.Utils.Types;
using UnityEngine;

namespace Ghost.Weapons
{
    public class BaseWeapon : BaseComponent
    {
        [Header("Weapon")]
        public float reloadPeriod;
        public Transform shootPoint; 

        protected bool canShoot = false;
        
        protected BaseInput input;

        protected virtual void Awake()
        {
            input = transform.parent.GetComponent<BaseInput>();
        }
        
        void Start()
        {
            StartCoroutine(Reload());
        }

        protected virtual void Update()
        {
            if (canShoot)
            {
                if (input.GetButton("Fire1"))
                {
                    Shoot();
                }
            }
        }

        protected virtual void Shoot()
        {
            canShoot = false;

            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadPeriod);
            canShoot = true;
            yield return null;
        }
    }
}