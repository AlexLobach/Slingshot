using System;
using System.Collections;
using UnityEngine;

public class ShootSlingshot : MonoBehaviour
{
    [SerializeField] private BirdRespawn birdRespawn;
    [SerializeField] private float slingPower = 25f;
    [SerializeField] private int numberOfBirds = 10;
    [SerializeField] private ShootPoint shootPoint;
    [SerializeField] private BirdBag birdBag;

    private IEnumerator Start()
    {
        for (int i = 0; i < numberOfBirds; i++)
        {
            var bird = birdBag.GetBird();
            yield return SeatBird(bird);
            yield return WaitForShot(bird);
            
        }
    }

    private IEnumerator WaitForShot(Bird bird)
    {
        var isDone = false;
        void Shoot (Vector2 direction)
        {
            isDone = true;
            bird.FlyingChicken(direction * -slingPower);

        }
        shootPoint.onRelease.AddListener(Shoot);
        while (!isDone)
        {
            bird.transform.position = shootPoint.transform.position;
            yield return null;
        }
        shootPoint.onRelease.RemoveAllListeners();
    }

    private IEnumerator SeatBird(Bird bird)
    {
        shootPoint.enabled = false;
        yield return birdRespawn.TransferBird(bird, shootPoint.transform.position);
        shootPoint.enabled = true;
        
    }
}