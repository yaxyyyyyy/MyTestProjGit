using MyInputActions;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour, IMove
{
    //test
    //https://www.youtube.com/watch?v=f473C43s8nE
    //- ñâÿçü ïîëåé ÷åðåç îáùóþ ññûëêó íà ïðèðàâíåííûå Transform
    //orientation ó íåãî êîíå÷íî åù¸ ñòðàííåå
    [Header("Movement")]
    [SerializeField] private float _moveSpeed = 12f;
    [SerializeField] private PlayerCamera OrientationCamera;
    private Transform _orientation => OrientationCamera.Orientation;
    private float _horizontalInput;
    private float _verticalInput;
    Vector3 _moveDirection;
    [SerializeField] private Rigidbody _rBody;

    [Header("Jump")]
    //[SerializeField] private KeyCode _jumpKey = KeyCode.Space;
    [SerializeField] private float _jumpForce = 12;
    [SerializeField] private float _jumpCooldown = 0.25f;
    [SerializeField] private float _airMultiplier = 0.4f;
    [SerializeField] private bool _isReadyToJump = true;


    [Header("Ground Check")]
    [SerializeField] private float PlayerHeight = 2f;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private float GroundDrag = 5f;
    private bool _isGrounded;

    //[Header("NewInput")]
    //[Inject] private MyInputActions.MyInputActions _actions;


    //[Header("new Input Check")]
    //[SerializeField] private MyInputActions.MyInputActions _inputActions;

    public void SetMovement(float moveSpeed = 7f, float jumpForce = 12, float jumpCooldown = 0.25f, float airMultiplier = 0.4f)
    {        _moveSpeed = moveSpeed; _jumpForce = jumpForce; _jumpCooldown = jumpCooldown; _airMultiplier = airMultiplier;    }
    private void Start()
    {
        _rBody.freezeRotation = true;
        //_inputActions.Player.Jump.started
    }
    //private void OnEnable()    {        _actions.Player.Jump.performed += OnJumpNewInput;    }
    //private void OnDisable()    {        _actions.Player.Jump.performed -= OnJumpNewInput;    }
    private void Update()
    {
        SetIsGroundedUpd();
        SetInputUpd();
        //SetInputJumpUpd();
        SetPlayerControlUpd();
        SetRBodyDragUpd();
    }

    private void SetIsGroundedUpd()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.2f, GroundMask);
    }
    private void SetRBodyDragUpd()
    { 
        _rBody.drag = _isGrounded ? GroundDrag : 0;
    }
    private void SetInputUpd()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    private void SetPlayerControlUpd()
    {
        _rBody.velocity = _rBody.velocity.sqrMagnitude > _moveSpeed * _moveSpeed ? _rBody.velocity.normalized * _moveSpeed : _rBody.velocity;
    }

    //private void SetInputJumpUpd()
    //{
    //    if(Input.GetKey(_jumpKey) && _isReadyToJump && _isGrounded)
    //    {
    //        _isReadyToJump = false;
    //        GetJump();

    //        Invoke(nameof(ResetJump), _jumpCooldown);
    //    }
    //}


    // ìåòîä âûçûâàåòñÿ íîâîé input-system
    //public void OnJumpNewInput(InputAction.CallbackContext context)
    //{
    //    //Debug.Log("OnJump");
    //    if (_isReadyToJump && _isGrounded)
    //    {
    //        _isReadyToJump = false;
    //        GetJump();

    //        Invoke(nameof(ResetJump), _jumpCooldown);
    //    }
    //}
    public void OnJump()
    {
        //Debug.Log("OnJump");
        if (gameObject.activeSelf && _isReadyToJump && _isGrounded)
        {
            _isReadyToJump = false;
            GetJump();

            Invoke(nameof(ResetJump), _jumpCooldown);
        }
    }

    private void GetJump()
    {
        _rBody.velocity = new Vector3(_rBody.velocity.x,0f,_rBody.velocity.z);
        _rBody.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        _isReadyToJump = true;
    }

    

    private void FixedUpdate()
    {
        MovePlayerFixedUpd();
    }


    private void MovePlayerFixedUpd()
    {
        _moveDirection = _orientation.forward * _verticalInput + _orientation.right * _horizontalInput;
        if (_isGrounded)
        {
            _rBody.AddForce(_moveDirection.normalized * _moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            _rBody.AddForce(_moveDirection.normalized * _moveSpeed * 10f * _airMultiplier, ForceMode.Force);
        }
    }

    public void SetMoveSpeed(float speed)
    { _moveSpeed = speed; }

    public float GetMoveSpeed()
    { return _moveSpeed; }

}
