using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Digital
{
    public interface IWeapon
    {
        MonoBehaviour MonoBehaviour { get; }
        void Action();
    }
}
