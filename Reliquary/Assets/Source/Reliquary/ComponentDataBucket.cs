using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Reliquary {
    public class ComponentDataBucket : MonoBehaviour {

        #region Protected Fields
        protected Dictionary<string, System.Object> components;

        private void Start() {
            init();
        }
        #endregion

        #region Public Functions
        //Register a component by the object.
        // We prefer this method because it allows default properties set by a system to be registered
        // with the DataBucket.
        public void RegisterComponent(System.Object componentObject) {
            try {
                components.Add(componentObject.GetType().Name, componentObject);

                Debug.Log("A new component of type " + componentObject.GetType().Name + " was registered for " + gameObject.name);
            } catch (ArgumentException) {
                // Do nothing.
                Debug.LogError("A component of type " + componentObject.GetType().Name + " is already registered in the data bucket.");
            }
        }

        public bool UnregisterComponent<T>() {
            string componentType = typeof(T).Name;
            if(components.ContainsKey(componentType)) {
                return components.Remove(componentType);
            } else {
                return false;
            }
        }

        //Set a component by object.
        // In this case, the componentObject's type is considered to determine the key it belongs to.
        // If the key already exists, it replaces the value in the dictionary.
        // If it doesn't, it registers the new component.
        public void SetComponent(System.Object componentObject) {
            init();
            //Get the object type of the component...
            if (components.ContainsKey(componentObject.GetType().Name)) {
                components[componentObject.GetType().Name] = componentObject;
            } else {
                // We don't have this component registered...
                // So let's register it.
                RegisterComponent(componentObject);
            }
        }

        //Get the component in the databucket defined by componentType.
        // In order to have smooth running, if the type doesn't exist in the DataBucket
        // Then a new component will be registered with its default values, then returned.

        public T GetRegisteredComponent<T>() {
            init();
            string objectName = typeof(T).Name;
            if(!components.ContainsKey(objectName)) {
                System.Object componentObject = Activator.CreateInstance(typeof(T));
                // Register Component
                RegisterComponent(componentObject);
            }

            return (T)components[objectName];
        }
        #endregion

        #region Private Functions
        private void init() {
            if (components == null) {
                components = new Dictionary<string, System.Object>();
            }
        }
        #endregion
    }
}
