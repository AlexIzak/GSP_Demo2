using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    private float speed = 2f;
    private float vertical;
    private float horizontal;
    [SerializeField] private Rigidbody rb;

    [Header("Camera")]
    private float mouseX;
    private float mouseY;
    private float xRot;
    private float yRot;
    private float rotLimit = 80f;
    public Image reticle;

    public Transform orientation;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Make the cursor stay in the centre of the screen and invisible
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        reticle.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = Input.GetAxisRaw("Mouse Y");

        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");

        //Shows the player that they clicked - also useful for debugging
        if(Input.GetMouseButton(0))
        {
            reticle.color = Color.red;
        }
        else
        {
            reticle.color = Color.white;
        }

        if(Input.GetKey(KeyCode.I))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        RotateToCamera();

        PlayerMovement();
    }

    private void RotateToCamera()
    {

        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot, -rotLimit, rotLimit);

        orientation.rotation = Quaternion.Euler(xRot, yRot, 0); //Rotate camera
        transform.rotation = Quaternion.Euler(0, yRot, 0); //Rotate player to camera orientation
    }

    private void PlayerMovement()
    {
        Vector3 moveVec = Vector3.zero;

        moveVec += transform.forward * vertical;
        moveVec += transform.right * horizontal;
        moveVec = moveVec.normalized * speed;

        rb.velocity = new Vector3(moveVec.x, rb.velocity.y, moveVec.z);
    }
}
