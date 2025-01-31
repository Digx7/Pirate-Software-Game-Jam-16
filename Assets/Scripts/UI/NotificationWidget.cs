using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class NotificationWidget : UIWidget
{
    public float timeShown = 5f;
    public float waitUntilFadeOutTime = 2f;
    public float fadeOutSpeed = 1f;
    public TextMeshProUGUI notificationTextMeshPro;
    public Image panel;
    public StringChannel requestBigNotificationChannel;
    public UIWidgetDataChannel requestUnloadUIWidget;
    public UIWidgetData notificationUIWidgetData;
    
    private string notificationText;

    public override void Setup(UIWidgetData newUIWidgetData)
    {
        base.Setup(newUIWidgetData);
        Render();
    }

    public override void Teardown()
    {
        base.Teardown();
    }
    
    private void Render()
    {
        notificationText = requestBigNotificationChannel.LastValue;

        notificationTextMeshPro.text = notificationText;
        StartCoroutine(FadeOut());
        StartCoroutine(TimeOut());
    }

    IEnumerator TimeOut()
    {
        yield return new WaitForSeconds(timeShown);
        requestUnloadUIWidget.Raise(notificationUIWidgetData);
    }

    IEnumerator FadeOut()
    { 
        yield return new WaitForSeconds(waitUntilFadeOutTime);
        while (true)
        {
            Color panelColor = panel.color;
            Color textColor = notificationTextMeshPro.color;

            float delta = (Time.deltaTime/fadeOutSpeed);
            panelColor.a -= delta;
            textColor.a -= delta;

            panel.color = panelColor;
            notificationTextMeshPro.color = textColor;
            yield return null;
        }
    }
}
