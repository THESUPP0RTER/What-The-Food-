using Class1;
using Console_Runner;
using User;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {
        public class Testing
        {
            UM um = new UM();
            Context context = new Context();
            [Fact]
            public void CreateUserSuccess()
            {
                //Arange
                string tester = "unitTester";
                Account acc = new Account();
                acc.Email = tester;
                acc.Password = "password1";
                acc.Fname = "fname";
                acc.Lname = "lname";
                acc.accessLevel = 1;
                //Act
                um.UserSignUp(acc);
                //Assert
                Assert.True(context.accounts.Find(acc.Email) != null);
                
            }

            [Fact]
            // trys to delete a user, while acting as if an admin executed the command
            public void deleteUserSuccess()
            {
                //Arange
                string tester = "UnitTestUser";
                Account acc = new Account();
                acc.Email = tester;
                acc.Password = "password1";
                acc.Fname = "fname";
                acc.Lname = "lname";
                acc.accessLevel = 1;
                um.UserSignUp(acc);
                //Act
                um.UserDelete(acc, tester);
                //Assert
                Assert.True(context.accounts.Find("UnitTestUser") == null);
            }
            [Fact]
            public void updateSuccess()
            {
                //Arange
                Account currentUser = makeAdmin();
                string newTester = "newTester";
                string tester = "UnitTestUser";
                Account acc = new Account();
                acc.Email = tester;
                acc.Password = "password1";
                acc.Fname = "fname";
                acc.Lname = "lname";
                acc.accessLevel = 1;
                um.UserSignUp(acc);
                string nName = "new name";
                string nlName = "new last name";
                string nPassword = "NewPassword";
                //act
                um.UserUpdateData(currentUser, acc.Email, nName, nlName, nPassword);
                acc = context.accounts.Find(acc.Email);
                //Assert
                Assert.True(acc.Fname == nName && acc.Lname == nlName && acc.Password == nPassword);
            }

            public Account makeAdmin()
            {
                if (context.accounts.Find("Admin") != null)
                {
                    context.accounts.Remove(context.accounts.Find("Admin"));
                }
                Account currentUser = new Account();
                currentUser.Email = "Admin";
                currentUser.Password = "pass";
                currentUser.Fname = "fname";
                currentUser.Lname = "lname";
                currentUser.accessLevel = 2;
                um.UserSignUp(currentUser);
                return currentUser;
            }
        }

    }
}
