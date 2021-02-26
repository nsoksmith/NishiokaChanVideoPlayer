
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ToggleBlightIcon : UdonSharpBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Image blightIcon;
    [SerializeField] private Image blightSliderFill;
    [SerializeField] private Renderer Screen1;
    [SerializeField] private Renderer Screen2;
    private int isBlack;

    public void ToggleBlightImage()
    {
        blightIcon.enabled = !toggle.isOn;
        blightSliderFill.enabled = !toggle.isOn;
        if (toggle.isOn == true){
            isBlack = 1;
        }else{
            isBlack = 0;
        }
        Screen1.material.SetFloat("_isBlack", isBlack);
        Screen2.material.SetFloat("_isBlack", isBlack);

    }

}
