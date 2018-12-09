using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "My Assets/ConfigurationObject")]

public class ConfigurationScript : ScriptableObject
{
    public static int moneySatisfactionValue = 120;
    public static int heartSatisfactionValue = 150;
    public static int peaceSatisfactionValue = 200;
    public static int rainbowSatisfactionValue = 300;
}
