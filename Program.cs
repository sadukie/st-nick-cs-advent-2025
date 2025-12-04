using Spectre.Console;
using System;

namespace StNicholasTUI
{
    public static class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            UIHelpers.ShowAsciiArt("St. Nicholas' Magical Gift Registry");

            var nick = new StNicholas();
            bool running = true;

            while (running)
            {
                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[bold green]What would you like to do?[/]")
                        .AddChoices(
                            "Add or lookup a child",
                            "Add gift to wishlist",
                            "Deliver gifts",
                            "Exit"
                        )
                );

                switch (choice)
                {
                    case "Add or lookup a child":
                        var name = AnsiConsole.Ask<string>("Enter the child's name:");
                        var child = nick.GetOrCreateChild(name);
                        AnsiConsole.MarkupLine($"[green]Registered or retrieved:[/] [bold]{child.Name}[/]");
                        if (child.Wishlist == null)
                        {
                            AnsiConsole.MarkupLine("[yellow]No gifts in wishlist yet.[/]");
                        }
                        else
                        {
                            foreach (var wishlistItem in child.Wishlist)
                            {
                                AnsiConsole.MarkupLine($" - {wishlistItem}");
                            }
                        }
                        break;
                    case "Add gift to wishlist":
                        var name2 = AnsiConsole.Ask<string>("Which child?");
                        var child2 = nick.GetOrCreateChild(name2);

                        AnsiConsole.Markup($"What gift would [bold]{child2.Name}[/] like?");
                        var gift = Console.ReadLine();
                        child2.AddToWishlist(gift!);

                        AnsiConsole.MarkupLine($"[yellow]Added[/] [bold]{gift}[/] to [bold]{child2.Name}[/]'s wishlist!");
                        break;

                    case "Deliver gifts":
                        nick.DeliverGifts();
                        break;
                    case "Exit":
                        running = false;
                        break;
                }
            }

            AnsiConsole.MarkupLine("[bold gold1]✨ Farewell from St. Nicholas![/]");
        }
    }
}
