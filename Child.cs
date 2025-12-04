namespace StNicholasTUI;

public class Child
{
    // C# 14 - No need for an explicit backing field
    public required string Name
    {
        get;
        set => field = value.Trim();
    }

    public List<string> Wishlist
    {
        get => field ??= new();
        set => field = value ?? new();
    }
    public void AddToWishlist(string gift)
    {
        if (!Wishlist.Contains(gift)){
            Wishlist.Add(gift);
        }
    }
}
