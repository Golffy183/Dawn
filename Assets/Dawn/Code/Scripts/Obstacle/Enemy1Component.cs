using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace GameDev4.Dawn
{
    public class Enemy1Component : MonoBehaviour, IInteractable, IActorEnterExitHandler
    {
        [SerializeField] private PlayerHP playerHP;
        protected bool isDestroyed = false;

        public void Interact(GameObject actor)
        {

        }

        public void ActorEnter(GameObject actor)
        {
            ObstacleTypeComponent otc = GetComponent<ObstacleTypeComponent>();
            if (otc != null)
            {
                switch (otc.Type)
                {
                    case ObstacleType.hpMinus1:
                        playerHP.TakeDamage(1);
                        isDestroyed = true;
                        break;
                }
            }

            DestroyObject();
        }

        public void ActorExit(GameObject actor)
        {

        }

        public void DestroyObject()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (isDestroyed)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
            }
        }
    }
}