﻿using UnityEngine;
using System.Collections;

namespace Reliquary {
    /// <summary>
    /// Example usage of how a script would get at the data bucket.
    /// </summary>
    [RequireComponent(typeof(ComponentDataBucket))]
    public class ReliquaryBehavior : MonoBehaviour {
        protected ComponentDataBucket dataBucket;

        public virtual void Start() {
            dataBucket = GetComponent<ComponentDataBucket>();
        }

        public T GetBucketComponent<T>() {
            return dataBucket.GetRegisteredComponent<T>();
        }

        public void SetBucketComponent(System.Object bucketComponent) {
            dataBucket.SetComponent(bucketComponent);
        }
    }
}
