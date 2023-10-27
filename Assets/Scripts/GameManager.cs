using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float increaseDifficultyInterval = 5f;

    public int enemiesEliminated = 0;
    public int difficulty = 0;

    public UpdateText difficultyText;
    public UpdateText enemiesEliminatedText;

    private void Awake()
    {
        instance = this;
    }

    public void Init()
    {
        StartCoroutine(IncreaseDifficulty());
    }

    IEnumerator IncreaseDifficulty()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseDifficultyInterval);
            difficulty++;
            if (difficultyText != null )
                difficultyText.UpdateValue(difficulty);
        }
    }

    public void AddEliminatedEnemy()
    {
        enemiesEliminated++;
        if (enemiesEliminatedText != null )
        enemiesEliminatedText.UpdateValue(enemiesEliminated);
    }
}
