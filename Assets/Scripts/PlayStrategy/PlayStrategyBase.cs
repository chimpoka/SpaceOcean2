using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class PlayStrategyBase
{
    protected int CurrentScore;
    protected int BestScore;
    protected int CurrentHealth;
    protected int MaxHealth;
    protected RocketController RocketController;

    abstract public void Update();
}
