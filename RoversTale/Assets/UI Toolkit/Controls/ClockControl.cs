using System;
using UnityEngine.UIElements;
using UnityEngine;

public class ClockControl : VisualElement
{
    Label clockLabel;

    public new class UxmlFactory : UxmlFactory<ClockControl, UxmlTraits> { }
    public new class UxmlTraits : VisualElement.UxmlTraits{ }
    public ClockControl(){
        clockLabel = new Label();
        clockLabel.text = "12:60AM";
        clockLabel.AddToClassList("title");
        this.Add(clockLabel);
        RegisterCallback<GeometryChangedEvent>(OnGeometryChanged);

    }

    private void OnGeometryChanged(GeometryChangedEvent evt)
    {
        IVisualElementScheduledItem clockTimer = schedule.Execute(ClockCount);
        clockTimer.Every(100); //makes the clock check every 100ms
    }

    public void ClockCount(){
        var time = DateTime.Now;
        int hour = time.Hour;
        int minute = time.Minute;

        string am_pm = "AM";
        if(hour >= 12){
            hour -= 12;
            am_pm = "PM";
        }
        if(hour == 0){
            hour = 12;
        }

        string finalTime = hour.ToString() + ":" + minute.ToString("0#") + am_pm;
        clockLabel.text = finalTime;
    }
}
