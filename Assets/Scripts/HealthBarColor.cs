using UnityEngine;
using UnityEngine.UI;

public class HealthBarColor : MonoBehaviour
{
    public Slider healthBarSlider;
    public Image fillImage;

    void Update()
    {
        float healthPercentage = healthBarSlider.value / healthBarSlider.maxValue;
        
        //find the color between red and green based on the health percentage
        fillImage.color = Color.Lerp(Color.red, Color.green, healthPercentage);
    }
}