using TMPro;
using UnityEngine;
using UnityEngine.UI;

class IngredientUI : MonoBehaviour
{
    private Image image;
    private TextMeshProUGUI text;
    private Substance substance;
    private void Start()
    {
        text = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        image = GetComponent<Image>();
        text.text = substance.ToString();
    }
    public void SetText(Substance substance)
    {
        this.substance = substance;
    }
    public void Success()
    {
        image.color = new Color(0, 200, 30, 0.5f);
    }
    public void Fail()
    {
        image.color = new Color(0, 0, 0, 0.5f);
    }
}