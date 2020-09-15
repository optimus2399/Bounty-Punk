using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Animator anim;    //Uday noob
    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    private Camera mainCamera;
    float rayLenght;
    bool isAiming = false;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (Input.GetMouseButtonDown(1))
        {
            isAiming = true;
        }
        else if(Input.GetMouseButtonUp(1))
        {
            isAiming = false;
        }
        
    }

    private void PlayerLookAt()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

        if (groundPlane.Raycast(cameraRay, out rayLenght))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLenght);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, 0f, pointToLook.z));
        }
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        var deltaX = horizontal * Time.deltaTime*moveSpeed;
        var deltaZ = vertical * Time.deltaTime*moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newZPos = transform.position.z + deltaZ;
        var newYPos = transform.position.y;

        var direction = new Vector3(horizontal, 0f, vertical).normalized;

       
        if (direction.magnitude >= 0.1f)
        {
            
            //player rotation 
            PLayerRotaionWithMovement(direction);

            //player movement and animation.
            transform.position = new Vector3(newXPos, newYPos, newZPos);
            anim.SetBool("Running", true);
            
        }
        else
        {
            anim.SetBool("Running", false);
        }

        if (isAiming)
        {
            PlayerLookAt();
        }
        

        //PlayerLookAt();

    }

    private void PLayerRotaionWithMovement(Vector3 direction)
    {
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
    //gg what is up what is up//
}
