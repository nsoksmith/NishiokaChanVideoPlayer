
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class BlightnessSlider : UdonSharpBehaviour
{
    [SerializeField] private Slider blightnessSlider;
    [SerializeField] private Renderer Screen1;
    [SerializeField] private Renderer Screen2;

    public void ChangeBlightness()
    {
        Screen1.material.SetFloat("_Emission", blightnessSlider.value);
        Screen2.material.SetFloat("_Emission", blightnessSlider.value);
    }
}
