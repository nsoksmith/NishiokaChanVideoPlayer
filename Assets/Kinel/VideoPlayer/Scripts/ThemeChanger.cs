
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class ThemeChanger : UdonSharpBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Material skybox1;
    [SerializeField] private Material skybox2;
    [SerializeField] private Material skybox3;
    [SerializeField] private Material skybox4;
    [SerializeField] private Material skybox5;
    [SerializeField] private Material skybox6;
    [SerializeField] private Material skybox7;

    public void setTheme1()
    {
        animator.SetInteger("Theme", 1);
        RenderSettings.skybox = skybox1;
    }

    public void setTheme2()
    {
        animator.SetInteger("Theme", 2);
        RenderSettings.skybox = skybox2;
    }

    public void setTheme3()
    {
        animator.SetInteger("Theme", 3);
        RenderSettings.skybox = skybox3;
    }

    public void setTheme4()
    {
        animator.SetInteger("Theme", 4);
        RenderSettings.skybox = skybox4;
    }

    public void setTheme5()
    {
        animator.SetInteger("Theme", 5);
        RenderSettings.skybox = skybox5;
    }

    public void setTheme6()
    {
        animator.SetInteger("Theme", 6);
        RenderSettings.skybox = skybox6;
    }

    public void setTheme7()
    {
        animator.SetInteger("Theme", 7);
        RenderSettings.skybox = skybox7;
    }
}
