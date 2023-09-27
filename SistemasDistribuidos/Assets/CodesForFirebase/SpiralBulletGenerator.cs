using PrePhoton;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePhoton
{
    public class SpiralBulletGenerator : MonoBehaviour
    {
        [SerializeField] int spirals = 1;
        [SerializeField] float radialSpeed = 1f;
        [SerializeField] float timePerBullet = 1f;
        [SerializeField] float bulletSpeed = 1f;
        [SerializeField] GameObject bullet;

        Vector2 polarMainAngle;
        float bulletCD;

        bool activated = false;

        private void Start()
        {
            polarMainAngle = new(0.1f, 0);
        }

        private void Update()
        {
            if (!activated) return;

            polarMainAngle.y += radialSpeed * Time.deltaTime;

            Vector2 direction = Utilities.PolarToCartesian(polarMainAngle);
            direction.Normalize();

            bulletCD -= Time.deltaTime;

            if (bulletCD < 0)
            {
                GenerateBullet(direction);
                bulletCD = timePerBullet;
            }
        }

        void GenerateBullet(Vector2 direction)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, Quaternion.identity, BulletDisposer.instance.transform);
            newBullet.GetComponent<Bullet>().movementVector = direction * bulletSpeed;
        }

        public void Set()
        {
            activated = true;
        }

        public void Stop()
        {
            activated = false;
        }
    }
}
