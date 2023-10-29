using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //https://www.youtube.com/watch?v=f473C43s8nE
    //- связь полей через общую ссылку на приравненные Transform
    //orientation у него конечно ещё страннее
    [Header("Movement")]
    public float MoveSpeed;
    [SerializeField] private PlayerCamera OrientationCamera;
    private Transform _orientation => OrientationCamera.Orientation;
    float _horizontalInput;
    float _verticalInput;
    Vector3 _moveDirection;
    [SerializeField] private Rigidbody _rBody;

    [Header("Jump")]
    public KeyCode jumpKey = KeyCode.Space;
    public float JumpForce = 12;
    public float JumpCooldown = 0.25f;
    public float AirMultiplier = 0.4f;
    public bool IsReadyToJump = true;


    [Header("Ground Check")]
    public float PlayerHeight = 2f;
    public LayerMask GroundMask;
    bool _isGrounded;
    public float GroundDrag = 5f;

    private void Start()
    {
        _rBody.freezeRotation = true;
    }

    private void Update()
    {
        SetIsGroundedUpd();
        SetInputUpd();
        SetInputJumpUpd();
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
        _rBody.velocity = _rBody.velocity.sqrMagnitude > MoveSpeed * MoveSpeed ? _rBody.velocity.normalized * MoveSpeed : _rBody.velocity;
    }

    private void SetInputJumpUpd()
    {
        if(Input.GetKey(jumpKey) && IsReadyToJump && _isGrounded)
        {
            IsReadyToJump = false;
            GetJump();

            Invoke(nameof(ResetJump), JumpCooldown);
        }
    }

    private void GetJump()
    {
        _rBody.velocity = new Vector3(_rBody.velocity.x,0f,_rBody.velocity.z);
        _rBody.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        IsReadyToJump = true;
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
            _rBody.AddForce(_moveDirection.normalized * MoveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            _rBody.AddForce(_moveDirection.normalized * MoveSpeed * 10f * AirMultiplier, ForceMode.Force);
        }
    }

}
