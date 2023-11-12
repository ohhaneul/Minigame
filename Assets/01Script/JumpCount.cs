using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCount : MonoBehaviour
{
    SpriteRenderer sr;
    public Image[] UIjump;


    //점프 count 하나씩 늘어날 때마다 아이콘 하나씩 사라지게(투명하게)

    public void JumpIconUpdate(int JumpCount) // 화면에 표시되어야하는 점프 icon갯수를 전달 받아서 표시
    {
        for(int i = 0; i < 4; i++)
        {
            if (i < JumpCount)
                UIjump[i].color = Color.white;
            else
                UIjump[i].color = Color.clear;
        }
    }

    
}
