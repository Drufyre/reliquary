using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Reliquary {
    public class ComponentDataBucket : MonoBehaviour {

        #region Protected Fields
        protected Dictionary<string, System.Object> components;
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

        //Unregister a component by type.
        public bool UnregisterComponent(String componentType) {
            init();
            if (components.ContainsKey(componentType)) {
                return components.Remove(componentType);
            } else {
                return false;
            }
        }

        //Unregister a component by the object itself.
        // Same as the above.  The value isn't actually considered, only its type.
        public bool UnregisterComponent(System.Object componentObject) {
            init();
            if (components.ContainsKey(componentObject.GetType().Name)) {
                return components.Remove(componentObject.GetType().Name);
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

        public System.Object GetRegisteredComponent(System.Object componentObject) {

            return GetRegisteredComponent(componentObject.GetType());
        }

        //Get the component in the databucket defined by componentType.
        // In order to have smooth running, if the type doesn't exist in the DataBucket
        // Then a new component will be registered with its default values, then returned.
        public System.Object GetRegisteredComponent(Type componentType) {

            init();
            string objectType = componentType.Name;
            if (!components.ContainsKey(objectType)) {
                System.Object componentObject = Activator.CreateInstance(componentType);
                RegisterComponent(componentObject);
            }

            return components[objectType];
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
