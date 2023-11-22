using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml;

public class AnimatorTest : MonoBehaviour
{
    public Animator Anim;
    public Rigidbody RBody;
    public LayerMask LMask;
    public bool IsGround;
    public TMP_Text TmpText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    

    private void Update()
    {
        Grounded();
        Jump();
        Move();
    }

    private void Grounded()
    {
        IsGround = Physics.CheckSphere(gameObject.transform.position + Vector3.down, 0.2f, LMask);
    }

    private void OnJump()
    {
        Debug.Log("JJJJump");
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsGround) { RBody.AddForce(Vector3.up * 4, ForceMode.Impulse); }

        Anim.SetBool("Jump", IsGround);
    }
    private void Move()
    {
        float verticalAxis = Input.GetAxisRaw("Horizontal");
        float horizontalAxis = Input.GetAxisRaw("Vertical");

        Vector3 movement = gameObject.transform.forward * horizontalAxis + gameObject.transform.right * verticalAxis ;
        movement.Normalize();

        gameObject.transform.position += movement * 0.04f;

        TmpText.text = "Vertical=" + verticalAxis + ", Horizontal=" + horizontalAxis;

        Anim.SetFloat("Vertical", horizontalAxis);
        Anim.SetFloat("Horizontal", verticalAxis );

    }
}
