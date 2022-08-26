using Cinemachine;
using UnityEngine;

public class BellsebossFPS : MonoBehaviour, IBellsebossMediator
{
    [Header("Parameters Configuration")] 
    [SerializeField] private float speed;
    [SerializeField] private float speedRotation;
    
    [Header("Dependencies")]
    [SerializeField] private FacadeInputSystem newInput;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject fatherOfCamera;
    [SerializeField] private GameObject camera;
    
    
    private LogicBellsebossFps logic;
    private bool canMove;
    private Vector2 _direction;
    private float _xRotationCamera;

    private void Start()
    {
        logic = new LogicBellsebossFps(this);
        
        newInput.OnMove += OnMove;
        newInput.OnLook += OnLook;
        
        camera.transform.SetParent(fatherOfCamera.transform);
        camera.transform.localPosition = Vector3.zero;
        camera.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnLook(Vector2 rotation)
    {
        logic.Look(rotation);
    }

    public void OnMove(Vector2 direction)
    {
        logic.Move(direction);
    }

    public void MoveDirection(Vector2 direction)
    {
        _direction = direction;
    }

    public void RotationBody(float rotationX)
    {
        transform.Rotate(0, rotationX * speedRotation * Time.deltaTime, 0, Space.Self);
    }

    public void RotationCamera(float rotationY)
    {
        _xRotationCamera += rotationY * speedRotation * Time.deltaTime;
        _xRotationCamera = Mathf.Clamp(_xRotationCamera, -90f, 90f);
        Debug.Log($"fatherOfCamera.transform.eulerAngles {_xRotationCamera}");
        //fatherOfCamera.transform.Rotate(rotationY * speedRotation * Time.deltaTime, 0, 0, Space.Self);
        fatherOfCamera.transform.localRotation = Quaternion.Euler(_xRotationCamera, 0f, 0f);
    }

    private void Update()
    {
        rb.velocity = transform.TransformDirection(new Vector3(_direction.x, 0, _direction.y)) *
                      (Time.deltaTime * speed);
    }
}