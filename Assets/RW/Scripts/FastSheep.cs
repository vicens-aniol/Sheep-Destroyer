using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSheep : Sheep
{
    void Awake()
    {
        // Set values specific to fast sheep
        runSpeed = 12.0f; // Faster than regular sheep
        sheepValue = 2; // Worth more points
        sheepColor = Color.red; // Different color to distinguish it
    }
} 