using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIScript : MonoBehaviour {

	public float fadeSpeed = 5f;
	public float fadeTime = 10f;
	private bool colorT = false;
	private bool paused;
	public TextMesh goText;
	public TextMesh oneText;
	public TextMesh twoText;
	public TextMesh threeText;
	public TextMesh timerText;
	public AudioSource[] sources;
	public AudioSource sourceOne;
	public AudioSource sourceTwo;
	public AudioSource sourceThree;
	public GameObject player;
	public Canvas mainScreen;
	public Canvas aboutScreen;
	public Canvas learnMore;
	public Canvas selectScreen;
	public Canvas pauseScreen;
	public Canvas optionsScreen;
	public Canvas countdownScreen;
	public Canvas selectMapScreen;
	public Slider slide;
	private float vol;
	public GameObject track;
	private float timer = 0.0f;
	private float otherTime;
	int sec;
	int min;
	public TextMesh lapNum;
	// Use this for initialization
	void Start () {
		aboutScreen.enabled = false;
		learnMore.enabled = false;
		selectScreen.enabled = false;
		optionsScreen.enabled = false;

		if (!countdownScreen.isActiveAndEnabled) {
			countdownScreen.enabled = true;
		}

		oneText.GetComponent<Renderer>().enabled = false;
		twoText.GetComponent<Renderer>().enabled = false;
		threeText.GetComponent<Renderer>().enabled = false;
		goText.GetComponent<Renderer>().enabled = false;

		sources = GetComponents<AudioSource> ();
		sourceOne = sources [0];
		sourceTwo = track.GetComponent<AudioSource> ();

		if (Application.loadedLevel == 1||Application.loadedLevel == 2|| Application.loadedLevel == 3) {
			mainScreen.enabled = false;
			pauseScreen.enabled = false;
			StartCoroutine (go ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		timer = Time.timeSinceLevelLoad;
		if (Input.GetButtonDown("Submit1") || Input.GetButtonDown("Submit2")){
			Paused ();
		}
		if (colorT) {
			fadeOut ();
		}

		min = (int)(timer/60f);
		sec = (int)(timer % 60f);
		timerText.text = string.Format("{00:00}:{1:00}",min,sec);
		plusLap ();
	}

	public void LoadLevel1(){
		Application.LoadLevel ("Level1");
	}

	public void About(){
		mainScreen.enabled = false;
		aboutScreen.enabled = true;
	}
	public void Options(){
		mainScreen.enabled = false;
		optionsScreen.enabled = true;
	}
	public void LearnMore(){
		mainScreen.enabled = false;
		learnMore.enabled = true;
	}
	public void SelectMap(){
		selectScreen.enabled = false;
		selectMapScreen.enabled = true;
	}
	public void Return(){
		mainScreen.enabled = true;
		aboutScreen.enabled = false;
		learnMore.enabled = false;
		selectScreen.enabled = false;
		optionsScreen.enabled = false;
	}
	public void ReturnToPause(){
		print ("HI");
		optionsScreen.enabled = false;
		pauseScreen.enabled = true;
		aboutScreen.enabled = false;
		learnMore.enabled = false;
		selectScreen.enabled = false;
	}
	public void Quit(){
		Application.Quit ();
	}
	public void SelectPlayer(){
		mainScreen.enabled = false;
		selectScreen.enabled = true;
	}
	public void loadLevel2(){
		Application.LoadLevel ("Level2");
	}
	public void LoadLevel3(){
		Application.LoadLevel ("Level3");
	}

	public void Paused(){
			sourceTwo.Pause ();
			pauseScreen.enabled = true;
			paused = true;
			Time.timeScale = 0;
	}
	public void Resume(){
		sourceTwo.Play ();
		pauseScreen.enabled = false;
		paused = false;
		Time.timeScale = 1;
	}
	public void VolumeDown(){
		
		AudioListener.volume -= 0.5f;
		vol = AudioListener.volume;
		print (vol);
	}
	public void VolumeUp(){

		AudioListener.volume += 0.5f;
		vol = AudioListener.volume;
		print (vol);
	}

	IEnumerator go()
	{
		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | 
			RigidbodyConstraints.FreezeRotationY|RigidbodyConstraints.FreezeRotationZ;

		player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | 
			RigidbodyConstraints.FreezePositionY|RigidbodyConstraints.FreezePositionZ;

		sourceOne.Play ();
		threeText.GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds (1);
		threeText.GetComponent<Renderer>().enabled = false;

		twoText.GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds (1);
		twoText.GetComponent<Renderer> ().enabled = false;

		oneText.GetComponent<Renderer>().enabled = true;
		yield return new WaitForSeconds (1);
		oneText.GetComponent<Renderer>().enabled = false;
		colorT = true;
		//timeCounter.GetComponent<Renderer>().enabled = true;
		sourceTwo.Play ();
		goText.GetComponent<Renderer>().enabled = true;
		player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
		yield return new WaitForSeconds (1);
		goText.GetComponent<Renderer>().enabled = false;

	}
	void fadeOut()
	{
		float fade = Mathf.SmoothDamp (
			goText.color.a, 0f, ref fadeSpeed, fadeTime);
		goText.color = new Color (0f, 255f, 0f, fade);
	}
	void plusLap(){
		
		lapNum.text = string.Format("Lap: {0}",CarCheckpoint.currentLap);
	}
}
