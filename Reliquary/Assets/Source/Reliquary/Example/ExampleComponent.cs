using UnityEngine;
using System.Collections;
using Reliquary;

public class ExampleComponent {

    private float someValue;
    private float someOtherValue;
    private bool someFlag;

    public float SomeValue {
        get {
            return someValue;
        }
        set {
            someValue = value;
        }
    }

    public float SomeOtherValue {
        get {
            return someOtherValue;
        }
        set {
            someOtherValue = value;
        }
    }

    public bool SomeFlag {
        get {
            return someFlag;
        }
        set {
            someFlag = value;
        }
    }

    public override string ToString() {
        return someValue + " " + someOtherValue + " " + someFlag;
    }
}
