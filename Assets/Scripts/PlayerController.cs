using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController player;

    public float moveSpeed = 5f;
    public float rotationSpeed = 5f;
    public GameObject projectilePrefab;
    public Transform projectileSpawnPoint;
    public Animator animatorBody;

    private Rigidbody rb;
    private bool isActive = false;

    public void SetIsActive(bool b)
    {
        isActive = b;
    }

    private void Awake()
    {
        player = this;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (isActive)
        {
            Vector3 moveDirection = Vector3.zero;

            if (Input.GetKey(KeyCode.W))
            {
                moveDirection += Camera.main.transform.forward;
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection -= Camera.main.transform.forward;
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection -= Camera.main.transform.right;
            }
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection += Camera.main.transform.right;
            }

            if (moveDirection != Vector3.zero)
            {
                animatorBody.SetBool("run", true);
                moveDirection.y = 0;
                moveDirection.Normalize();
                rb.velocity = moveDirection * moveSpeed;
            }
            else
            {
                animatorBody.SetBool("run", false);
                rb.velocity = Vector3.zero;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 cursorPosition = hit.point;
                cursorPosition.y = transform.position.y;

                Vector3 lookDirection = cursorPosition - transform.position;
                lookDirection.y = 0;
                if (lookDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection);
                    rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                }
            }

            if (Input.GetMouseButtonDown(0))
            {
                animatorBody.SetTrigger("shoot");
                ShootProjectile();
            }
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.AddForce(projectileSpawnPoint.forward * 10f, ForceMode.Impulse);
        Destroy(projectile, 2f);
    }
}
