namespace recruitment_app.DTOs.QuestionDTOs
{
    public class GetQuestionDto
    {
        public Guid Uuid { get; set; }
        public string? Contents { get; set; }
        public List<GetLanguageDto>? Languages { get; set; }
    }
}
