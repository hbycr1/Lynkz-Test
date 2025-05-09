namespace Application.Models.Common;
internal static class ShapeInstructionRegex
{
    public static string Pattern = @"draw an? (\w+(?: \w+)?) with an? ((?:\w+ ?){1,2}) of (\w+)(?: and an? ((?:\w+ ?){1,2}) of (\w+))?";
}
