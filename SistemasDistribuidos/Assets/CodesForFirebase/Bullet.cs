using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePhoton
{
    public class Bullet : MonoBehaviour
    {
        public Vector2 movementVector;
        public int bulletLife;

        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3)movementVector * Time.deltaTime;
        }
    }
}
