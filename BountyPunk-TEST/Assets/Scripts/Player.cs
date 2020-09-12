using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] Animator anim;    //Uday noob

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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

        
        if(direction.magnitude >= 0.1f)
        {
            transform.position = new Vector3(newXPos, newYPos, newZPos);
            anim.SetBool("Running", true);
        }
        else
        {
            anim.SetBool("Running", false);
        }
        
    }
    //gg what is up what is up
}
