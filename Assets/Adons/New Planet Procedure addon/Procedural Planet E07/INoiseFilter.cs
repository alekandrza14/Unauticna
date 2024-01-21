using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace na1
{
    public interface INoiseFilter
    {

        float Evaluate(Vector3 point);
    }
}