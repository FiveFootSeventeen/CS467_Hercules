using UnityEngine;
using System.Collections;
using System.Collections.Generic;


[System.Serializable]

public class ClickController : MonoBehaviour {

	public List<GameObject> effects = new List<GameObject>();
	public int index = 0;
	void Update(){
		
		if (Input.GetMouseButtonDown (0)) {
//			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
//			RaycastHit hit = new RaycastHit ();
//			if(Physics.Raycast(ray, out hit, 100)){
//				Debug.Log (hit.point);
//				ShowTargetEffectObject (effects[index], hit.point);
//
//				index++;
//				if (index >= effects.Count) {
//					index = 0;
//				}
//			}


			Vector3 mousePos = Input.mousePosition;  
			Vector3 targetPos = Camera.main.ScreenToWorldPoint (mousePos);
			targetPos.z = 0;
			ShowTargetEffectObject (effects[index], targetPos);
			index++;
			if (index >= effects.Count) {
				index = 0;
			}
		}

	}

	public void ShowTargetEffectObject(GameObject gameObject, Vector3 targetPos){
		if (gameObject) {
			GameObject effectObject =(GameObject)MonoBehaviour.Instantiate (gameObject, targetPos, Quaternion.identity)as GameObject;
			if(Screen.width/2 - targetPos.x >= 0){
				effectObject.transform.localScale = new Vector3 (-1,1,1);
			}
		}
	}
}
