using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    CharacterController controller;
    [SerializeField] Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        ChareterControllerMove();
        //Move();
        anim.SetBool("Running", false);
    }

    private void ChareterControllerMove()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * moveSpeed * Time.deltaTime);
            anim.SetBool("Running", true);
        }
    }

    void Move()
    {
        var deltaX = Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
        var deltaZ = Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;

        var newXPos = transform.position.x + deltaX;
        var newZPos = transform.position.z + deltaZ;

        transform.position = new Vector3(newXPos, 0, newZPos);
        anim.SetFloat("Running", deltaX);
        
    }
}
