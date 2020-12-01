using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int PlayerScore = 0;
    public static int AIScore = 0;
    public Text uiText;
    public Text whoScores;
    public static bool Goal { get; private set; }
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Goal = false;
        uiText.text = "Score:0-0";
        PlayerScore = 0;
        AIScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    private void OnTriggerEnter2D(Collider2D box)
    {
        if (!Goal)
        {
            if (box.tag == "AiGoal")
            {
                PlayerScore++;
                Goal = true;
                StartCoroutine(ResetPuck(false));
                whoScores.text = "Last Goal: Player";



            }
            else if (box.tag == "PlayerGoal")
            {
                AIScore++;
                Goal = true;
                StartCoroutine(ResetPuck(true));
                whoScores.text = "Last Goal: AI";
            }
        }
        uiText.text = "Score:" + PlayerScore + "-" + AIScore;
        if (PlayerScore == 5 || AIScore == 5)
        {
            SceneManager.LoadScene("Result");
        }
    }

    private IEnumerator ResetPuck(bool whoScores)
    {
        yield return new WaitForSecondsRealtime(1);
        Goal = false;
        rb.velocity = rb.position = new Vector2(0, 0);
        if (whoScores)
        rb.velocity = rb.position = new Vector2(0, -1);
        else rb.velocity = rb.position = new Vector2(0, 1);

    }
}
