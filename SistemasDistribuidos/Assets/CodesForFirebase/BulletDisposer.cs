using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePhoton
{
    public class BulletDisposer : MonoBehaviour
    {
        public static BulletDisposer instance;

        private void Start()
        {
            instance = this;
        }
    }
}

