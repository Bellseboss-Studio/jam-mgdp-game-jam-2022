using UnityEngine;

public class LogicBellsebossFps
{
    private readonly IBellsebossMediator _mediator;

    public LogicBellsebossFps(IBellsebossMediator mediator)
    {
        _mediator = mediator;
    }

    public void Move(Vector2 direction)
    {
        //Debug.Log($"X: {direction.x} - Y: {direction.y}");
        _mediator.MoveDirection(direction.normalized);
    }

    public void Look(Vector2 rotation)
    {
        _mediator.RotationBody(rotation.x);
        _mediator.RotationCamera(rotation.y * -1);
    }
}