using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {
	[SerializeField]
	private EventSystem eventSystem;
	[SerializeField]
	private GameObject selectedObject;

	private bool buttonSelected;

	void Update() {
		if (Input.GetAxisRaw("Vertical") != 0 && buttonSelected == false){
			eventSystem.SetSelectedGameObject(selectedObject);
			buttonSelected = true;
		} 
	}

	private void OnDisable() {
		buttonSelected = false;
	}
}
