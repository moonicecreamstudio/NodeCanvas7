using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class EnergyRechargeAT : ActionTask {

        public RobotScript robotScript;
		public float chargeSpeed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			// Keely said something about putting stuff in OnExecute when doing behaviour trees, however I wouldn't be able to do this Action if it was in OnExecute

			robotScript.batteryCharge += Time.deltaTime * chargeSpeed; // Charge the robot at a set speed

            if (robotScript.batteryCharge >= robotScript.startingBatteryCharge) 
			{
                robotScript.batteryCharge = robotScript.startingBatteryCharge;
                EndAction(true);
            }

		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}