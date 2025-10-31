using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float speed = 12;

    Vector3 velocity;

    CharacterController characterController;

    [SerializeField]
    Transform groundCheck;

    [SerializeField]
    LayerMask groundMask;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        RaycastHit hit;

        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch (terrainType)
            {
                default: speed = 12; break;
                case "Slow": speed = 2; break;
                case "Fast": speed = 36; break;
            }
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = x * transform.right + z * transform.forward;

        characterController.Move(move * speed * Time.deltaTime);
    }
}
