using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets._Scripts.Custom_Character
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get 
            {
                if (instance == null)
                    instance = new GameObject().GetComponent<T>();
                return instance;
            }   
        }

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Other Instance of " + this.GetType().Name + "has been destroyed!");
            }

            instance = this as T;
        }
    }
}