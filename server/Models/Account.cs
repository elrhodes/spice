namespace spice.Models;

public class Account : Profile
{
  public string Email { get; set; }
}

public class Profile
{
  public string Id { get; set; }
  public string Name { get; set; }
  public string Picture { get; set; }


}
// here we are extending the profile class to include email for the account class, originally the Account class had all the information, but since we added the profile class we can now use that to extend other classes if needed// the profile class has the basic information that we need for a profile, and the account class has the email information that we need for an account// this is useful because we can now use the profile class for other classes that need the basic profile information without needing the email information// this is also useful because we can now use the account class for classes that need the email information as well as the basic profile information// this is a common practice in object oriented programming called inheritance, where we create a base class with common properties and then extend that class to create more specific classes with additional properties// this helps to reduce code duplication and makes the code more maintainable and easier to read.
