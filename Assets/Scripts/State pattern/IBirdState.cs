using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBirdState
{
    void Handle(BirdState bird);
}

public class NormalState : IBirdState
{
    public void Handle(BirdState bird)
    {
        Debug.Log("Bird is in a normal state!");
    }
}

public class ChargedState : IBirdState
{
    public void Handle(BirdState bird)
    {
        Debug.Log("Bird is charged!");
    }
}

public class FiredState : IBirdState
{
    public void Handle(BirdState bird)
    {
        Debug.Log("Bird has been fired!");
    }
}
