using UnityEngine;

public class RingLimit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerController.player.transform.position = new Vector3(0f, 0.2f, 0f);
        }
    }
}
