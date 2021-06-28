//==========================================
// writer : 노현석
// file : SceneController.cs
// content : 신간 이동 통제 컨트롤러
// discript : 한 신에서 다른 신으로 이동해야 할 경우 MovetToScene("신 이름") 호출
//==========================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
