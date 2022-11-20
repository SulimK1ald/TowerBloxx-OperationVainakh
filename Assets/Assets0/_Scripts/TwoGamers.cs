using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TwoGamers : MonoBehaviour
{
    public void ChooseSecondMap()
    {
        SceneManager.LoadScene("Map2");
    }
}
