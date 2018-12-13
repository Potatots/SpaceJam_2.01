using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class staticElement : MonoBehaviour {
    public static ReputationManager mang;
    public ReputationManager nonsMang;

    public void Start()
    {
        mang = nonsMang;
    }
    public static void ModifyRep(int k)
    {
        mang.notority += k;
    }

}
