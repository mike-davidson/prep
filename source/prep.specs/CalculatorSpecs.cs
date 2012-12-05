using System;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using prep.collections;
using developwithpassion.specifications.extensions;
using System.Data;

namespace prep.specs
{
  [Subject(typeof(Calculator))]
  public class CalculatorSpecs
  {
    public abstract class concern : Observes<Calculator>
    {
    }




    public class when_adding_two_numbers : concern
    {
      Establish c = () =>
      {
        command = fake.an<IDbCommand>();
        connection = depends.on<IDbConnection>();

        connection.setup(x => x.CreateCommand()).Return(command);
      };

      Because b = () =>
        result = sut.add(2, 3);

      It should_open_a_connection_to_the_database = () =>
        connection.received(x => x.Open());

      It should_run_a_stored_procedure = () =>
        command.received(x => x.ExecuteNonQuery());
        

      It should_return_the_sum = () =>
        result.ShouldEqual(5);

      static int result;
      static IDbConnection connection;
      static IDbCommand command;
    }
    public class when_attempting_to_shut_off_the_calculator : concern
    {
      Establish c = () =>
      {
        principal = fake.an<IPrincipal>();
        spec.change(() => Thread.CurrentPrincipal).to(principal);
      };


      public class and_they_are_not_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(false);
        };
        Because b = () =>
          spec.catch_exception(() => sut.shut_off());

        It should_throw_a_security_exceptionn = () =>
          spec.exception_thrown.ShouldBeAn<SecurityException>();
          
      }

      public class and_they_are_in_the_correct_security_group
      {
        Establish c = () =>
        {
          principal.setup(x => x.IsInRole(Arg<string>.Is.Anything)).Return(true);
        };

        Because b = () =>
          sut.shut_off();

        It should_not_do_anything_that_causes_an_error = () =>
        {

        };
          
      }
      static IPrincipal principal;
    }

    public class when_attempting_to_add_a_negative_to_a_positive : concern
    {
      Because b = () =>
        spec.catch_exception(() => sut.add(2, -3));
        

      It should_throw_an_argument_exception = () =>
        spec.exception_thrown.ShouldBeAn<ArgumentException>(); 
    }
  }

}
