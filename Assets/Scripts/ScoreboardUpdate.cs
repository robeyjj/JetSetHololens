using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreboardUpdate : MonoBehaviour {
    TextMesh scoreBoard;
    static int sdsuBuildingCount = 0;
    static int sdsuLogoCount = 0;
    static int rocketPosterCount = 0;
    static int astronautPosterCount = 0;
    static int priceCount = 0;
    static float countdownTimer = 60;
    
    // Use this for initialization
    void Start()
    {
        scoreBoard = GetComponent<TextMesh>();
        scoreBoard.text = "Timer: " + countdownTimer + "\n" +
                          "SDSU Building: " + sdsuBuildingCount + " / 20  \n" +
                          "SDSU Logo: " + sdsuLogoCount + " / 20 \n" +
                          "Astronaut: " + astronautPosterCount + " / 20 \n" +
                          "Rocketship: " + rocketPosterCount + " / 20 \n" +
                          "Price: " + priceCount + " / 20 \n";
    }

    // Update is called once per frame
    void Update()
    {
        scoreBoard.text = "Timer: " + countdownTimer + "\n" +
                          "SDSU Building: " + sdsuBuildingCount + " / 20  \n" +
                          "SDSU Logo: " + sdsuLogoCount + " / 20 \n" +
                          "Astronaut: " + astronautPosterCount + " / 20 \n" +
                          "Rocketship: " + rocketPosterCount + " / 20 \n" +
                          "Price: " + priceCount + " / 20 \n";
        //Debug.Log(rocketPosterCount);
        countdownTimer -= Time.deltaTime;
        if (countdownTimer < 0)
        {
            SceneManager.LoadScene("Lose");
        }
        if (sdsuBuildingCount >= 20 && sdsuLogoCount >= 20 && rocketPosterCount >= 20 && astronautPosterCount >= 20 && priceCount >= 20)
        {
            SceneManager.LoadScene("Win");
        }

    }

    public static void particleBoxColliderRemover(GameObject other)
    {
        BoxCollider particlesBoxCollider = other.GetComponent<BoxCollider>();
        Destroy(other.GetComponent<BoxCollider>());
    }

    public static void BoardUpdater(GameObject self)
    {
        //rocketPosterCount++;

        if (self.tag == "Astronaut")
        {
            astronautPosterCount++;
        }
        else if (self.tag == "Price")
        {
            priceCount++;
        }
        else if (self.tag == "RocketPoster")
        {
            rocketPosterCount++;
            Debug.Log("INCREMENTING");
        }
        else if (self.tag == "SDSULogo")
        {
            sdsuLogoCount++;
        }
        else if (self.tag == "SDSUBuilding")
        {
            sdsuBuildingCount++;
        }
        else { }
    }
}
