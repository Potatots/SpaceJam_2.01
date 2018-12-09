using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/ConfigurationObject")]

public class ConfigurationScript : ScriptableObject
{
    public static int moneySatisfactionValue = 180;
    public static int heartSatisfactionValue = 210;
    public static int peaceSatisfactionValue = 260;
    public static int rainbowSatisfactionValue = 360;
}
