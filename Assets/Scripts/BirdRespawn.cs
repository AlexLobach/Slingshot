using System;
using System.Collections;
using UnityEngine;
using DG.Tweening;

[Serializable]
public class BirdRespawn
{
    [SerializeField] private float animation = 2f;
    [SerializeField] private float animationJump = 2;

    public IEnumerator TransferBird(Bird bird, Vector2 startPosition)
    {
        yield return bird.transform.DOJump(startPosition, animationJump, 1, animation).WaitForCompletion();
    }
}