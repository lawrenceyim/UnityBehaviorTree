using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BooleanNode : Node
{
    private Func<bool> condition;
    private Node trueNode;
    private Node falseNode;

    public BooleanNode() { }

    public BooleanNode(Func<bool> func, Node trueNode, Node falseNode)
    {
        this.condition = func;
        this.trueNode = trueNode;
        this.falseNode = falseNode;
    }

    public void SetCondition(Func<bool> func)
    {
        condition = func;
    }

    public void SetTrueNode(Node trueNode)
    {
        this.trueNode = trueNode;
    }

    public void SetFalseNode(Node falseNode)
    {
        this.falseNode = falseNode;
    }

    public override void Behave()
    {
        (condition() ? trueNode : falseNode).Behave();
    }

    public override void ValidateNode()
    {
        if (condition == null)
        {
            throw new System.NullReferenceException("Condition for the boolean node is null.");
        }
        if (trueNode == null)
        {
            throw new System.NullReferenceException("Child true node for the boolean node is null.");
        }
        if (falseNode == null)
        {
            throw new System.NullReferenceException("Child false node for the boolean node is null.");
        }
        trueNode.ValidateNode();
        falseNode.ValidateNode();
    }


}

public class BooleanNodeBuilder
{
    private Func<bool> condition;
    private Node trueNode;
    private Node falseNode;

    public BooleanNodeBuilder() { }

    public BooleanNodeBuilder SetCondition(Func<bool> condition)
    {
        this.condition = condition;
        return this;
    }

    public BooleanNodeBuilder SetTrueNode(Node trueNode)
    {
        this.trueNode = trueNode;
        return this;
    }

    public BooleanNodeBuilder SetFalseNode(Node falseNode)
    {
        this.falseNode = falseNode;
        return this;
    }

    public BooleanNode Build()
    {
        return new BooleanNode(condition, trueNode, falseNode);
    }
}