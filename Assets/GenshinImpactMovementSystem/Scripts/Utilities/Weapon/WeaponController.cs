using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GenshinImpactMovementSystem
{
    public class WeaponController : MonoBehaviour
    {
        public GameObject currentWeapond;

        public GameObject weaponLocaleAtacking;
        public GameObject weaponLocaleIdle;

        private GameObject InstanciateSword;
        private Player PlayerScript;
        [Header("In Atack Config")]
        public Vector3 InAtackPosition;
        public Vector3 InAtackRotation;
        [Header("In Idle Config")]
        public Vector3 InIdlePosition;
        public Quaternion InIdleRotation;

        // Start is called before the first frame update
        void Start()
        {
            InstanciateSword = Instantiate(currentWeapond, new Vector3(0,0,0), Quaternion.identity);
            InstanciateSword.transform.parent = weaponLocaleIdle.transform;
            InstanciateSword.transform.transform.position = new Vector3(0, 0, 0);
            
            PlayerScript = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            SetIdleState();
        }

        public void SetIdleState()
        {
            InstanciateSword.transform.parent = weaponLocaleIdle.transform;
            //InstanciateSword.transform.transform.position = InIdlePosition;
            InstanciateSword.transform.rotation = InIdleRotation;
        }
    }
}
