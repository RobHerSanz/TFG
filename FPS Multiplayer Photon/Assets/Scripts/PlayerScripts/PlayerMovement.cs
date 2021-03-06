﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private PhotonView PV;
    private CharacterController myCC;
    public Camera myCamera;
    public float movementSpeed;
    public float rotationSpeed;
    public float gravity;
    public float jumpForce;
    private float vSpeed;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
        myCC = GetComponent<CharacterController>();
        menu = GameObject.FindWithTag("PlayerMenu");
        menu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            BasicMovement();
            BasicRotation();
            

        }
    }
    void BasicMovement()
    {
        if (!PhotonRoom.InMenu)
        {
            if (Input.GetKey(KeyCode.W))
            {
                myCC.Move(transform.forward * Time.deltaTime * movementSpeed);
            }

            if (Input.GetKey(KeyCode.A))
            {
                myCC.Move(-transform.right * Time.deltaTime * movementSpeed);
            }

            if (Input.GetKey(KeyCode.S))
            {
                myCC.Move(-transform.forward * Time.deltaTime * movementSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                myCC.Move(transform.right * Time.deltaTime * movementSpeed);
            }

            if (myCC.isGrounded)
            {
                vSpeed = -1;
                if (Input.GetKey(KeyCode.Space))
                {
                    vSpeed = jumpForce;
                }
            }
            vSpeed -= gravity * Time.deltaTime;
            myCC.Move(transform.up * Time.deltaTime * vSpeed);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            showPlayerMenu();
        }

    }
    void BasicRotation()
    {
        if (!PhotonRoom.InMenu)
        {
            float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;

            float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;

            transform.Rotate(new Vector3(0, mouseX, 0));
            if (mouseY < 90 && mouseY > -90)
            {
                myCamera.transform.Rotate(new Vector3(-mouseY, 0, 0));
            }
        }
        
        
    }
    void showPlayerMenu()
    {
        
        if (PhotonRoom.InMenu)
        {
           PhotonRoom.InMenu = false;   
           menu.SetActive(false);
        }
        else
        {
            PhotonRoom.InMenu = true;
            menu.SetActive(true);
        }
            
    }
}
