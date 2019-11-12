using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerometerPlayStrategy : PlayStrategyBase
{
    public AccelerometerPlayStrategy() : base()
    {
        RocketController = new AccelerometerRocketController();
    }

    override public void Update()
    {
        
    }
}
