﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteragivel
{
    public bool interagivel { get; set; }

    void HighLight();
    void DownLight();
    void Interaction();
}
