using DelegatesAndLinq;
using System;
using System.Collections.Generic;
using System.Linq;

List<Account> accounts = new List<Account>
{
  new Account{AccountNumber=1, Customer="Donald", Balance=-2345},
  new Account{AccountNumber=5, Customer="Micky", Balance=76474},
  new Account{AccountNumber=3, Customer="Daisy", Balance=74745},
  new Account{AccountNumber=7, Customer="Goofy", Balance=555}
};

//foreach(var account in accounts)
//  Console.WriteLine(account);

//ExtensionMethods.Print(accounts, "as static method call");
accounts.Print("calling as Extension Method");

//new int[] { 12, 2435, 436 }.Print();
//"hello".Print("string");

Comparison<Account> compareFunction = new Comparison<Account>(CompareByNumber);

accounts.Sort(compareFunction);
accounts.Print("by number");

accounts.Sort(CompareByBalance);
accounts.Print("by balance");

// anonymous function (C# 2)
accounts.Sort(delegate (Account a, Account b)
{
  return a.Customer.CompareTo(b.Customer);
});
accounts.Print("by customer");

// Lambda expression (C# 3)
int direction = -1;
accounts.Sort((a, b) =>  // goes to
{
  return direction * a.AccountNumber.CompareTo(b.AccountNumber);
});
accounts.Print("by number");

accounts.Sort((a, b) => a.AccountNumber.CompareTo(b.AccountNumber));

// Language integrated query
var result = accounts
  .Where(a => a.Balance > 0)
  .OrderByDescending(a => a.AccountNumber)
  .Select(a => new  {  a.Customer, a.Balance })
  .ToList();

result.Print("using LINQ");
result.Print("using LINQ");

//var result2 = ExtensionMethods.GetTexts()
//  .Where(t => t.Length == 5);

//result2.Print("Texts");

var result3 =ExtensionMethods.GetTexts()
  .Where(t => t.Length == 5)
  .Any();
Console.WriteLine(result3);

//var micky = accounts
//  .Where(a => a.Customer == "Micky")
//  .SingleOrDefault();
var micky = accounts
  .SingleOrDefault(a => a.Customer == "Micky");

Console.WriteLine("found: " + (micky?.Customer ?? "nothing found"));

// Language integrated query syntax
var result4= from a in accounts
             where a.Balance>0
             orderby a.AccountNumber descending
             select new {a.Balance, a.Customer};



//var aaa = new { Number = 123, Text = "hello" };
//Console.WriteLine(aaa.Number);
//Console.WriteLine(aaa.Text);
////aaa.Text = "xxx";

Console.ReadLine();

static int CompareByNumber(Account a, Account b)
{
  return a.AccountNumber - b.AccountNumber;
}
static int CompareByBalance(Account a, Account b)
{
  return a.Balance.CompareTo(b.Balance);
}