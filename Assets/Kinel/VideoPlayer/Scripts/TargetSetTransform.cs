
using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;

public class TargetSetTransform : UdonSharpBehaviour
{
    public GameObject targetObject;
    public GameObject toTransformObject;
    [SerializeField] private Animator animator;

    public void FixedUpdate()
    {
        if (targetObject.transform.position == toTransformObject.transform.position && targetObject.transform.rotation == toTransformObject.transform.rotation)
        {
            animator.SetInteger("TabletTransform", 0);
        }
        else
        {
            animator.SetInteger("TabletTransform", 1);
        }
    }

    public void Move()
    {
        targetObject.transform.position = toTransformObject.transform.position;
        targetObject.transform.rotation = toTransformObject.transform.rotation;
    }
    
}
