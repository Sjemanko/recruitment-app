namespace recruitment_app.DTOs
{
    public record struct CreateUserDto(
        string FirstName,
        string LastName,
        DateOnly BirthdayDate,
        string Experience,
        string SecondarySkills,
        List<GetLanguageDto> Languages,
        string Email,
        string Image
    );
}