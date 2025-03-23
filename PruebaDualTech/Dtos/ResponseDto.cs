namespace PruebaDualTech.Dtos
{
    public class ResponseDto
    {
        public bool success {  get; set; }
        public string message { get; set; } = string.Empty;
        public string[] errors { get; set; } = new string[0];
        public dynamic? Data { get; set; } 

    }
}
