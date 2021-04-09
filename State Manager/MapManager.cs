using System.Collections;
using UnityEngine;
using Assets._Scripts.FSM;
using Assets._Scripts.Server;

namespace Assets._Scripts.State_Manager
{
    [ExecuteInEditMode]
    public class MapManager : MonoBehaviour
    {
        public GameObject player;
        public Vector3 position;

        [Range(500.0f, 10000.0f)]
        public float distance = 500.0f;
        public bool unloade = true;
        public GameObject[] sectors;
        public GameObject[] terrains;
        private float dist;

        void Update()
        {
            LoadTerrain();
        }

        

        void LoadTerrain()
        {
            if (!player)
            {
                player = GameObject.Find("Player(Clone)");
            }
            else
            {
                position = player.transform.position;
            }

            for (int i = 0; i < sectors.Length; i++)
            {
                dist = Vector3.Distance(sectors[i].transform.position, position);
                if (dist > distance)
                {
                    if (unloade)
                    {
                        terrains[i].SetActive(false);
                    }
                }
                else
                {
                    terrains[i].SetActive(true);
                }
            }
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(position, distance);
        }
    }
}