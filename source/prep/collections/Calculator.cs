using System;
using System.Data;

namespace prep.collections
{
  public class Calculator
  {
    IDbConnection connection;

    public Calculator(IDbConnection connection)
    {
        this.connection = connection;
    }
    
    public int add(int i, int i1)
    {
        if ((i < 0) || (i1 < 0))
            throw new ArgumentException();

        connection.Open();

        return i + i1;
    }

     
  }
}
