using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XboxController : Controller
{
    private int controllerId = -1;

    public Func<Vector3> GetJoystick;

   

    private void SetControllerID(int cID)
    {
        controllerId = cID;
        OnDefense = () => { return Input.GetButtonDown("A_p" + controllerId); };
        OnBump = () => { return Input.GetButtonDown("B_p" + controllerId); };
        OnDefenseHold = () => { return Input.GetButton("A_p" + controllerId); };
        OnBumpHold = () => { return Input.GetButton("B_p" + controllerId); };
        GetJoystick = () => { return new Vector3(Input.GetAxis("hor" + cID), 0, Input.GetAxis("ver" + cID)); };

    }

 
    protected override void UpdateInput()
    {
        base.UpdateInput();
        
        if (GetJoystick != null)
        {
            Vector3 v = GetJoystick();
            if (v.magnitude > 0.2f)
            {
              
              
            }
        }
      
       

    }
}
