using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class MoveToBasketAT : ActionTask {

        public NavMeshAgent robotNavMeshAgent;
        public BBParameter<string> currentFruitType;
        public BBParameter<Transform[]> basketTarget;
        public BBParameter<Transform> currentTargetPosition;
        public BBParameter<Transform> robotTransform;
        public BBParameter<float> offSet;
        public float distanceFromRobotToTarget;
        public BBParameter<Transform> currentFruitTargetTransform;
        public FruitBasketManager fruitBasketManager;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            // Check what type of fruit the robot is holding

			if (currentFruitType.value == "Apple")
			{
				Debug.Log("Apple!");
                currentTargetPosition.value = basketTarget.value[0].transform;
            }

            if (currentFruitType.value == "Orange")
            {
                Debug.Log("Orange!");
                currentTargetPosition.value = basketTarget.value[1].transform;
            }

            // Set the position for the robot to move to
            NavMeshHit hit;
            NavMesh.SamplePosition(currentTargetPosition.value.position, out hit, 300f, NavMesh.AllAreas);
            robotNavMeshAgent.SetDestination(hit.position);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            distanceFromRobotToTarget = Vector3.Distance(currentTargetPosition.value.position, robotTransform.value.position);

            if (distanceFromRobotToTarget < offSet.value) // When robot reaches to the target's position
            {
                GameObject fruitToDestroy = currentFruitTargetTransform.value.gameObject;
                currentFruitTargetTransform.value = null;


                Object.Destroy(fruitToDestroy); // Destroy the fruit the robot is carrying

                // Put the fruit into the basket

                if (currentFruitType.value == "Apple")
                {
                    fruitBasketManager.AddApple();
                }

                if (currentFruitType.value == "Orange")
                {
                    fruitBasketManager.AddOrange();
                }

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