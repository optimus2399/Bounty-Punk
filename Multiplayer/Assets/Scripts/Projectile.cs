using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        var bullet = GetComponent<Rigidbody2D>();
        bullet.velocity = transform.right * projectileSpeed;
    }

    
}
