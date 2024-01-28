using UnityEngine;

public class BirdBag : MonoBehaviour
{
    [SerializeField] private Bird birdPref;
    public Bird GetBird(){return Instantiate(birdPref, transform.position, Quaternion.identity);}

}
