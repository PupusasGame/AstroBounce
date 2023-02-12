using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class GameManager : MonoBehaviour
{
    public int totalPieces;
    public bool[] ballUnlock = new bool[9];
    public bool[] nivelUnlock = new bool[3];

    static public GameManager gameManager;
    public int playersprite = 0;

    private InterstitialAd interstitial;

    private void Awake()
    {

        DontDestroyOnLoad(this.gameObject);
        if (gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        LoadData();
    }

    private void Start()
    {
        RequestInterstitial();
    }

   
    private void RequestInterstitial()
    {
        string adUnitId = "ca-app-pub-6737259196260392/3292442823";
        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);
    }

    public void GameOver()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            this.interstitial.Destroy();
        }

    }

    public void CallAd()
    {
        RequestInterstitial();
    }

    
    public void SaveData()
    {
        SaveSystem.SaveData(this);
    }

    public void LoadData()
    {
        GameData data = SaveSystem.LoadData();
        if(data != null) { 
            totalPieces = data.pieces;
            playersprite = data.playerSprite;

            ballUnlock[0] = data.ballunlock[0];
            ballUnlock[1] = data.ballunlock[1];
            ballUnlock[2] = data.ballunlock[2];
            ballUnlock[3] = data.ballunlock[3];
            ballUnlock[4] = data.ballunlock[4];
            ballUnlock[5] = data.ballunlock[5];
            ballUnlock[6] = data.ballunlock[6];
            ballUnlock[7] = data.ballunlock[7];
            ballUnlock[8] = data.ballunlock[8];

            nivelUnlock[0] = data.nivelunlock[0];
            nivelUnlock[1] = data.nivelunlock[1];
            nivelUnlock[2] = data.nivelunlock[2];
        }
    }
}