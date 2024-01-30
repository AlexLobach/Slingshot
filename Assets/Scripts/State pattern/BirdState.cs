using UnityEngine;

public class BirdState : MonoBehaviour
{
    private IBirdState _state;

    public void SetState(IBirdState state)
    {
        _state = state;
    }

    public void Handle()
    {
        _state.Handle(this);
    }
}