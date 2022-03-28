using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
class Mission : ScriptableObject
{
    [SerializeField]
    private Substance[] ingredients;
    [SerializeField]
    private int priz;
    [SerializeField]
    private int delay;
    [SerializeField]
    private int timeToComplete;
    [SerializeField]
    private Substance result;
    private int id;
    public Formula Formula
    {
        get => new Formula(ingredients);
    }
    public int Reward => priz;
    public int Delay => delay;
    public int TimeToComplete => timeToComplete;
    public Substance Result => result;
    public Status Status { get; set; } = Status.active;
    public void SetID(int id)
    {
        this.id = id;
    }
    public override int GetHashCode()
    {
        return id;
    }
}
