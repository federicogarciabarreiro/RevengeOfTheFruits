using UnityEngine;
using UnityEngine.Events;

public class EnemyExplosion : MonoBehaviour
{
    public int damage = 1;
    public GameObject particlePrefab;
    public UnityEvent eventoFinal;

    public bool bulletCollisionActivate = true;
    public bool playerCollisionActivate = true;
    public bool isEnemy = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (playerCollisionActivate)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerHealth playerHealth = PlayerController.player.GetComponent<PlayerHealth>();

                if (playerHealth)
                    playerHealth.TakeDamage(damage);

                eventoFinal.Invoke();

                Instantiate(particlePrefab, this.transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }

        if (bulletCollisionActivate)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                if (isEnemy)
                    GameManager.instance.AddEliminatedEnemy();


                eventoFinal.Invoke();

                Instantiate(particlePrefab, this.transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
