using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

namespace GameDev4.Dawn
{
    public class CloudBehavior : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject dropPrefab;
        private Transform spawnArea;
        [SerializeField] private float spawnInterval = 1f;

        private void Start()
        {
            spawnArea = this.transform;
            InvokeRepeating("SpawnDrop", 0, spawnInterval);
        }

        private void SpawnDrop()
        {
            if (!PhotonNetwork.IsConnected)
                return;

            Vector3 randomPos = new Vector3(Random.Range(-spawnArea.localScale.x / 2, spawnArea.localScale.x / 2), 0, Random.Range(-spawnArea.localScale.z / 2, spawnArea.localScale.z / 2));
            if (PhotonNetwork.IsMasterClient)
                PhotonNetwork.Instantiate(dropPrefab.name, spawnArea.position + randomPos, Quaternion.identity);
        }
    }
}
