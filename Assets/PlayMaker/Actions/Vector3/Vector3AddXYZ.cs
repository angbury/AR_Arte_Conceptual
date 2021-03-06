// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Vector3)]
	[Tooltip("Adds a XYZ values to Vector3 Variable.")]
	public class Vector3AddXYZ : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
        [Tooltip("The Vector3 Variable to add to.")]
        public FsmVector3 vector3Variable;

        [Tooltip("Add to the X axis.")]
        public FsmFloat addX;

        [Tooltip("Add to the Y axis.")]
        public FsmFloat addY;

        [Tooltip("Add to the Z axis.")]
        public FsmFloat addZ;

        [Tooltip("Repeat every frame.")]
        public bool everyFrame;

        [Tooltip("Add over one second (multiplies values by Time.deltaTime). Note: Needs Every Frame checked.")]
        public bool perSecond;

		public override void Reset()
		{
			vector3Variable = null;
			addX = 0;
			addY = 0;
			addZ = 0;
			everyFrame = false;
			perSecond = false;
		}

		public override void OnEnter()
		{
			DoVector3AddXYZ();
			
			if (!everyFrame)
				Finish();		
		}

		public override void OnUpdate()
		{
			DoVector3AddXYZ();
		}
		
		void DoVector3AddXYZ()
		{
			var vector = new Vector3(addX.Value, addY.Value, addZ.Value);
			
			if(perSecond)
			{
				vector3Variable.Value += vector * Time.deltaTime;
			}
			else
			{
				vector3Variable.Value += vector;
			}
				
		}
	}
}

