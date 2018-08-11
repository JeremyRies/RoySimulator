using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPerspectiveHelper : MonoBehaviour
{

	[SerializeField] private Transform[] _perspectives;
	[SerializeField] private Transform _cameraTransform;

	private int _perspectiveIndex;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
		{
			NextPerspective();
		}
	}

	private void NextPerspective()
	{
		var perspective = _perspectives[_perspectiveIndex++ % _perspectives.Length];
		_cameraTransform.position = perspective.position;
		_cameraTransform.rotation = perspective.rotation;
	}
}
