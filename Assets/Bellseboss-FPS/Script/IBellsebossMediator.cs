using UnityEngine;

public interface IBellsebossMediator
{
    void MoveDirection(Vector2 direction);
    void RotationBody(float rotationX);
    void RotationCamera(float rotationY);
}