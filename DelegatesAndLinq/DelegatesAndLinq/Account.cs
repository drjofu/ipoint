namespace DelegatesAndLinq
{
  internal class Account
  {
    public string Customer { get; set; }
    public int AccountNumber { get; set; }
    public double Balance { get; set; }

    public override string ToString()
    {
      return $"{AccountNumber} {Customer,-10} {Balance:0.00}";
    }
  }
}
