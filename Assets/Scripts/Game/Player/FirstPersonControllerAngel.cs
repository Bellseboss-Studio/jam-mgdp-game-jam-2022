using SystemOfExtras;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Player
{
    public class FirstPersonControllerAngel : MonoBehaviour, IInputBellseboss
    {
        [SerializeField] private bool isInventoryKeyPressed;
        CharacterController characterController;
        [Header("Opciones de personaje")]
        public float walkSpeed = 6.0f;
        public float runSpeed = 10.0f;
        public float jumpSpeed = 8.0f;
        public float gravity = 20.0f;

        [Header("Opciones de camara")]
        public GameObject cam;
        public float mouseHorizontal = 3.0f;
        public float mouseVertical = 2.0f;

    

        public float minRotation = -65.0f;
        public float maxRotation = 60.0f;
        float h_mouse, v_mouse;


        private Vector3 move = Vector3.zero;
        private Vector2 _inputMovement, _cameraMovement;
        private IMediatorPlayer _mediator;

        void Start()
        {
            characterController = GetComponent<CharacterController>();

            Cursor.lockState = CursorLockMode.Locked; 
        
        }

        void Update()
        {
            h_mouse = mouseHorizontal * _cameraMovement.x;
            v_mouse += mouseVertical * _cameraMovement.y;

            v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
            
            cam.transform.localEulerAngles = new Vector3(v_mouse, 0, 0);

            transform.Rotate(0, h_mouse, 0);


            if (characterController.isGrounded)
            {
                move = new Vector3(_inputMovement.x, 0.0f, _inputMovement.y);

                /*if (Input.GetKey(KeyCode.LeftShift))
                    move = transform.TransformDirection(move) * runSpeed;
                else
                    */
                move = transform.TransformDirection(move) * walkSpeed;

                /*if (Input.GetKey(KeyCode.Space))

                    move.y = jumpSpeed;*/
            }
            move.y -= gravity * Time.deltaTime;

            characterController.Move(move * Time.deltaTime);
        }

        public void OnMove(InputAction.CallbackContext value)
        {
            _inputMovement = value.ReadValue<Vector2>();
            /*move = new Vector3(_inputMovement.x, 0, _inputMovement.y);
            move = transform.TransformDirection(move) * walkSpeed;*/
        }

        public void OnLook(InputAction.CallbackContext value)
        {
            _cameraMovement = value.ReadValue<Vector2>();
            /*h_mouse = mouseHorizontal * _cameraMovement.x;
            v_mouse += mouseVertical * _cameraMovement.y;
            v_mouse = Mathf.Clamp(v_mouse, minRotation, maxRotation);
            
            cam.transform.localEulerAngles = new Vector3(v_mouse, 0, 0);
            transform.Rotate(0, h_mouse, 0);*/
        }

        public void ConfigurePlayer(IMediatorPlayer mediator)
        {
            _mediator = mediator;
        }
        
        public void OnLookInventory(InputAction.CallbackContext value)
        {
            isInventoryKeyPressed = value.ReadValueAsButton();
        }


        public bool PressInventoryButton()
        {
            return isInventoryKeyPressed;
        }
    }
}