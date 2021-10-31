using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class globalvariable : MonoBehaviour
{
    public static float MobModSpeed=1; //Модификатор изменения скорости
    public static bool Earthquake = false;
    public static bool FireDamage = false;
    public static bool online = false;

    private void Start()
    {
        MobModSpeed = 1;
        Earthquake = false;
        FireDamage = false;
    }

}
