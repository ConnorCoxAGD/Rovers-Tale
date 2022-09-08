using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientationLock : MonoBehaviour
{

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
    }
}
