using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    [RequireComponent(typeof(Canvas))]
    public class LoadingView : MonoBehaviour
    {
        private void Awake()
        {
            StartCoroutine(WaitLoad());
        }

        private IEnumerator WaitLoad()
        {
            yield return new WaitForSeconds(2);
            GetComponent<Canvas>().enabled = false;
        }
    }
}
