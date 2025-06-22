using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MMAR.ScrollSystem.Demo
{
    public class SimpleController : Controller
    {
        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                AddData(new SimpleData("Index " + i));
            }
        }
    }
}