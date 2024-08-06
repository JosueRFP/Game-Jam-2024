using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPoints : MonoBehaviour
{
    public static AIPoints Instance;

    public int eviPoints, goodPoints;

    private void Awake()
    {
        Instance = this;
    }


}
