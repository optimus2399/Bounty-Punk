using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] float moveSpeed = 14f;
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] Animator anim;
    [SerializeField] Transform cam;

    [Header("Gun")]
    [SerializeField] float shootRange = 5;
    [SerializeField] float damage = 10;
    [SerializeField] GameObject pistolPrefab;
    [SerializeField] GameObject lineRender;
    [SerializeField] Transform pistolPos;
    [SerializeField] GameObject bulletPos;

    [Header("GunCharge")]
    [SerializeField] Slider GunChargeSlider;
    [SerializeField] float cooldownValue = 100;
    [SerializeField] float cooldownDecreaseValue = 10;
    [SerializeField] float cooldownIncreaseRate = 0.2f;


    //Private DataTypes
    GameObject pistol;
    Rigidbody rb;
    float turnSmoothVelocity;
    Camera mainCamera;
    float rayLenght;
    bool isAiming = false;
    bool isMoving = false;
 
    RaycastHit hit = new RaycastHit();

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        FreezeZrotation();
    }

    void Update()
    {
        Movement();
        CheckAiming();
        IncreaseGunCharge();
    }
    private void FreezeZrotation()
    {
        var rot = transform.rotation.eulerAngles;
        rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
    }

    private void IncreaseGunCharge()
    {
        if (cooldownValue < 100)
        {
            cooldownValue += cooldownDecreaseValue * Time.fixedDeltaTime * cooldownIncreaseRate;
            GunChargeSlider.value = cooldownValue;
        }
    }


    private void CheckAiming()
    {
        SpawnPistol();

        if (pistol)
        {
            ShootRayCast();
        }

        if (isAiming)
        {
            PlayerLookAt();
            if (isMoving)
            {
                anim.SetBool("RunningAim", true);
            }
            else
            {
                anim.SetBool("RunningAim", false);
                anim.SetBool("Aiming", true);
            }
        }
        else if (!isAiming)
        {
            anim.SetBool("Aiming", false);
            anim.SetBool("RunningAim", false);
        }
    }

    private void SpawnPistol()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            pistol = Instantiate(pistolPrefab, pistolPos) as GameObject;

        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            Destroy(pistol);
        }
    }

    private void PlayerLookAt()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }


    private void ShootRayCast()
    {
        if (Physics.Raycast(pistolPos.position, pistolPos.forward))
        {
            Debug.DrawRay(pistolPos.position, pistolPos.forward * shootRange, Color.green);
        }
        if (cooldownValue > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cooldownValue -= cooldownDecreaseValue;
                Instantiate(lineRender, bulletPos.transform.position, bulletPos.transform.rotation);

                if (Physics.Raycast(pistolPos.position, pistolPos.forward, out hit, shootRange))
                {

                    if (hit.transform.tag == "Enemy")
                    {
                        hit.transform.GetComponent<HealthSystem>().DealDamage(damage);

                    }
                }
            }
        }
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        var direction = new Vector3(horizontal, 0f, vertical);

        if (direction.magnitude >= 0.1f)
        {
            isMoving = true;
            PLayerRotaionWithCamera(direction);

            if (!isAiming)
            {
                anim.SetBool("Running", true);
            }
        }
        else
        {
            isMoving = false;
            anim.SetBool("Running", false);
        }
    }

    private void PLayerRotaionWithCamera(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
        Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);
    }
}
