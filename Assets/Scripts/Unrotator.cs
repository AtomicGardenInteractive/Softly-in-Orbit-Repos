using System.Collections;
using System.Collections.Generic;
using UnityEngine;
	public class Unrotator : MonoBehaviour
	{

		void Update()
		{
			
			this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

