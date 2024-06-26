﻿using Third_Party._3rd_Party.Joystick_Pack.Scripts.Joysticks;
using UnityEngine;

namespace Third_Party._3rd_Party.Joystick_Pack.Examples
{
    public class JoystickPlayerExample : MonoBehaviour
    {
        public float speed;
        public VariableJoystick variableJoystick;
        public Rigidbody rb;

        public void FixedUpdate()
        {
            Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
            rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        }
    }
}