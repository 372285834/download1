/*
 * Author:      熊哲
 * CreateTime:  10/9/2017 3:53:36 PM
 * Description:
 * 
*/
using UnityEngine;

namespace EZFramework.UniSDK.UnityNative
{
    public class DataAnalytics : UniSDK.DataAnalytics
    {
#if UNITY_ANALYTICS
        public override void SetUserInfo(string userId, int gender = 2, int birthYear = 0)
        {
            ResultCheck(UnityEngine.Analytics.Analytics.SetUserId(userId));
            ResultCheck(UnityEngine.Analytics.Analytics.SetUserGender((UnityEngine.Analytics.Gender)gender));
            if (birthYear >= 1900 && birthYear <= 2010)
                ResultCheck(UnityEngine.Analytics.Analytics.SetUserBirthYear(birthYear));
        }
        public override void Transaction(string productId, decimal amount, string currency)
        {
            ResultCheck(UnityEngine.Analytics.Analytics.Transaction(productId, amount, currency));
        }
        public override void Transaction(string productId, decimal amount, string currency, string receiptPurchaseData, string signature)
        {
            ResultCheck(UnityEngine.Analytics.Analytics.Transaction(productId, amount, currency));
        }
        public override void Submit(CustomEvent customEvent)
        {
            ResultCheck(UnityEngine.Analytics.Analytics.CustomEvent(customEvent.eventName, customEvent.eventData));
        }

        private void ResultCheck(UnityEngine.Analytics.AnalyticsResult result)
        {
            if (result != UnityEngine.Analytics.AnalyticsResult.Ok)
            {
                Log("AnalyticsResult: " + result);
            }
        }
#endif
    }
}