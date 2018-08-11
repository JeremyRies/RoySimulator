using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Controller : MonoBehaviour
{



    #region Input
    protected Func<bool> OnDefense;
    protected Func<bool> OnDefenseHold;
    protected Func<bool> OnBump;
    protected Func<bool> OnBumpHold;


    public Func<bool> IsHoldingInteraction
    {
        get
        {
            if (OnDefenseHold != null)
                return OnDefenseHold;
            else
                return () => { return true; };
        }
    }
    public Func<bool> IsHoldingSabotage
    {
        get
        {
            if (OnBumpHold != null)
                return OnBumpHold;
            else
                return () => { return true; };
        }
    }

    
    #endregion
    



    protected virtual void FixedUpdate()
    {
        UpdateInput();
    }
    

    protected virtual void UpdateInput()
    {

     
    }

   
}
