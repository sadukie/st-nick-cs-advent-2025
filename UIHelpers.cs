using Spectre.Console;

namespace StNicholasTUI;

public static class UIHelpers
{
    public static void ShowAsciiArt(string title)
    {
        AnsiConsole.Clear();
        AnsiConsole.MarkupLine("[bold gold1 underline]" + title + "[/]\n");

        AnsiConsole.MarkupLine("[green]   🎄[/]");
        AnsiConsole.MarkupLine("[green]  🎄🎄[/]");
        AnsiConsole.MarkupLine("[green] 🎄🎄🎄[/]");
        AnsiConsole.MarkupLine("[green]🎄🎄🎄🎄[/]");
        AnsiConsole.MarkupLine("[yellow]   |||[/]");

        Thread.Sleep(500);
    }
}