using RPG.Control;
using RPG.Core;
using UnityEngine;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float projectileSpeed;
        [SerializeField] private bool isHoming = false;
        [SerializeField] private GameObject hitEffect = null;
        [SerializeField] private float lifeTime = 5;
        [SerializeField] private GameObject[] destroyOnHit = null;
        [SerializeField] private float lifeAfterImpact = 2;

        private Health target = null;
        private float damage = 0;

        private void Start()
        {
            transform.LookAt(GetAimLocation());
        }

        void Update()
        {
            if (target == null) return;

            if (isHoming && !target.IsDead())
            {
                transform.LookAt(GetAimLocation());
            }

            transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);
        }

        private Vector3 GetAimLocation()
        {
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if(targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }

        public void SetTarget(Health target, float damage)
        {
            this.target = target;
            this.damage = damage;

            Destroy(gameObject, lifeTime);
        }

        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<Health>() == target)
            {
                if (target.IsDead()) return;
                target.TakeDamage(damage);

                projectileSpeed = 0;

                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform.position, transform.rotation);
                }

                foreach(GameObject toDestroy in destroyOnHit)
                {
                    Destroy(toDestroy);
                }


                Destroy(gameObject, lifeAfterImpact); 
            }
        }
    }
}
