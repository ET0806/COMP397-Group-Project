using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Cameras : MonoBehaviour
{
    public Transform target;
	public Vector3 offset;


    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.paused)
        {
            
            transform.position = target.position;
        }
        else
        {
            transform.position = target.position + offset;
        }
    }
}

