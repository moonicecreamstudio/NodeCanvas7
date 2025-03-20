using NodeCanvas.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotScript : MonoBehaviour
{
    public Blackboard robotBlackboard;
    public float batteryCharge;
    public float startingBatteryCharge;
    public float batteryPercentage;
    public Slider sliderUI;
    public void Start()
    {
        batteryCharge = startingBatteryCharge;

        // How to get a blackboard variable from blackboard scripts

        //if (robotBlackboard != null)
        //{
        //    batteryCharge = robotBlackboard.GetVariableValue<float>("batteryCharge");
        //    Debug.Log("Battery Charge: " + batteryCharge);
        //}
        //else
        //{
        //    Debug.LogError("Blackboard not assigned or found!");
        //}
    }

    public void Update()
    {

        // Battery UI elements
        batteryPercentage = (batteryCharge / startingBatteryCharge) * 100;
        sliderUI.value = batteryPercentage;


        if (batteryCharge > 0)
        {
            // Decrease battery
            batteryCharge -= Time.deltaTime;
        }
    }
}

