using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerBehaviour : MonoBehaviour
{
	private enum PlayerStates
	{
		Spawning,
		Moving,
		Falling,
		OnGround,
		StandingUp,
	}

	[SerializeField] private Transform _body;
	[SerializeField] private Transform _bottomAnchor;

	[SerializeField] private float _acceleration;
	[SerializeField] private float _criticalFallingSpeed;

	[SerializeField] private Text _debugStateText;
	
	private float _speed;
	private PlayerStates _state = PlayerStates.Moving;

	[SerializeField] private Dictionary<PlayerStates,float> _durationForState;
	private Dictionary<PlayerStates,float> _currentTimeInState = new Dictionary<PlayerStates, float>();
	
	void Update ()
	{
		_debugStateText.text = _state.ToString();
//		_currentTimeInState[_state] += Time.deltaTime;
			
		switch (_state)
		{
			case PlayerStates.Spawning:
				HandleSpawning();
				break;
			case PlayerStates.Moving:
				HandleMoving();
				break;
			case PlayerStates.Falling:
				HandleFalling();
				break;
			case PlayerStates.OnGround:
				break;
			case PlayerStates.StandingUp:
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
		
	}

	private PlayerStates State { get; }
	

	private void HandleSpawning()
	{
		//todo play falling animation
		_state = PlayerStates.Moving;
	}

	private void HandleFalling()
	{
		//todo play falling animation
	}

	private void HandleMoving()
	{
		var xinput = Input.GetAxis("Horizontal");
        		
		_bottomAnchor.localRotation = Quaternion.AngleAxis(-xinput *50, new Vector3(0,0,1));

		_speed += xinput * _acceleration;
		_body.transform.position += Vector3.right * _speed;

		if (_speed > _criticalFallingSpeed)
		{
			_state = PlayerStates.Falling;
		}
	}
}
