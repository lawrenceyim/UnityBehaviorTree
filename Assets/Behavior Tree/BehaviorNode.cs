using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BehaviorNode : Node
{   
    private Action behavior;

    public BehaviorNode() {}

    public BehaviorNode(Action action) {
        this.behavior = action;
    }

    public void SetAction(Action action) {
        this.behavior = action;
    }
    
    public override void Behave() {
        behavior();
    }

    public override void ValidateNode() {
        if (behavior == null) {
            throw new System.NullReferenceException("Behavior for the behavior node is null.");
        }
    }
}
