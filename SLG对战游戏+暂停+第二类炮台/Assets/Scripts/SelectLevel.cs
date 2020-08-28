using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    public void OnButtonSelect1()
    {
        SceneManager.LoadScene(2);
    }
    public void OnButtonSelect2()
    {
        SceneManager.LoadScene(3);
    }
}
