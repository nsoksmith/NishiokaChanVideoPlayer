
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class ToggleMuteIcon : UdonSharpBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private Image unMuteIcon;
    [SerializeField] private Image volumeSliderFill;

    public void ToggleMuteImage()
    {
        unMuteIcon.enabled = !toggle.isOn;
        volumeSliderFill.enabled = !toggle.isOn;
    }

}
