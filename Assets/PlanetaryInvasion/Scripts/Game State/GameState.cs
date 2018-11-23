using System;
using Zenject;

public abstract class GameState : IInitializable
{
    public virtual void OnEnter() { }

    public virtual void Update() { }

    public virtual void OnExit() { }

    public virtual void Initialize() { }
}