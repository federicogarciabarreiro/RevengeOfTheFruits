using TMPro;
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    private TextMeshProUGUI text;
    private string initialValue = "";
    public string lastValue = "";

    private void OnEnable()
    {
        text = GetComponent<TextMeshProUGUI>();

        if (initialValue == "")
            initialValue = text.text;
    }
    void Start()
    {
        UpdateValue(0);
    }

    public void UpdateValue(int amount)
    {
        text.text = initialValue + " " + amount + lastValue;
    }
}
