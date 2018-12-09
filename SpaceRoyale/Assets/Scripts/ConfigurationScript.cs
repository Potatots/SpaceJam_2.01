using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/ConfigurationObject")]

public class ConfigurationScript : ScriptableObject
{
    public static int moneySatisfactionValue = 20;
    public static int heartSatisfactionValue = 50;
    public static int peaceSatisfactionValue = 100;
    public static int rainbowSatisfactionValue = 200;
}
