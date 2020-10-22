using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    public float smoothSpeed = 25f;
    public UnityEngine.Vector3 offset;
    public bool lookAtPlayer = false;
    public bool rotateAroundPlayer = false;
    public float rotateSpeed = 5f;

    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void Update()
    {
        

    }

    private void LateUpdate()
    {
        UnityEngine.Vector3 newPos = target.position + offset;
        transform.position = UnityEngine.Vector3.Slerp(transform.position, newPos, smoothSpeed);
        if (Input.GetKey(KeyCode.Mouse2))
        {
            if (rotateAroundPlayer)
            {
                UnityEngine.Quaternion camTurnAngle = UnityEngine.Quaternion.AngleAxis(Input.GetAxis("Mouse X") * rotateSpeed, UnityEngine.Vector3.up);
                offset = camTurnAngle * offset;
            }
          

            if (lookAtPlayer || rotateAroundPlayer)
            {
                transform.LookAt(target);
            }
        }

    }
}
