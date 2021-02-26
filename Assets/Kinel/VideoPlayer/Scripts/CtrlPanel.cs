
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;
using UnityEngine.UI;

public class CtrlPanel : UdonSharpBehaviour
{
    [SerializeField] private Toggle toggle;
    [SerializeField] private GameObject target;

    public void ToggleCtrlPanel()
    {
        target.SetActive(!toggle.isOn);
    }
}