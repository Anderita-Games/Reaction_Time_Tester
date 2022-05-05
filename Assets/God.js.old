#pragma strict
var Instructions : UnityEngine.UI.Text;

var Reaction_Best : UnityEngine.UI.Text;

var Countdown_Time : float;
var Countup_Time : float;

function Start () {
	Instructions.text = "Tap to start";
}

function Update () {
	if (Input.GetMouseButtonDown(0) && Instructions.text == "wait") {
		Instructions.text = "You tapped too early! Tap to try again.";
	}else if (Input.GetMouseButtonDown(0) && Instructions.text == "tap the screen!") {
		Instructions.text = "You took " + Countup_Time + "  seconds! Tap to try again.";
		if (PlayerPrefs.GetFloat("BestTime") == null || PlayerPrefs.GetFloat("BestTime") == 0) {
			PlayerPrefs.SetFloat("BestTime", Countup_Time);
		}else if (Countup_Time < PlayerPrefs.GetFloat("BestTime")) {
			PlayerPrefs.SetFloat("BestTime", Countup_Time);
		}
	}else if (Input.GetMouseButtonDown(0)) {
		Totally_Not_Waiting();
	}

	if (Instructions.text == "tap the screen!") {
		Countup_Time += Time.deltaTime;
	}

	Reaction_Best.text = "Fastest reaction: " + PlayerPrefs.GetFloat("BestTime") +" seconds";
}

function Totally_Not_Waiting () {
	Countup_Time = 0;
	Countdown_Time = Random.Range(3.0f, 7.0f);
	Instructions.text = "wait";
	yield WaitForSeconds (Countdown_Time);
	if (Instructions.text == "wait") {
		Instructions.text = "tap the screen!"; 
	}
}