﻿namespace Onspring.API.SDK.Models
{
    public class TimeSpanFieldValue : RecordFieldValue
    {
        public TimeSpanData Value { get; set; }

        public TimeSpanFieldValue()
        {
            Type = Enums.ResultValueType.TimeSpan;
        }

        public TimeSpanFieldValue(TimeSpanData value) : this()
        {
            Value = value;
        }
    }
}
