using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DrinkingContestScript : MonoBehaviour
{
    [SerializeField] Transform topPivot;
    [SerializeField] Transform bottomPivot;

    [SerializeField] Transform beer;

    float beerPosition;
    float beerDestination;

    float beerTimer;
    [SerializeField] float timerMultiplicator = 3f;

    float beerSpeed;
    [SerializeField] float smoothMotion = 1f;

    [SerializeField] Transform hook;
    float hookPosition;
    [SerializeField] float hookSize = 0.1f;
    [SerializeField] float hookPower = 0.5f;
    float hookProgress;
    float hookPullVelocity;
    [SerializeField] float hookPullPower = 0.1f;
    [SerializeField] float hookGravityPower = 0.005f;
    [SerializeField] float hookProgressDegradationPower = 0.1f;

    [SerializeField] Transform progressBarContainer;

    [SerializeField] float failTimer = 10f;

    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

    bool stopGame = false;

    // Start is called before the first frame update
    void Start()
    {
        stopGame = false;
        winText.SetActive(false);
        loseText.SetActive(false);
        Globals.isPaused = false;
        Globals.isPausedExit = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopGame) { SceneTransition(); }
        Beer();
        Hook();
        ProgressCheck();
    }

     void Beer()
    {
        if (stopGame) { return; }
        beerTimer -= Time.deltaTime;
        if (beerTimer < 0f)
        {
            beerTimer = UnityEngine.Random.value * timerMultiplicator;

            beerDestination = UnityEngine.Random.value;
        }

        beerPosition = Mathf.SmoothDamp(beerPosition, beerDestination, ref beerSpeed, smoothMotion);
        beer.position = Vector3.Lerp(bottomPivot.position, topPivot.position, beerPosition);
    }

    void Hook()
    {
        if (stopGame) { return; }
        if (Input.GetMouseButton(0))
        {
            hookPullVelocity += hookPullPower * Time.deltaTime;
        }
        
        hookPullVelocity -= hookGravityPower * Time.deltaTime;

        hookPosition += hookPullVelocity;

        if(hookPosition - hookSize / 2 <= 0f && hookPullVelocity < 0f)
        {
            hookPullVelocity = 0f;
        }
        if(hookPosition + hookSize / 2 >= 1f && hookPullVelocity > 0f)
        {
            hookPullVelocity= 0f;
        }

        hookPosition = Mathf.Clamp(hookPosition, hookSize / 2, 1.0f - hookSize / 2);
        hook.position = Vector3.Lerp(bottomPivot.position, topPivot.position, hookPosition);


    }

    void ProgressCheck()
    {
        if (stopGame) { return; }
        Vector3 ls = progressBarContainer.localScale;
        ls.y = hookProgress;
        progressBarContainer.localScale = ls;

        float min = hookPosition - hookSize/ 2;
        float max = hookPosition + hookSize/ 2;

        if(min < beerPosition && max > beerPosition)
        {
            hookProgress += hookPower * Time.deltaTime;
        }
        else
        {
            hookProgress -= hookProgressDegradationPower * Time.deltaTime;

            failTimer -= Time.deltaTime;
            if(failTimer < 0f)
            {
                stopGame = true;
                Lose();
            }
        }

        if(hookProgress >= 1f)
        {
            stopGame= true;
            Win();
        }

        hookProgress = Mathf.Clamp(hookProgress, 0f, 1f);

    }


    public void SceneTransition()
    {
        SceneManager.LoadScene("SampleScene");
    } 

    public void Win()
    {
        winText.SetActive(true);

        if (Globals.drunkenness <= 90)
            Globals.drunkenness += 10;
        else
            Globals.drunkenness = 100;
        StartCoroutine(ExampleCoroutine());
    }

    public void Lose()
    {
        loseText.SetActive(true);

        if (Globals.drunkenness >= 10)
            Globals.drunkenness -= 10;
        else
            Globals.drunkenness = 0;
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);

    }
}
