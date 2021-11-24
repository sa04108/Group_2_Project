using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SearchPoint : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Golem_FSM golem_FSM = animator.gameObject.GetComponent<Golem_FSM>();
        golem_FSM.SetNextPoint();
    }
}
