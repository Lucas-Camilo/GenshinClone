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
            InstanciateSword = Instantiate(currentWeapond, Vector3.zero, Quaternion.identity) as GameObject;
            InstanciateSword.transform.parent = weaponLocaleIdle.transform;
            InstanciateSword.transform.position = Vector3.zero;
            
            PlayerScript = GetComponent<Player>();
        }

        // Update is called once per frame
        void Update()
        {
            if(PlayerScript.Animator.GetBool("isIdling"))
            {
                SetIdleState();
            }
            if(PlayerScript.Animator.GetBool("isAtacking"))
            {
                SetAtackState();
            }
        }

        public void SetIdleState()
        {
            InstanciateSword.transform.parent = weaponLocaleIdle.transform;
            InstanciateSword.transform.position = weaponLocaleIdle.transform.position;
            InstanciateSword.transform.rotation = weaponLocaleIdle.transform.rotation;
        }

        public void SetAtackState()
        {
            InstanciateSword.transform.parent = weaponLocaleAtacking.transform;
            InstanciateSword.transform.position = weaponLocaleAtacking.transform.position;
            InstanciateSword.transform.rotation = weaponLocaleAtacking.transform.rotation;
        }
    }
}
