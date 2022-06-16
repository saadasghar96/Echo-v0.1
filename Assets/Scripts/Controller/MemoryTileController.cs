using UnityEngine;

public class MemoryTileController : MonoBehaviour
{
    RaycastHit2D hit;
    Vector2[] touches = new Vector2[5];

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch t in Input.touches)
            {
                touches[t.fingerId] = Camera.main.ScreenToWorldPoint(Input.GetTouch(t.fingerId).position);
                if (Input.GetTouch(t.fingerId).phase == TouchPhase.Began)
                    hit = Physics2D.Raycast(touches[t.fingerId], Vector2.zero);
                if (hit.collider.name == "Tri(Clone)")
                    hit.transform.position = touches[t.fingerId];

                print("Ouch");
            }
        }
    }
}
