﻿using System;
namespace prep.collections
{
  public class Calculator
  {
    public int add(int i, int i1)
    {
        if (i1 < 0)
            throw new ArgumentException();
        return i + i1;
    }
  }
}