using PrePhoton;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthDisplay;
    [SerializeField] int health;
    [SerializeField] float damageFade = 1f;

    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = Color.Lerp(spriteRenderer.color, Color.white, Time.deltaTime * damageFade);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.GetComponentInParent<Bullet>() != null)
        {
            Damage();
        }
    }

    public void Damage()
    {
        if (health <= 0) return;

        health--;
        healthDisplay.text = $"Health : {health}";

        spriteRenderer.color = Color.red;

        if (health <= 0)
        {
            // End
            Stop();
            FirebaseManager.instance.SaveData();
            FirebaseManager.instance.StopGame();
        }
    }

    public void Stop()
    {
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Set()
    {
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;

        health = 5;
        healthDisplay.text = $"Health : {health}";

        spriteRenderer.color = Color.white;
    }
}
