using UnityEngine;
using UnityEngine.UI;

public class GlassFill : MonoBehaviour
{
    
    [SerializeField] public Image glassFill;
    
    public float fillAmount = 0.0f;
    public float fillSpeed = 0.75f;
    public float maxFill = 1.0f;

    void Start()
    {
        glassFill.type = Image.Type.Filled;
    }

    void Update()
    {
        glassFill.fillAmount = Mathf.Lerp(glassFill.fillAmount, fillAmount, Time.deltaTime * fillSpeed);
    }

    public void AddIngredient()
    {
        if (Globals.minutesToPlay == 0 && Globals.secondsToPlay == 0) return;
        fillAmount += 0.1f;
        if (fillAmount > maxFill)
        {
            fillAmount = maxFill;
        }
    }
}
