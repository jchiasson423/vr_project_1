using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Locomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 joystick;
    public float speed = 1.0f;
    private CharacterController controller;
    public Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 joystickMove = joystick.axis.y * Vector3.forward;
        Vector3 movement = cameraTransform.rotation * (joystickMove * speed * Time.deltaTime);
        movement.y = 0;
        controller.Move(movement);
    }
}
