using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;
	public TextMeshProUGUI nameText;
	public string currentUser;
	public string bestUser = "";
	public int bestResult = 0;
	private Menu menu;
   
    void Awake()
    {
        if(Instance!= null){
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		
		
		LoadUser();
		
    }
	
	  [System.Serializable]
  class SaveData{
	 public string name;
	 public int record;
  }
  
  public void GetCurrentUser(){
	  currentUser = nameText.text;
  }
  
  
public void SaveUser(){
	SaveData saveData = new SaveData();
	saveData.name = bestUser;
	saveData.record =bestResult;
	string json = JsonUtility.ToJson(saveData);
	File.WriteAllText(Application.persistentDataPath+"/saveData.json",json);
	
}

public void LoadUser(){
	string path = Application.persistentDataPath+"/saveData.json";
	if(File.Exists(path)){
		string json = File.ReadAllText(path);
		SaveData user = JsonUtility.FromJson<SaveData>(json);
		bestResult = user.record;
		bestUser  = user.name;
		
	}
}

public void ResetRecord(){
	SaveData saveData = new SaveData();
	saveData.name = "";
	saveData.record = 0;
	string json = JsonUtility.ToJson(saveData);
	File.WriteAllText(Application.persistentDataPath+"/saveData.json",json);
	currentUser = "";
	bestResult = 0;
	menu = GameObject.Find("Canvas").GetComponent<Menu>();
	menu.bestResult.text = "Best Score";
	
}

public void UpdateResult( int result){
	bestUser = currentUser;
	bestResult = result;
}
	
	
	
	

  
}
