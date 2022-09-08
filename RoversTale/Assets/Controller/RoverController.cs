using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the main character rover. It will do so by manipulating the various parts of the rover. 
/// Example: movement X will rotation the front wheel axles, and movement Y will spin wheels forward or backwards.
/// </summary>
public class RoverController : MonoBehaviour
{
    InputInterpreter _in;

    public float wheelSpeed = 15;
    public float turnSpeed = 15;
    Vector3 direction;

    private void Awake() {
        _in = GetComponent<InputInterpreter>();
    }

    private void Update() {
        Movement();
    }

    public void Movement(){
        direction = _in.m_movement;

        Vector3 translation = new Vector3(0,0, direction.y * wheelSpeed);
        transform.Translate(translation * Time.deltaTime);
        float rotationY = direction.x * turnSpeed * Time.deltaTime;
        transform.Rotate(0, rotationY, 0);
        
    }
}
