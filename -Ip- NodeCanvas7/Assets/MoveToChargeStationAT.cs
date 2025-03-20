using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class MoveToChargeStationAT : ActionTask {

        public NavMeshAgent robotNavMeshAgent;
        public BBParameter<Transform> currentTargetPosition;
        public BBParameter<Transform> robotTransform;
        public float distanceFromRobotToTarget;
		public BBParameter<Transform> chargePad;
        public BBParameter<float> offSet;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            // Set the target position to the targetted fruit
            currentTargetPosition = chargePad;

            // Set the position for the robot to move to
            NavMeshHit hit;
            NavMesh.SamplePosition(currentTargetPosition.value.position, out hit, 300f, NavMesh.AllAreas);
            robotNavMeshAgent.SetDestination(hit.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            distanceFromRobotToTarget = Vector3.Distance(currentTargetPosition.value.position, robotTransform.value.position);

            if (distanceFromRobotToTarget < offSet.value) // When robot reaches to the target fruit's position
            {
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