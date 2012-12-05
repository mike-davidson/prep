using System;
using System.Data;

namespace prep.collections
{
  public class Calculator
  {

      private IDbConnection connection;

      public Calculator(IDbConnection connection)
      {
          this.connection = connection;
      }

      
    public int add(int i, int i1)
    {
        this.connection.Open();

        if ((i < 0) || (i1 < 0))
            throw new ArgumentException();

        return i + i1;
    }
  }
}