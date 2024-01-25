namespace recruitment_app.DTOs.QuestionDTOs
{
    public record struct CreateQuestionDto(
        string Contents,
        List<GetLanguageDto> Languages
    );
}
