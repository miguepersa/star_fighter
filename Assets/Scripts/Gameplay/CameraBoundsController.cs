using UnityEngine;

public class CameraBoundsController : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float deltaBound = 0.1f;

    private Bounds cameraBounds;
    private Bounds spriteBounds;

    public static Bounds GetOrthoBounds(Camera camera)
    {
        var screenAspect = Screen.width / (float)Screen.height;
        var cameraHeight = camera.orthographicSize * 2f;
        var bounds = new Bounds(
            camera.transform.position,
            new Vector3(
                cameraHeight * screenAspect,
                cameraHeight,
                0
            )
        );

        return bounds;
    }

    private void Clamp()
    {
        Vector3 newPos = transform.position;

        // bot
        if ( spriteBounds.max.y < cameraBounds.min.y )
        {
            newPos.y = cameraBounds.max.y + spriteBounds.extents.y - deltaBound;
        }

        // top
        if (spriteBounds.min.y > cameraBounds.max.y)
        {
            newPos.y = cameraBounds.min.y - spriteBounds.extents.y + deltaBound;
        }

        // left
        if (spriteBounds.max.x < cameraBounds.min.x)
        {
            newPos.x = cameraBounds.max.x + spriteBounds.extents.x - deltaBound;
        }

        // right
        if (spriteBounds.min.x > cameraBounds.max.x)
        {
            newPos.x = cameraBounds.min.x - spriteBounds.extents.x + deltaBound;
        }

        transform.position = newPos;
    }

    private void Start()
    {
        cameraBounds = GetOrthoBounds(mainCamera);
    }

    private void Update()
    {
        spriteBounds = spriteRenderer.bounds;
        Clamp();
    }

}
