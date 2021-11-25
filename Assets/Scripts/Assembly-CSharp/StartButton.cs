using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// Token: 0x0200002F RID: 47
public class StartButton : MonoBehaviour
{
	// Token: 0x060000EF RID: 239 RVA: 0x000081E0 File Offset: 0x000065E0
	private void Start()
	{
		this.button = base.GetComponent<Button>();
		this.button.onClick.AddListener(new UnityAction(this.StartGame));
	}

    // Token: 0x060000F0 RID: 240 RVA: 0x0000820C File Offset: 0x0000660C
    private void StartGame()
    {
        switch (base.name) {
            case "StoryButton":
                PlayerPrefs.SetString("CurrentMode", "story");
                SceneManager.LoadScene("School");
                break;
            case "EndlessButton":
                PlayerPrefs.SetString("CurrentMode", "endless");
                SceneManager.LoadScene("School");
                break;
            case "NightButton":
                PlayerPrefs.SetString("CurrentMode", "story");
                SceneManager.LoadScene("School_night");
                break;
			case "BaldiButton":
                PlayerPrefs.SetString("CurrentMode", "endless");
                SceneManager.LoadScene("School_onlyderpys");
                break;
            case "SmallButton":
                PlayerPrefs.SetString("CurrentMode", "endless");
                SceneManager.LoadScene("Small_School");
                break;
            case "OneRoomButton":
                PlayerPrefs.SetString("CurrentMode", "endless");
                SceneManager.LoadScene("School_OneRoom");
                break;
        }
	}

	// Token: 0x040001A6 RID: 422
	private Button button;
}
