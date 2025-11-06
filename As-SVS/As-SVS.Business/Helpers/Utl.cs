namespace As_SVS.Business.Helpers
{
    public static class Utl
    {
        public static string GetMimeType(string filePath)
        {
            var extensions = Path.GetExtension(filePath);

            return extensions switch
            {
                ".jpg" or ".jpeg" => "image/jpg",
                ".png" => "image/png",
                ".mp4" => "video/mp4",
                _ => "application/octec-stream",
            };
        }
    }
}
