using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class PickUpFruitAT : ActionTask {

        public BBParameter<Transform> currentFruitTargetTransform;
        public BBParameter<Transform> robotTransform;
		public float offSet;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			// Set the parent to robot
			currentFruitTargetTransform.value.transform.parent = robotTransform.value.transform;
			// Place the fruit slightly above the robot
			currentFruitTargetTransform.value.position = new Vector3(currentFruitTargetTransform.value.position.x,
																	currentFruitTargetTransform.value.position.y + offSet,
																	currentFruitTargetTransform.value.position.z);
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}