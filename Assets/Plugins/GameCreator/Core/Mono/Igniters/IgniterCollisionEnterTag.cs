namespace GameCreator.Core
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
    using GameCreator.Variables;

    [AddComponentMenu("")]
    public class IgniterCollisionEnterTag : Igniter 
	{
        [TagSelector]
        public string withTag = "";

		#if UNITY_EDITOR
        public new static string NAME = "Object/On Collision Enter with Tag";
		public new static bool REQUIRES_COLLIDER = true;
		#endif

        [Space][VariableFilter(Variable.DataType.GameObject)]
        public VariableProperty storeSelf = new VariableProperty(Variable.VarType.GlobalVariable);

        [Space][VariableFilter(Variable.DataType.GameObject)]
        public VariableProperty storeCollider = new VariableProperty(Variable.VarType.GlobalVariable);

        private void OnCollisionEnter(Collision c)
		{
            if (c.gameObject.CompareTag(this.withTag))
            {
                this.storeSelf.Set(gameObject);
                this.storeCollider.Set(c.gameObject);

                this.ExecuteTrigger(c.gameObject);
            }
		}
	}
}