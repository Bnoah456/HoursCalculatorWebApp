namespace HoursCalculatorWeb.Models
{
    public class CalculatorModel
    {
        public int StartHour { get; set; }
        public int EndHour { get; set;}
        public int StartMinute { get; set;}
        public int EndMinute { get; set;}
        public string AmPM1 { get; set; }
        public string AmPM2 { get; set; }
        public string calculate { get; set; }
        public int Hour_result { get; set; }
        public int Minute_result { get; set; }
        
        //public string Resetting { get; set; }

    }
}
