using IncidentApp.Domain;
using IncidentApp.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IncidentApp.Infrastructure.ModelConfigurations;

public class SurveyConfiguration : IdentityModelConfigurationBase<Survey>
{
    protected override void AddCustomConfiguration(EntityTypeBuilder<Survey> builder)
    {
        builder.Property(survey => survey.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Navigation(additionalService => additionalService.Questions).AutoInclude();

        builder.HasMany(survey => survey.Questions)
            .WithOne(question => question.Survey)
            .HasForeignKey(question => question.SurveyId);
    }
}