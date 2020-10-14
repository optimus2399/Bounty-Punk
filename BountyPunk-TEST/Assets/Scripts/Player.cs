using TreeEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Animator anim;    //Uday noob
    [SerializeField] float turnSmoothTime = 0.1f;
    [SerializeField] GameObject pistolPrefab;
    [SerializeField] Transform pistolPos;
    GameObject pistol;
    [SerializeField] GameObject bulletPrefab;
    private float turnSmoothVelocity;
    private Camera mainCamera;
    float rayLenght;
    bool isAiming = false;
    bool isMoving = false;
    


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();

        var rot = transform.rotation.eulerAngles;
        rot.z = 0;
        transform.rotation = Quaternion.Euler(rot);
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckAiming();
        
    }

    private void PlayerLookAt()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x,transform.position.y, pointToLook.z));
        }
    }

    private void CheckAiming()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
            pistol = Instantiate(pistolPrefab,pistolPos) as GameObject;
            
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isAiming = false;
            Destroy(pistol);
        }

        if (pistol)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GameObject bullet = Instantiate(bulletPrefab, pistol.transform.position , pistol.transform.rotation) as GameObject;
            }
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
        else if(!isAiming)
        {
            anim.SetBool("Aiming", false);
            anim.SetBool("RunningAim", false);
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        

        var deltaX = horizontal * Time.deltaTime*moveSpeed;
        var deltaZ = vertical * Time.deltaTime*moveSpeed;

        var newXPos = transform.position.x + deltaX ;
        var newZPos = transform.position.z + deltaZ;
        var newYPos = transform.position.y; 

        var direction = new Vector3(horizontal, 0f, vertical).normalized;
        

        if (direction.magnitude >= 0.1f)
        {
            isMoving = true;
            //player rotation 
            PLayerRotaionWithMovement(direction);

            //player movement and animation.
            transform.position = new Vector3(newXPos, newYPos, newZPos);
            
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

    private void PLayerRotaionWithMovement(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    //gg what is up what is up//
}
