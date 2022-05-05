using UnityEngine;
using System.Collections;

[System.Serializable]
public partial class God : MonoBehaviour
{
    public UnityEngine.UI.Text Instructions;
    public UnityEngine.UI.Text Reaction_Best;
    public float Countdown_Time;
    public float Countup_Time;
    public virtual void Start()
    {
        this.Instructions.text = "Tap to start";
    }

    public virtual void Update()
    {
        if (Input.GetMouseButtonDown(0) && (this.Instructions.text == "wait"))
        {
            this.Instructions.text = "You tapped too early! Tap to try again.";
        }
        else
        {
            if (Input.GetMouseButtonDown(0) && (this.Instructions.text == "tap the screen!"))
            {
                this.Instructions.text = ("You took " + this.Countup_Time) + "  seconds! Tap to try again.";
                if ((PlayerPrefs.GetFloat("BestTime") == null) || (PlayerPrefs.GetFloat("BestTime") == 0))
                {
                    PlayerPrefs.SetFloat("BestTime", this.Countup_Time);
                }
                else
                {
                    if (this.Countup_Time < PlayerPrefs.GetFloat("BestTime"))
                    {
                        PlayerPrefs.SetFloat("BestTime", this.Countup_Time);
                    }
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.StartCoroutine(this.Totally_Not_Waiting());
                }
            }
        }
        if (this.Instructions.text == "tap the screen!")
        {
            this.Countup_Time = this.Countup_Time + Time.deltaTime;
        }
        this.Reaction_Best.text = ("Fastest reaction: " + PlayerPrefs.GetFloat("BestTime")) + " seconds";
    }

    public virtual IEnumerator Totally_Not_Waiting()
    {
        this.Countup_Time = 0;
        this.Countdown_Time = Random.Range(3f, 7f);
        this.Instructions.text = "wait";
        yield return new WaitForSeconds(this.Countdown_Time);
        if (this.Instructions.text == "wait")
        {
            this.Instructions.text = "tap the screen!";
        }
    }

}