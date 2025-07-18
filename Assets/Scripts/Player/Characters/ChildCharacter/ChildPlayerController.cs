using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildPlayerController : MonoBehaviour
{
    [SerializeField] private ChildPlayerBehaviour _childBehaviour;
    [SerializeField] private ClimbDetector _climbDetector;
    private ChildStateMachine _childStateMachine;

    private void Start()
    {
        _childStateMachine = new ChildStateMachine(_childBehaviour, _climbDetector);
        _childStateMachine.Initialize(_childStateMachine.idleState);
    }

    private void Update()
    {
        if (GameStateManager.Instance.IsGamePaused()) return;
        if (_childBehaviour.isInControll)
        {
            _childStateMachine.Update();
            // Detect enter to climb
            if (_climbDetector.CanClimb && Input.GetKeyDown(KeyCode.E))
            {
                _childStateMachine.TransitionTo(_childStateMachine.climbState);
                return;
            }
        }
    }
}
