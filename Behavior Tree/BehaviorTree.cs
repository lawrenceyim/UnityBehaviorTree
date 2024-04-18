using UnityEngine;

public class BehaviorTree {
    private Node parentNode;

    public BehaviorTree() { }

    public BehaviorTree(Node parentNode) {
        this.parentNode = parentNode;
    }

    public void SetParentNode(Node node) {
        parentNode = node;
    }

    public void Behave() {
        parentNode.Behave();
    }

    // Throw error if any path does not result in a BehaviorNode or if a node is missing a dependency
    public void ValidateTree() {
        parentNode.ValidateNode();
        Debug.Log("Behavior Tree is valid.");
    }
}
