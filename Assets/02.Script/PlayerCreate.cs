using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//<summary>
//이미지 인식을 하게되면
//큐브 위 지정된 위치에
//Player 생성
// </summary>

public class PlayerCreate : MonoBehaviour
{
    public GameObject player;

    public void CreatePlayer()
    {
        this.gameObject.SetActive(true);
        player.SetActive(true);
    }
}
