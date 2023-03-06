using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Descending.Units;
using UnityEngine;
using UnityEditor;

namespace Descending.Core
{
    public static class Utilities
    {
        public static bool IsMouseInWindow()
        {
#if UNITY_EDITOR
            if (Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1 ||
                Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1)
            {
                return false;
            }
#else
            if (Input.mousePosition.x <= 0 || Input.mousePosition.y <= 0 || Input.mousePosition.x >= Screen.width - 1 ||
                Input.mousePosition.y >= Screen.height - 1)
            {
                return false;
            }
#endif
            else
            {
                return true;
            }
        }
        
        public static bool IsInRange(Vector3 origin, Vector3 target, float range)
        {
            return Vector3.Distance(origin, target) <= range;
        }
        
        public static TValue RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            List<TValue> values = Enumerable.ToList(dict.Values);

            int size = dict.Count;

            return values[Random.Range(0, size)];
        }

        public static TKey RandomKey<TKey, TValue>(IDictionary<TKey, TValue> dict)
        {
            List<TKey> keys = Enumerable.ToList(dict.Keys);

            int size = dict.Count;

            return keys[Random.Range(0, size)];
        }

        public static T FindClosestObj<T>(Transform origin, float range) where T : MonoBehaviour
        {
            Collider[] collidersInRange = Physics.OverlapSphere(origin.position, range);
            List<T> objList = new List<T>();
            for (int i = 0; i < collidersInRange.Length; i++)
            {
                T obj = collidersInRange[i].GetComponent<T>();
                if (obj != null)
                    objList.Add(obj);
            }

            objList.Sort((a, b) =>
            {
                float distA = Vector3.SqrMagnitude(origin.position - a.transform.position);
                float distB = Vector3.SqrMagnitude(origin.position - b.transform.position);
                if (distA < distB)
                    return -1;
                else if (distA == distB)
                    return 0;
                else return 1;
            }
            );

            if (objList.Count == 0)
                return null;
            else
                return objList[0];
        }

        public static Transform FindClosestObj(Transform origin, float range, string tag)
        {
            Collider[] collidersInRange = Physics.OverlapSphere(origin.position, range);
            List<Transform> objList = new List<Transform>();
            for (int i = 0; i < collidersInRange.Length; i++)
            {
                Transform obj = collidersInRange[i].transform;
                if (obj.tag.Equals(tag) && obj.transform != origin.transform)
                    objList.Add(obj);
            }

            objList.Sort((a, b) =>
            {
                float distA = Vector3.SqrMagnitude(origin.position - a.transform.position);
                float distB = Vector3.SqrMagnitude(origin.position - b.transform.position);
                if (distA < distB)
                    return -1;
                else if (distA == distB)
                    return 0;
                else return 1;
            }
            );

            if (objList.Count == 0)
                return null;
            else
                return objList[0];
        }

        public static Vector3 GetRandomPosition(Vector3 position, float range)
        {
            float x = Random.Range(-range, range);
            float z = Random.Range(-range, range);

            return new Vector3(position.x + x, position.y, position.z + z);
        }

        public static void ClearTransform(this Transform transform)
        {
            if (transform == null)
            {
                return;
            }

            foreach (Transform child in transform)
            {
                GameObject.Destroy(child.gameObject);
            }
        }

        public static Genders GetRandomGender()
        {
            if (Random.Range(0, 100) > 50)
            {
                return Genders.Male;
            }
            else
            {
                return Genders.Female;
            }
        }

        private static System.Random rng = new System.Random();
        
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }
        
        public static void Exit()
        {
#if UNITY_STANDALONE
            Application.Quit();
#endif
 
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }

        public static void PlayParticleSystem(GameObject prefab, Vector3 position, Quaternion rotation, Transform lookAt)
        {
            ParticleSystem ps = GameObject.Instantiate(prefab, position, rotation).GetComponent<ParticleSystem>();
            if (lookAt != null) ps.transform.LookAt(lookAt);
            
            ps.Play();
            GameObject.Destroy(ps.gameObject, ps.main.duration);
        }
    }
}