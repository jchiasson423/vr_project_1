using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Locomotion : MonoBehaviour
{
    public SteamVR_Action_Vector2 joystick;
    public SteamVR_Action_Boolean modeToggle;
    public float speed = 1.0f;
    private CharacterController controller;
    public Transform cameraTransform;
    public Teleport teleport;

    private bool mode = true;
    private bool toggleMem;

    // Start is called before the first frame update
    void Start()
    {
        controller= GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        ModeChange();
        if (!mode)
        {
            Move();
        }
    }

    private void ModeChange()
    {
        if (modeToggle.changed && modeToggle.state)
        {
            mode = !mode;
            teleport.Activate(mode);
            Debug.Log("mode changed");
        }
    }

    private void Move()
    {
        Vector3 joystickMove = joystick.axis.y * Vector3.forward + joystick.axis.x * Vector3.right;
        Vector3 movement = cameraTransform.rotation * (joystickMove * speed * Time.deltaTime);
        movement.y = 0;
        controller.Move(movement);
    }
}
