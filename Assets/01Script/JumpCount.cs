using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpCount : MonoBehaviour
{
    SpriteRenderer sr;
    public Image[] UIjump;


    //���� count �ϳ��� �þ ������ ������ �ϳ��� �������(�����ϰ�)

    public void JumpIconUpdate(int JumpCount) // ȭ�鿡 ǥ�õǾ���ϴ� ���� icon������ ���� �޾Ƽ� ǥ��
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
