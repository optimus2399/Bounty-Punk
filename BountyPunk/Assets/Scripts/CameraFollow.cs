using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [Header("SetCamera")]
    public float smoothSpeed = 25f;
    public float rotateSpeed = 5f;
    [SerializeField] Transform target;
    public UnityEngine.Vector3 offset;

    [Header("SetBool")]
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = false;
   

    private void Start()
    {
        offset = transform.position - target.position;
    }

    private void LateUpdate()
    {
        UnityEngine.Vector3 newPos = target.position + offset;
        transform.position = UnityEngine.Vector3.Slerp(transform.position, newPos, smoothSpeed);
        if (Input.GetKey(KeyCode.Mouse2))
        {
            if (rotateAroundPlayer)
            {
                UnityEngine.Quaternion camTurnAngle = UnityEngine.Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, 
                    UnityEngine.Vector3.up);
                offset = camTurnAngle * offset;
            }
          

            if (lookAtPlayer || rotateAroundPlayer)
            {
                transform.LookAt(target);
            }
        }

    }
}
