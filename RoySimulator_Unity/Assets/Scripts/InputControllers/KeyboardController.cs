using UnityEngine;
using System;

public class KeyboardController : Controller
{
    public Func<bool> OnForward;
    public Func<bool> OnLeft;
    public Func<bool> OnRight;
    public Func<bool> OnBack;

    private void SetControllerID(int cID)
    {
        if (cID == 1)
        {
            OnForward = () => { return Input.GetKey(KeyCode.UpArrow); };
            OnRight = () => { return Input.GetKey(KeyCode.RightArrow); };
            OnLeft = () => { return Input.GetKey(KeyCode.LeftArrow); };
            OnBack = () => { return Input.GetKey(KeyCode.DownArrow); };
            OnDefense = () => { return Input.GetKeyDown(KeyCode.I); };
            OnBump = () => { return Input.GetKeyDown(KeyCode.P); };
            OnDefenseHold = () => { return Input.GetKey(KeyCode.I); };
            OnBumpHold = () => { return Input.GetKey(KeyCode.P); };

        }
        if (cID == 2)
        {
            OnForward = () => { return Input.GetKey(KeyCode.W); };
            OnRight = () => { return Input.GetKey(KeyCode.D); };
            OnLeft = () => { return Input.GetKey(KeyCode.A); };
            OnBack = () => { return Input.GetKey(KeyCode.S); };
            OnDefense = () => { return Input.GetKeyDown(KeyCode.C); };
            OnBump = () => { return Input.GetKeyDown(KeyCode.V); };
            OnDefenseHold = () => { return Input.GetKey(KeyCode.C); };
            OnBumpHold = () => { return Input.GetKey(KeyCode.V); };
        
        }
    }

    protected override void UpdateInput()
    {
        base.UpdateInput();

        if (OnForward.Invoke())
            Debug.Log("arrow up");
        if (OnBack.Invoke())
            Debug.Log("arrow down");
        if (OnLeft.Invoke())
            Debug.Log("arrow left");
        if (OnRight.Invoke())
            Debug.Log("arrow right");

    }
}
