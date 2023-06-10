using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalAnimationController : MonoBehaviour
{
    private Animator anim;
    private bool accept_input = true;

    public AnimationClip OrcWalkAnimClip;
    public AnimationClip BreakDanceAnimClip;
    public AnimationClip DiceAnimClip;
    public AnimationClip WalkLeftAnimClip;
    public AnimationClip WalkRightAnimClip;
    public AnimationClip JumpAttackAnimClip;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();

        if(OrcWalkAnimClip != null) {
            AddInputBlockingAnimEndCallback(OrcWalkAnimClip);
            AddInputBlockingAnimEndCallback(BreakDanceAnimClip);
            AddInputBlockingAnimEndCallback(DiceAnimClip);
            AddInputBlockingAnimEndCallback(WalkLeftAnimClip);
            AddInputBlockingAnimEndCallback(WalkRightAnimClip);
            AddInputBlockingAnimEndCallback(JumpAttackAnimClip);
        }
    }

    private void AddInputBlockingAnimEndCallback(AnimationClip clip){
        AnimationEvent animDoneEvent = new AnimationEvent();
        animDoneEvent.time = clip.length;
        animDoneEvent.functionName = "OnInputBlockingAnimationDone";
        clip.AddEvent(animDoneEvent); 
    }

    // Update is called once per frame
    void Update()
    {
        if (accept_input){
            HandleInput();
        }
    }

        private void OnInputBlockingAnimationDone(){
        accept_input = true;
    }
    private void HandleInput()
    {
        if(Input.GetKey(KeyCode.W)) {
           anim.SetTrigger("OrcWalk");
            accept_input = false;
        }

        if(Input.GetKey(KeyCode.A)) {
           anim.SetTrigger("WalkLeft");
            accept_input = false;
        }

            if(Input.GetKey(KeyCode.D)) {
           anim.SetTrigger("WalkRight");
            accept_input = false;
        }

        if(Input.GetKey(KeyCode.F)) {
           anim.SetTrigger("JumpAttack");
            accept_input = false;
        }

        if(Input.GetKey(KeyCode.B)) {
            anim.SetTrigger("BreakDance");
            accept_input = false;
        }

        if(Input.GetKey(KeyCode.V)) {
            anim.SetTrigger("Dice");
            accept_input = false;
        }
    }
}
