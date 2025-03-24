using IncidentApp.Domain;
using IncidentApp.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Infrastructure.ModelConfigurations;

public class QuestionConfiguration : IdentityModelConfigurationBase<Question>
{
    protected override void AddCustomConfiguration(EntityTypeBuilder<Question> builder)
    {
        builder.Property(question => question.QuestionText)
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(question => question.Type)
            .IsRequired();

        builder.Property(question => question.OptionsJson)
            .IsRequired()
            .HasMaxLength(500);

        builder.HasOne(question => question.Survey)
            .WithMany(survey => survey.Questions)
            .HasForeignKey(question => question.SurveyId);
    }
}