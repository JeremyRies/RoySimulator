using System;
using UnityEngine;

namespace Physics
{
    public class PlayerPhysics
    {
        public float Strength { get; set; }
        public float CriticalAngle { get; set; }

        public PlayerPhysics(float strength = 1, float criticalAngle = 45)
        {
            Strength = strength;
            CriticalAngle = criticalAngle;
        }

        public Vector3 GetTiltForce(float tiltAngle)
        {
            var forceMagnitude = (float) (Math.Pow(CriticalAngle, 2) * Strength * Math.Pow(tiltAngle, 4) - Strength * tiltAngle);
            return Quaternion.Euler(0, tiltAngle, 0) * Vector3.back* forceMagnitude;
        }
    }
}
