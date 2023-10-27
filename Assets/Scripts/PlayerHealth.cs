using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 3;
    public float currentHealth;
    public UpdateHealth healthCanvas;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth += damage;

        if (currentHealth >= maxHealth)
            currentHealth = maxHealth;

        healthCanvas.ActualizarValores();

        if (currentHealth <= 0)
        {
            PlayerController.player.animatorBody.SetTrigger("death");
            PlayerController.player.SetIsActive(false);
            Invoke("Die", 3f);
        }
    }

    void Die()
    {
        SceneManager.LoadScene(0);
    }
}
