using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/ConfigurationObject")]

public class ConfigurationScript : ScriptableObject
{
    public static int moneySatisfactionValue = 20;
    public static int heartSatisfactionValue = 30;
    public static int peaceSatisfactionValue = 40;
    public static int rainbowSatisfactionValue = 50;
}
