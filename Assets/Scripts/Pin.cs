using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 10f;

    private bool isPinned = false;
    private bool isLaunched = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Debug.Log("delta Time : " + Time.deltaTime); // 콘솔 뷰에서 프레임 시간 간격 출력
        if(isPinned == false && isLaunched == true) {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        isPinned = true;
        if(other.gameObject.tag == "Target") {
            // 자식 게임 오브젝트 찾기
            GameObject childObject = transform.Find("Square").gameObject; // 첫 번째 방법
            // GameObject childObject = transform.GetChild(0).gameObject; // 두 번쩨 방법
            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true; // 충돌 시 막대기 화면에 나타내기

            transform.SetParent(other.gameObject.transform); // 타겟과 충돌하면 타겟을 부모로 설정해서 같이 회전   

            GameManager.instance.DecreaseGoal();       
        }
        else if(other.gameObject.tag == "Pin") {
            GameManager.instance.SetGameOver(false);
        }
    }

    public void Launch() {
        isLaunched = true;
    }
}
