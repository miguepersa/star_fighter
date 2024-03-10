using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField, Range(0.1f, 10f)] private float speed = 0.5f;
    
    private Vector3 transformDirection;
    
private void Update()
    {
        var translation = speed * Time.deltaTime * transform.up;
        transform.Translate(translation, Space.World);

        if (!spriteRenderer.isVisible) Destroy(gameObject);

    }

}
