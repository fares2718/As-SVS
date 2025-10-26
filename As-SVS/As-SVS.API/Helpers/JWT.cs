namespace As_SVS.API.Helpers
{
    public class JWT
    {
        public string Key { get; set; }
        public string Audience { get; set; }
        public string Isuuer { get; set; }
        public string DurationTimeInDays { get; set; }
    }
}
