using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GenshinImpactMovementSystem
{
    [Serializable]
    public class Character
    {
        public string Name;
        public GameObject ModelPreFab;

        public Character(string _name, GameObject _model)
        {
            Name = _name;
            ModelPreFab = _model;
        }
    }
}
