using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

namespace GenshinImpactMovementSystem
{
    public class CharacterManager : MonoBehaviour
    {
        [field: Header("Characters")]
        [field: SerializeField] public List<Character> characters;
        public CharacterManagerController InputActions { get; private set; }
        public GameObject Player;
        public CinemachineVirtualCamera cinemachineVirtual;

        private GameObject[] players = { };

        private void Awake()
        {
            InputActions = new CharacterManagerController();
            players = GameObject.FindGameObjectsWithTag("Player");
            Player = players[1];
            for(int i = 0; i < players.Length; i++)
            {
                characters.Add(new Character(players[i].name, players[i]));
            }
            /// Order List of Characters by Name
            SetChatacter("1");
            InputActions.SetCharacter.Teclas.performed += ctx => SetChatacter(ctx.control.name);
        }
        public void SetChatacter(string number)
        {
            int tecla = int.Parse(number);
            if (tecla <= characters.Count)
            {
                if(Player == null)
                {
                    Player = GameObject.FindGameObjectWithTag("Player");
                }
                
                Transform playerTransform = Player.transform;
                
                if (Player.name.Equals(characters[int.Parse((tecla).ToString()) - 1].Name))
                {
                }
                else
                {
                    bool inGound = Player.GetComponent<Player>().Animator.GetBool("Grounded");
                    if (inGound) 
                    {
                        Player = players[tecla - 1];
                        DisableNoSelectCharactes();
                        GameObject CameraLookPoint = Player.transform.Find("CameraLookPoint").gameObject;
                        if (CameraLookPoint != null)
                        {
                            cinemachineVirtual.LookAt = CameraLookPoint.transform;
                            cinemachineVirtual.Follow = CameraLookPoint.transform;
                            Player.transform.position = playerTransform.position;
                            Player.transform.rotation = playerTransform.rotation;
                        }
                    }
                    
                    
                }
            }
        }

        public void DisableNoSelectCharactes()
        {
            foreach(GameObject obj in players)
            {
                if(!obj.name.Equals(Player.name))
                {
                    obj.SetActive(false);
                }
                else
                {
                    obj.SetActive(true);
                }
            }
        }

        private void OnEnable()
        {
            InputActions.Enable();
        }

        private void OnDisable()
        {
            InputActions.Disable();
        }
    }
}
