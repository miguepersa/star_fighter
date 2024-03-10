using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroidGenerator : MonoBehaviour
{
    public event Action<int> OnAsteroidDestroyed;

    [Header("References")]
    [SerializeField] private AsteroidController prefab = null;
    [SerializeField] private Transform parent = null;
    [SerializeField] private AudioSource audioSource = null; 
    [SerializeField] private AudioClip explosion = null;

    [SerializeField] private int initialNumberOfAsteroids = 5;
    [SerializeField] private float delta = 3f;
    
    
    private void Start()
    {
        Generate(initialNumberOfAsteroids);
    }

    public void Generate(int num = 1)
    {

        for (int i = 0; i < num; i++)
        {
            var position = (Vector3)Random.insideUnitCircle * delta + parent.position;
            var asteroid = Instantiate(prefab, position, Quaternion.identity, parent);
            asteroid.OnCollision += AsteroidDestroyedHandler;
        }
    }

    private void AsteroidDestroyedHandler(int points)
    {
        audioSource.PlayOneShot(explosion, 0.5f);
        OnAsteroidDestroyed?.Invoke(points); 
    }

}
