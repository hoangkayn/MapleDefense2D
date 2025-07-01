using System.Collections.Generic;

public static class SkillDescriptionFormatter
{
    public static string Format(string template, Dictionary<string, string> replacements)
    {
        foreach (var pair in replacements)
        {
            template = template.Replace($"{{{pair.Key}}}", pair.Value);
        }
        return template;
    }
}
