using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotation : MonoBehaviour
{
	public Transform cam;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(cam.eulerAngles.x , cam.eulerAngles.y , 0f);
    }
}
