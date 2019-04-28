using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBaseScript : MonoBehaviour
{
    public float speed;
    public float health;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Feet"))
        {
            Destroy(gameObject);
        }
    }
}
