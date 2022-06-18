using UnityEngine;

public class MemoryTileController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForTouch();
    }

    // Check if a particular memory tile is touched
    void CheckForTouch()
    {
#if !UNITY_EDITOR
        if (Input.touchCount > 0)
        {
            Vector3 screenPoint = Input.GetTouch(0).position;

            // The z position is in world units from the camera
            screenPoint.z = Vector3.Distance(transform.position, Camera.main.transform.position);

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            bool overSprite = spriteRenderer.bounds.Contains(worldPoint);

            if (overSprite)
            {
                this.gameObject.SetActive(false);
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 screenPoint = Input.mousePosition;

            // The z position is in world units from the camera
            screenPoint.z = Vector3.Distance(transform.position, Camera.main.transform.position);

            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);

            bool overSprite = spriteRenderer.bounds.Contains(worldPoint);

            if (overSprite)
            {
                this.gameObject.SetActive(false);
            }
        }
#endif
    }
}
