using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject pinObject;

    private Pin currPin;

    // Start is called before the first frame update
    void Start() // 맨 처음 한 번 실행하는 메소드
    {
        PreparePin();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)
        && currPin != null
        && GameManager.instance.isGameOver == false) {
            currPin.Launch();
            currPin = null;
            Invoke("PreparePin", 0.1f);
        }
    }

    void PreparePin() {
        if(GameManager.instance.isGameOver == false) {
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
    }
}
