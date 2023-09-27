using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PrePhoton
{
    public class KillBarrier : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerStats>() != null)
            {
                // que sueñooo
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
                collision.GetComponent<PlayerStats>().Damage();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
