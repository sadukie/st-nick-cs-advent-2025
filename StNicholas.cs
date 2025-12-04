using Spectre.Console;

namespace StNicholasTUI;

public class StNicholas
{
    private readonly Dictionary<string, Child> _registry = new();

    public Child GetOrCreateChild(string rawName)
    {
        var name = rawName.Trim();
        return _registry.TryGetValue(name, out var child)
            ? child
            : (_registry[name] = new Child { Name = name });
    }

    public Dictionary<string, Child> GetAllChildren() => _registry;

    public void DeliverGifts()
    {
        AnsiConsole.Clear();
        UIHelpers.ShowAsciiArt("Delivering Gifts...");

        AnsiConsole.Status()
            .Spinner(Spinner.Known.Christmas)
            .Start("Preparing sleigh...", ctx =>
            {
                Thread.Sleep(1000);
            });

        AnsiConsole.MarkupLine("[gold1 bold]🎅 Preparing gifts...[/]\n");

        AnsiConsole.Progress()
            .AutoClear(true)
            .HideCompleted(true)
            .Columns(new ProgressColumn[]
            {
                    new TaskDescriptionColumn(),
                    new ProgressBarColumn(),
                    new PercentageColumn(),
                    new RemainingTimeColumn(),
                    new SpinnerColumn(Spinner.Known.Christmas)
            })
            .Start(ctx =>
            {
                var task = ctx.AddTask("[green]Packing and delivering gifts[/]");

                while (!task.IsFinished)
                {
                    task.Increment(5);
                    Thread.Sleep(120);
                }
            });

        var table = new Table()
            .Border(TableBorder.Rounded)
            .BorderColor(Color.Gold1)
            .AddColumn("[bold green]Child[/]")
            .AddColumn("[bold yellow]Gifts Delivered[/]");

        foreach (var child in _registry.Values)
        {
            var gifts = child.Wishlist is { Count: > 0 }
                ? string.Join(", ", child.Wishlist)
                : "🍬 Candy Cane (no wishlist)";
            table.AddRow($"[bold]{child.Name}[/]", gifts);
        }

        AnsiConsole.MarkupLine("\n[gold1 bold]🎁 Delivery Complete![/]\n");
        AnsiConsole.Write(table);
        _registry.Clear();
    }
}
