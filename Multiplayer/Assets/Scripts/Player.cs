using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //prameters
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float bulletDestroyTime = 4f;
    
    bool isGrounded = true;
    bool turn = true;
    //bool isShooting = false;

    //cached refrence
    private PlayerController playerController;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    BoxCollider2D feet;
    Animator anim;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform gun;
    
    
    private void Awake()
    {
        playerController = new PlayerController();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        feet = GetComponent<BoxCollider2D>();
    }

    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    //start 
    void Start()
    {
        playerController.Movement.Jump.performed += _ => Jump();
        playerController.Movement.Shoot.started += _ => Shoot();
        playerController.Movement.Shoot.canceled += _ => StopShoot();


    }

    //update 
    void Update()
    {
        Move();
        GroundCheck();
    }

    private void Shoot()
    {
        StartCoroutine(DestroyBullet());
        anim.SetBool("isShooting", true);
    }

    private void StopShoot()
    {
        anim.SetBool("isShooting", false);
    }
   

    void Jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void Move()
    {

        //move player
        float movementInput = playerController.Movement.Move.ReadValue<float>();

        anim.SetFloat("Speed", Mathf.Abs(movementInput));

        Vector2 currentPos = transform.position;
        currentPos.x += movementInput * moveSpeed * Time.deltaTime;
        transform.position = currentPos;
        FlipPlayer(movementInput);

    }

    private void FlipPlayer(float movementInput)
    {
        //flip player
        if (movementInput == -1 && turn == true)
        {
            transform.Rotate(0f, 180f, 0f);
            turn = false;
        }
        else if (movementInput == 1 && turn == false)
        {
            transform.Rotate(0f, -180f, 0f);
            turn = true;
        }
    }

    public void GroundCheck()
    {
        if (!feet.IsTouchingLayers(LayerMask.GetMask("ground")))
        {
            isGrounded = false;
            anim.SetBool("isFalling", true);
            
        }
        else
        {
            isGrounded = true;
            anim.SetBool("isFalling", false);
        }
    }

    IEnumerator DestroyBullet()
    {
        GameObject laser = Instantiate(bulletPrefab, gun.position, gun.rotation) as GameObject;
        yield return new WaitForSeconds(bulletDestroyTime);
        Destroy(laser);
        
    }
   
}
