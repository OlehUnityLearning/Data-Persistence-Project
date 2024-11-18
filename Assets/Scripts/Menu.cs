using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Menu : MonoBehaviour
{
	public TextMeshProUGUI bestResult;
	
	
	void Start(){
		if(GameManager.Instance.bestUser != ""){
			bestResult.text = $"Best score : {GameManager.Instance.bestUser} : {GameManager.Instance.bestResult}";
		}
	}
	
    public void StartGame(){
		SceneManager.LoadScene(1);
	}
	
	public void ExitGame(){
			
		#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
	}
    
}
