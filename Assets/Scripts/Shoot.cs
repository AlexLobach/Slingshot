using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D ball;
    public Transform slingshotMiddle;
    public LineRenderer rubberBandLeft;
    public LineRenderer rubberBandRight;

    private Vector3 dragStartPos;
    private bool isDragging = false;

    void  Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            EndDrag();
        }
        if (isDragging)
        {
            ContinueDrag();
        }

    }
    
        void StartDrag()
        {
            dragStartPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragStartPos.z = 0f;
            isDragging = true;
        }

        void ContinueDrag()
        {
            Vector3 draggingPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggingPos.z = 0f;
            ball.transform.position = draggingPos;
            UpdateRubberBands(draggingPos);


        }

        void EndDrag()
        {
            isDragging = false;
            // Calculate the shoot direction and magnitude based on the drag
            Vector3 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 force = dragStartPos - dragEndPos;
            Vector2 forceVector = new Vector2(force.x, force.y) * power;
            // Shoot the ball
            ball.isKinematic = false;
            ball.AddForce(forceVector, ForceMode2D.Impulse);
            ResetRubberBands();
            
        }
        void UpdateRubberBands(Vector3 position)
        {
            rubberBandLeft.SetPosition(1, position);
            rubberBandRight.SetPosition(1, position);
        }
        void ResetRubberBands()
        {
            rubberBandLeft.SetPosition(1,slingshotMiddle.position);
            rubberBandRight.SetPosition(1,slingshotMiddle.position);

        }


}
