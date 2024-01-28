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
        

    }

    void OnMouseDrag()
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

    void OnMouseUp()
    {
        Vector2 endPoint = transform.position;
        transform.position = startPoint;
        Vector2 force = endPoint - startPoint;
        onRelease?.Invoke(force.normalized * (force.magnitude / maxDistance));


    }
    
}
