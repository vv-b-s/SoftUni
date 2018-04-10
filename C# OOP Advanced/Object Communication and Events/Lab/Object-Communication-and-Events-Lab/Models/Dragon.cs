using System;
using System.Collections.Generic;

public class Dragon : ObservableTarget
{
    private string id;
    private int hp;
    private int reward;
    private bool eventTriggered;

    private IHandler logChain;
    private List<IObserver> observers;

    public Dragon(string id, int hp, int reward, IHandler logChain)
    {
        this.id = id;
        this.hp = hp;
        this.reward = reward;
        this.observers = new List<IObserver>();

        this.logChain = logChain;
    }

    public bool IsDead { get => this.hp <= 0; }

    public IHandler Handler => this.logChain;

    public void NotifyObservers()
    {
        foreach (var observer in observers)
            observer.Update(this.reward);
    }

    public void ReceiveDamage(int damage)
    {
        if (!this.IsDead)
        {
            this.hp -= damage;
        }

        if (this.IsDead && !eventTriggered)
        {
            NotifyObservers();
            logChain.Handle(LogType.EVENT, $"{this} dies");
            this.eventTriggered = true;
        }
    }

    public void Register(IObserver observer)
    {
        this.observers.Add(observer);
    }

    public override string ToString()
    {
        return this.id;
    }

    public void Unregister(IObserver observer)
    {
        this.observers.Remove(observer);
    }
}
