﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchscreenPlayStrategy : PlayStrategyBase
{
    public TouchscreenPlayStrategy() : base()
    {
        RocketController = new TouchscreenRocketController();
    }

    override public void Update()
    {

    }
}
