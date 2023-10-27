using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BodyManager : MonoBehaviour
{
    public List<Transform> types = new List<Transform>();

    private void OnEnable()
    {
        foreach (var item in types)
        {
            item.gameObject.SetActive(false);
        }

        Shuffle(types);

        if (types.Count > 0)
        {
            types[0].gameObject.SetActive(true);
        }
    }

    void Shuffle<T>(List<T> list)
    {
        System.Random rand = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rand.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
