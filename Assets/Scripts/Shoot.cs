using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D ballRB;
    public GameObject ball;
    public Transform slingshotMiddle;
    public LineRenderer rubberBandLeft;
    public LineRenderer rubberBandRight;
    public GameObject ballPrefab;
    private List<GameObject> ballsPool = new List<GameObject>();
    public Transform respawnPosition;

    private Vector3 dragStartPos;
    private bool isDragging = false;

    void  Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject currentBall = GetLooseBall();
            if (currentBall == null)
            {
                currentBall = CreateNewBall();
            }
            currentBall.gameObject.SetActive(true); 
            StartDrag();
        }
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine(EndDrag());
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
            ballRB.transform.position = draggingPos;
            UpdateRubberBands(draggingPos);


        }

        IEnumerator EndDrag()
        {
            
            isDragging = false;
            // Calculate the shoot direction and magnitude based on the drag
            Vector3 dragEndPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 force = dragStartPos - dragEndPos;
            Vector2 forceVector = new Vector2(force.x, force.y) * power;
            // Shoot the ball
            ballRB.isKinematic = false;
            ballRB.AddForce(forceVector, ForceMode2D.Impulse);
            ResetRubberBands();
            yield return new WaitForSeconds(2);
            ball.SetActive(false);
                               
            
            
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
        private void TransformPosition(GameObject gameObject, Transform respawn)
        {
            gameObject.transform.position = respawn.transform.position;
            gameObject.transform.rotation = respawn.transform.rotation;
            //gameObject.velocity = Vector2.zero;
        }
        private GameObject CreateNewBall()
        {
        var gameObject = Instantiate(ballPrefab);
        TransformPosition(gameObject, respawnPosition);
        ballsPool.Add(gameObject);        
        return gameObject;
        }
        private GameObject GetLooseBall()
        {
            foreach(var item in ballsPool) 
            {
                if (item.activeInHierarchy != true)
                {
                    TransformPosition(item, respawnPosition);                
                    return item;
                }            
            }
            return null;
        }


        
    
}
