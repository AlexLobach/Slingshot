using UnityEngine;
using UnityEngine.Events;

public class ShootPoint : MonoBehaviour
{
    [SerializeField] private float maxDistance = 3;
    private Vector2 startPoint;
    public UnityEvent<Vector2> onRelease;


    void Start()
    {
        startPoint = transform.position;
        Camera camera = Camera.main;

    }

    void OnMouseDrag()
    {
        
    }

    void OnMouseUp()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;
        if (Vector2.Distance(startPoint, mousePos) < maxDistance){
            transform.position = mousePos;
        }

        else {
            var direction = (mousePos - startPoint).normalized * maxDistance;
            transform.position = startPoint + direction;
        }
    }
    
}
