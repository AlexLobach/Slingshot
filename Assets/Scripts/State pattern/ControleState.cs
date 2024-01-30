using UnityEngine;

public class ControleState : MonoBehaviour
{
    void Start()
    {
        BirdState bird = new BirdState();

        NormalState normalState = new NormalState();
        ChargedState chargedState = new ChargedState();
        FiredState firedState = new FiredState();

        // changing states
        bird.SetState(normalState);
        bird.Handle();  // Output: 'Bird is in a normal state!'

        bird.SetState(chargedState);
        bird.Handle();  // Output: 'Bird is charged!'

        bird.SetState(firedState);
        bird.Handle();  // Output: 'Bird has been fired!'
    }
}