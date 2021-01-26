using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnimation : MonoBehaviour
{
    private Animator animatorGO;
    [SerializeField] private Transform handObject;
    [SerializeField] private Transform lookObj;
    [SerializeField] private bool ikActive;


    void Start()
    {
        animatorGO = GetComponent<Animator>();
        ikActive = false;
    }

    void Update()
    {
        var heading = Vector3.Distance(transform.position, lookObj.position);
        if (heading < 5)
        {
            ikActive = true;
        }
        else ikActive = false;
    }

    private void OnAnimatorIK(int layerIndex)
    {

        if (ikActive)
        {
            if (handObject)
            {
                animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
                animatorGO.SetIKPosition(AvatarIKGoal.RightHand, handObject.position);
                animatorGO.SetIKRotation(AvatarIKGoal.RightHand, handObject.rotation);

                //для левой руки
                animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
                animatorGO.SetIKPosition(AvatarIKGoal.LeftHand, handObject.position);
                animatorGO.SetIKRotation(AvatarIKGoal.LeftHand, handObject.rotation);
            }

            if (lookObj)
            {
                animatorGO.SetLookAtWeight(1);
                animatorGO.SetLookAtPosition(lookObj.position);
            }
        }
        else
        {
            animatorGO.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.RightHand, 0);
            animatorGO.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetIKRotationWeight(AvatarIKGoal.LeftHand, 0);
            animatorGO.SetLookAtWeight(0);
        }
    }
}
