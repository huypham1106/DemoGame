using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Banner : MonoBehaviour
{
    //private BannerView bannerView;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });
        this.RequestBanner();
        
    }

#if UNITY_ANDROID
    private string _adUnitId = "ca-app-pub-6540649555949670/5455899909";
#elif UNITY_IPHONE
  private string _adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
  private string _adUnitId = "unused";
#endif

    BannerView bannerView;

    /// <summary>
    /// Creates a 320x50 banner view at top of the screen.
    /// </summary>
    public void RequestBanner()
    {
        Debug.Log("Creating banner view");

        // If we already have a banner, destroy the old one.
/*        if (_bannerView != null)
        {
            DestroyAd();
        }*/

        // Create a 320x50 banner at top of the screen
        bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);

        AdRequest adRequest = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(adRequest);
    }
}
