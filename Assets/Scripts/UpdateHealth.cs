using System.Collections.Generic;
using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    public List<Transform> healthImages = new List<Transform>();

    public void ActualizarValores()
    {
        foreach (var item in healthImages)
        {
            item.gameObject.SetActive(false);
        }

        for (int i = 0; i < PlayerController.player.GetComponent<PlayerHealth>().currentHealth; i++)
        {
            healthImages[i].gameObject.SetActive(true);
        }
    }
}
