using UnityEngine;

public class FollowSmoothCamera : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 5.0f;
    public Vector3 offset;

    public float orthographicSize = 2.5f;

    private Camera cam;

    private bool canFollow = false;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    public void SetCanFollow(bool b)
    {
        canFollow = b;
    }

    void LateUpdate()
    {
        if (target != null && canFollow)
        {
            Vector3 targetPosition = target.position + offset;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, orthographicSize, Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}

