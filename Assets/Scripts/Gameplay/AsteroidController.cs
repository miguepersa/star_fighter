using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AsteroidController : MonoBehaviour
{
    public event Action<int> OnCollision;

    [SerializeField, Range(1, 99)] private int points = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag.Equals("ProjectilePlayer"))
        {
            OnCollision?.Invoke(points);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

    }
}
