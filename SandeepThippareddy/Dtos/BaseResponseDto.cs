namespace SandeepThippareddy.Dtos
{
    public class BaseResponseDto
    {
        public int ResponseStatus { get; set; }
        public string ResponseMessage { get; set; }
        public string RedirectUrl { get; set; }
    }
}
