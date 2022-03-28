using UnityEngine;

public class BaitReadyState : BaitBaseState
{
    public override void EnterState(BaitStateManager bait)
    {
        //Debug.Log("Entering Ready State");
    }
    public override void UpdateState(BaitStateManager bait)
    {

    }
    public override void OnCollisionEnter(BaitStateManager bait, Collision collision)
    {

    }

    public override void OnPointerPress(BaitStateManager bait, Vector2 position)
    {
        bait.PullBait();
    }
}
