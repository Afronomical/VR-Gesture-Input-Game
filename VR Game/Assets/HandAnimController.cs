using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimController : MonoBehaviour
{
    public Animator lAnimator;
    public Animator rAnimator;

    public InputAction lThumb, rThumb;
    public InputAction lIndex, rIndex;
    public InputAction lGrip, rGrip;

    // Update is called once per frame
    void Update()
    {
        lAnimator.SetBool("thumbPressed", lThumb.IsPressed());
        rAnimator.SetBool("thumbPressed", rThumb.IsPressed());

        lAnimator.SetBool("indexPressed", lIndex.IsPressed());
        rAnimator.SetBool("indexPressed", rIndex.IsPressed());

        lAnimator.SetBool("gripPressed", lGrip.IsPressed());
        rAnimator.SetBool("gripPressed", rGrip.IsPressed());
    }
}
