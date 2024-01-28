using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    private Rigidbody2D birdRigidbody2D;

    void Awake()
    {
        birdRigidbody2D = GetComponent<Rigidbody2D>();
        birdRigidbody2D.isKinematic = true;

    }

    public void FlyingChicken(Vector2 whereToFly){
        birdRigidbody2D.isKinematic = false;
        birdRigidbody2D.AddForce(whereToFly, ForceMode2D.Impulse);

    }
    
}
