using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	public Text TextGold;
	public Camera MainCamera;
	public GameObject Effectspark;
	public AudioClip ClickAudio;
	public Text UpgradeCollectGoldText;
	
	// Use this for initialization
	void Start ()
	{
		TextGold.text = DataController.Instance.GameData.Gold.ToString();
		StartCoroutine(StartCollectGold());
	}
	//코루틴 : 
	IEnumerator StartCollectGold()
	{
		while (true)
		{
			yield return new WaitForSecondsRealtime(1f); // 1초를 쉬는것 
			DataController.Instance.GameData.Gold += DataController.Instance.GameData.GoldPerSec; //골드를 추가
			TextGold.text = DataController.Instance.GameData.Gold.ToString(); // 추가된 골드를 이용해 텍스트 변경
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) //마우스 버튼이 눌리는 시점에서 
		{
			DataController.Instance.GameData.Gold += DataController.Instance.GameData.GoldPerSec; //골드를 추가
			TextGold.text = DataController.Instance.GameData.Gold.ToString(); // 추가된 골드를 이용해 텍스트 변경
			MainCamera.ScreenPointToRay(Input.mousePosition);        

			Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100f))
			{
				Debug.Log(hit.point);
				Debug.DrawLine(ray.origin , hit.point , Color.red); //마우스클릭한 곳과 카메라간에 선을 그림
				Instantiate(Effectspark, hit.point, Effectspark.transform.rotation); //
				MainCamera.gameObject.AddComponent<AudioSource>().PlayOneShot(ClickAudio); //오디오 재생
			}
		}
	}

	public void UpgradeCollectGold()
	{
		int Cost = DataController.Instance.GameData.CollectGoldLevel * DataController.Instance.GameData.CollectGoldLevel;
		
		if (DataController.Instance.GameData.Gold < Cost)
		{
			return;
		}
		DataController.Instance.GameData.CollectGoldLevel += 1;
		DataController.Instance.GameData.GoldPerSec = DataController.Instance.GameData.CollectGoldLevel;
		DataController.Instance.GameData.Gold -= Cost;
		TextGold.text = DataController.Instance.GameData.Gold.ToString();
		UpgradeCollectGoldText.text = DataController.Instance.GameData.Gold.ToString();

		String upgradeText = String.Format("골드수집 속도 향상 \n 현재 : {0}, 가격 : {1} Gold"
			, DataController.Instance.GameData.CollectGoldLevel,
			Cost);
		UpgradeCollectGoldText.text = upgradeText;
	}
}
