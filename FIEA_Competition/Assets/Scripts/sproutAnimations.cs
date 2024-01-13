using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sproutAnimations : MonoBehaviour
{
    public Animator animator;
   
    AnimatorStateInfo animStateInfo;
    public float NTime;

    private void Update()
    {
        chooseAnimation();
    }

    public void chooseAnimation()
    {
        animStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        NTime = animStateInfo.normalizedTime;

        if (NTime > 1.0f) 
        { 
            changeAnimation(Random.Range(1,4));
        }
    }

    public void changeAnimation(int state)
    {
        animator.SetInteger("New Int", state);
    }
}
