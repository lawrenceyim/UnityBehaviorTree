using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorTreeExample : MonoBehaviour
{
    private BehaviorTree behaviorTree;
    [SerializeField] bool enemyVisible;
    [SerializeField] bool inShootingRange;
    [SerializeField] bool inMeleeRange;
    [SerializeField] bool hasAmmo;

    void Start()
    {
        InitializeBehaviorTree();
    }

    private void InitializeBehaviorTree()
    {
        behaviorTree = new BehaviorTree();
        BooleanNode parentNode = new BooleanNodeBuilder()
            .SetCondition(() => enemyVisible)
            .SetTrueNode(new BooleanNodeBuilder()
                .SetCondition(() => inShootingRange)
                .SetTrueNode(new BooleanNodeBuilder()
                    .SetCondition(() => hasAmmo)
                    .SetTrueNode(new BehaviorNode(() => Debug.Log("Shoot the enemy.")))
                    .SetFalseNode(new BooleanNodeBuilder()
                        .SetCondition(() => inMeleeRange)
                        .SetTrueNode(new BehaviorNode(() => Debug.Log("Melee the enemy.")))
                        .SetFalseNode(new BehaviorNode(() => Debug.Log("Move into melee range.")))
                        .Build())
                    .Build())
                .SetFalseNode(new BehaviorNode(() => Debug.Log("Move into shooting range.")))
                .Build()
            )
            .SetFalseNode(new BehaviorNode(() => Debug.Log("No enemy in sight.")))
            .Build();
        behaviorTree.SetParentNode(parentNode);
        behaviorTree.ValidateTree();
        behaviorTree.Behave();
    }

    void Update()
    {
        behaviorTree.Behave();
    }
}
