using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneMovement : MonoBehaviour
{
    private Transform Player;

    public float jumpForce = 4;
    public Rigidbody rb;
    public CapsuleCollider playerCollider;

    private bool Lane1 = false;
    private bool Lane2 = true;
    private bool Lane3 = false;

    private void Start()
    {
        Player = GetComponent<Transform>();
        rb = rb == null ? gameObject.GetComponent<Rigidbody>() : rb;
        playerCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Jump();
        if (Lane3 == true && Player.position.z < 1.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane1 == true && Player.position.z > -1.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z <= -0.1f)
        {
            Player.position += new Vector3(0, 0, 10.5f * Time.deltaTime);
        }
        else if (Lane2 == true && Player.position.z >= 0.1f)
        {
            Player.position += new Vector3(0, 0, -10.5f * Time.deltaTime);
        }



        #region ChangeBools
        if (Input.GetKeyDown(KeyCode.D) && Lane3 == false && Lane1 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane2 == true && Player.position.z <= 0.2f)
        {
            Lane1 = true;
            Lane2 = false;
            Lane3 = false;
        }
        else if (Input.GetKeyDown(KeyCode.D) && Lane2 == true && Player.position.z >= -0.2f)
        {
            Lane3 = true;
            Lane1 = false;
            Lane2 = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && Lane1 == false && Lane3 == true)
        {
            Lane2 = true;
            Lane1 = false;
            Lane3 = false;
        }
        #endregion
    }

    private void Jump()
    {
        bool jumpKeyPressed = Input.GetKeyDown(KeyCode.W);
        if (jumpKeyPressed && isGrounded())
        {
            Vector3 jumpVector = Vector3.up * jumpForce;
            jumpVector.x = rb.velocity.x;
            jumpVector.z = rb.velocity.z;
            rb.velocity = jumpVector;
            if (TryGetComponent(out PlayerAudio audio))
            {
                audio.JumpSource.Play();
            }
        }
    }

    private bool isGrounded()
    {
        bool isGrounded = Physics.Raycast(transform.position, -gameObject.transform.up, playerCollider.bounds.extents.y + 0.1f);
        return isGrounded;
    }
}