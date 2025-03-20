using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class FruitListCT : ConditionTask
	{

		public BBParameter<GameObject> fruitList;
		public BBParameter<Vector3> currentFruitTargetVector3;
		public BBParameter<Transform> currentFruitTargetTransform;
		public BBParameter<string> fruitType;

        public RobotScript robotScript;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
		{
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{

		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable()
		{

		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			if (fruitList.value.transform.childCount > 0 && robotScript.batteryCharge > 30f) // If more than 1 fruit has spawned, and the battery level is above 30
			{
                currentFruitTargetTransform.value = fruitList.value.transform.GetChild(0);
                currentFruitTargetVector3.value = currentFruitTargetTransform.value.position;
				fruitType.value = currentFruitTargetTransform.value.gameObject.tag.ToString();

                return true;
			}
            return false;
        }

	}
}