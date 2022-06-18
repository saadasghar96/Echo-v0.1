using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Track failed or helped player attemps
    public int playerAttempts;
    public int playerPosition; // Track current player position in memory map matrix

    public void MovePlayer()
    {

    }

    void Update()
    {
        CheckForTouch();
    }

    void CheckForTouch()
    { 
        #if !UNITY_EDITOR
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
 
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
 
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
 
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.name.Contains("Tile"))
                {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                }
            }
        }
        #endif

        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
 
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 100f);
 
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
                if (hit.collider.name.Contains("Tile"))
                {
                    GameObject temp = hit.transform.gameObject;
                    Destroy(temp);
                }
            }
        }
        #endif
     }
}
