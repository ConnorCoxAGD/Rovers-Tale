using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantRotation : MonoBehaviour
{
    public float x = 0;
    public float y = 0;
    public float z = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(x, y, z, Space.Self);
    }
}
