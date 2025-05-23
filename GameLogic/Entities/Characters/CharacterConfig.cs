using System.Diagnostics.CodeAnalysis;
using GameLogic.Entities.Skills;

namespace GameLogic.Entities.Characters;

public interface ICharacterRecord
{
    public string Id { get; }
    public string Name { get; }
    public int Health { get; }
    public int Attack { get; }
    public int Defense { get; }
    public List<SkillRecord> Skills { get; }
}

public record CharacterRecord : ICharacterRecord
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public int Health { get; init; }
    public int Attack { get; init; }
    public int Defense { get; init; }
    public List<SkillRecord> Skills { get; init; } = new();
}

public class CharacterConfig
{
    public required string Id { get; init; }
    public required string Name { get; init; }
    public int Health { get; init; }
    public int Attack { get; init; }
    public int Defense { get; init; }
    public List<Skill> Skills { get; init; } = new();

    [SetsRequiredMembers]
    public CharacterConfig(ICharacterRecord record)
    {
        this.Id = record.Id;
        this.Name = record.Name;
        this.Health = record.Health;
        this.Attack = record.Attack;
        this.Defense = record.Defense;

        foreach (SkillRecord skillRecord in record.Skills)
        {
            Skill skill = SkillFactory.CreateFromRecord(skillRecord);
            this.Skills.Add(skill);
        }
    }
}
