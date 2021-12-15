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
                Account acc = makeTestUser();
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
                Account currentUser = makeAdmin();
                //Act
                um.UserDelete(currentUser, "UnitTestUser");
                //Assert
                Assert.True(context.accounts.Find("UnitTestUser") == null);
            }
            [Fact]
            public void updateSuccess()
            {
                //Arange
                Account currentUser = makeAdmin();
                Account testUser = makeTestUser();
                string nName = "new name";
                string nlName = "new last name";
                string nPassword = "NewPassword";
                //act
                um.UserUpdateData(currentUser, testUser.Email, nName, nlName, nPassword);
                testUser = context.accounts.Find(testUser.Email);
                //Assert
                Assert.True(testUser.Fname == nName && testUser.Lname == nlName && testUser.Password == nPassword);
            }
            public Account makeAdmin()
            {
                Account currentUser = new Account();
                if (context.accounts.Find("UnitTestAdmin") == null)
                {

                    currentUser.Email = "UnitTestAdmin";
                    currentUser.Password = "password1";
                    currentUser.Fname = "fname";
                    currentUser.Lname = "lname";
                    currentUser.accessLevel = 2;
                    um.UserSignUp(currentUser);
                }
                else
                {
                    currentUser = context.accounts.Find("UnitTestAdmin");
                }
                return currentUser;
            }
            public Account makeTestUser()
            {
                Account currentUser = new Account();
                if (context.accounts.Find("UnitTestUser") == null)
                {

                    currentUser.Email = "UnitTestUser";
                    currentUser.Password = "password1";
                    currentUser.Fname = "fname";
                    currentUser.Lname = "lname";
                    currentUser.accessLevel = 1;
                    um.UserSignUp(currentUser);
                }
                else
                {
                    currentUser = context.accounts.Find("UnitTestUser");
                }
                return currentUser;
            }
        }

    }
}
