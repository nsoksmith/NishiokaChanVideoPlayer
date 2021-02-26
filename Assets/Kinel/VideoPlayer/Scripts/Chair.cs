
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using System;
using VRC.SDK3.Components;
using VRC.SDK3.Components.Video;
using VRC.SDK3.Video.Components.Base;
using VRC.Udon.Common.Interfaces;

public class Chair : UdonSharpBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Toggle toggleFront;
    [SerializeField] private GameObject frontChair;
    [SerializeField] private Toggle toggleBack;
    [SerializeField] private GameObject backChair;
    private bool localFrontChair = false;
    private bool localBackChair = false;
    [UdonSynced] private bool grobalFrontChair = false;
    [UdonSynced] private bool grobalBackChair = false;

public void ToggleFrontChair()
    {
        if(Networking.IsMaster == true){
            grobalFrontChair = toggleFront.isOn;
            localFrontChair = toggleFront.isOn;
            frontChair.SetActive(toggleFront.isOn);
            animator.SetBool("ChairFront", toggleFront.isOn);
        }
    }

    public void ToggleBackChair()
    {
        if(Networking.IsMaster == true){
            grobalBackChair = toggleBack.isOn;
            localBackChair = toggleBack.isOn;
            backChair.SetActive(toggleBack.isOn);
            animator.SetBool("ChairBack", toggleBack.isOn);
        }
    }

    public override void OnDeserialization()
        {
            if(localFrontChair != grobalFrontChair){
                localFrontChair = grobalFrontChair;
                toggleFront.isOn = localFrontChair;
                frontChair.SetActive(localFrontChair);
                animator.SetBool("ChairFront", localFrontChair);
            }
            if(localBackChair != grobalBackChair){
                localBackChair = grobalBackChair;
                toggleBack.isOn = localBackChair;
                backChair.SetActive(localBackChair);
                animator.SetBool("ChairBack", localBackChair);
            }
        }
}
