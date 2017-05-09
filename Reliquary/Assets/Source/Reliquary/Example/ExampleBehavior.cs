using UnityEngine;
using System.Collections;
using Reliquary;

public class ExampleBehavior : ReliquaryBehavior{

    private ExampleComponent exampleComponent;
	
	// Update is called once per frame
	void Update () {
        exampleComponent = GetBucketComponent<ExampleComponent>();
        ProcessValues();
        PrintValues();
        SetBucketComponent(exampleComponent);
	}

    private void ProcessValues() {
        exampleComponent.SomeFlag = !exampleComponent.SomeFlag;
        exampleComponent.SomeValue += Time.deltaTime;
        if(exampleComponent.SomeFlag) {
            exampleComponent.SomeOtherValue += Time.deltaTime;
        }
    }

    private void PrintValues() {
        Debug.Log(exampleComponent.ToString());
    }
}
