
try
{
	try
	{
		int x = 0;
		int y = 1 / x;

	}

	catch (DivideByZeroException ex)
	{
		throw new ApplicationException("something went wrong", ex);
	}
	catch (Exception ex)
	{

	}
}
catch (Exception ex)
{
}

